using ECommerceWebsite.Helpers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return RedirectToAction("Index", "LoginSignup");
            }

            CartModel cartModel;
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                cartModel = CartModelHelper.ToCartModelList(databaseEntity.Carts.Where(s =>
                s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID
                && s.IsInCart == true).ToList());
            }

            return View(cartModel);
        }

        public ActionResult WishList()
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return RedirectToAction("Index", "LoginSignup");
            }

            CartModel cartModel;
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                cartModel = CartModelHelper.ToCartModelList(databaseEntity.Carts.Where(s =>
                s.Customer_ID == databaseEntity.Customers.Where(customer => customer.Email == AuthenticationUtility.CurrentCustomer.Email).FirstOrDefault<Customer>().Customer_ID && s.IsWished == true).ToList());
            }

            return View(cartModel);
        }

        public ActionResult Order(int orderNO)
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "User is not logged in"
                });
            }

            var orderModel = OrderModelHelper.ToOrderModel(orderNO);

            if(orderModel == null)
            {
                //Error
                return View();
            }

            return View(orderModel);
        }

        [HttpPost]
        public JsonResult AddToCart(int productID, int isWished)
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "User is not logged in"
                });
            }

            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var existingProduct = databaseEntity.Carts.Where(s => s.Product_ID == productID && s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID).FirstOrDefault<Cart>();

                if (existingProduct != null)
                {
                    if (isWished == 1)
                    {
                        existingProduct.IsWished = true;
                    }
                    else
                    {
                        existingProduct.IsInCart = true;
                    }
                }
                else
                {
                    var newProduct = new Cart
                    {
                        Product_ID = productID,
                        Customer_ID = AuthenticationUtility.CurrentCustomer.ID,
                        Quantity = 1,
                        IsWished = isWished == 1,
                        IsInCart = isWished != 1
                    };

                    databaseEntity.Carts.Add(newProduct);
                }
                databaseEntity.SaveChanges();
            }
            return Json(new JsonObjectUtility()
            {
                Title = "Success",
                Message = isWished == 1 ? "Product added successfully to the wishlist" : "Product added successfully to the cart"
            });
        }

        [HttpPost]
        public JsonResult RemoveFromCart(int productID, int isWished)
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "User is not logged in"
                });
            }

            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var existingProduct = databaseEntity.Carts.Where(s => s.Product_ID == productID && s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID).FirstOrDefault<Cart>();

                if (existingProduct != null)
                {
                    if (isWished == 1)
                    {
                        existingProduct.IsWished = false;
                    }
                    else
                    {
                        existingProduct.IsInCart = false;
                        existingProduct.Quantity = 0;
                    }

                    if (existingProduct.IsInCart == false && existingProduct.IsWished == false)
                    {
                        databaseEntity.Carts.Remove(existingProduct);
                    }

                    databaseEntity.SaveChanges();

                    return Json(new JsonObjectUtility()
                    {
                        Title = "Success",
                        Message = isWished == 1 ? "Product successfully removed from Wish List" : "Product successfully removed from Cart"
                    });
                }

                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "Product not found"
                });
            }
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int productID, int quantity)
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "User is not logged in"
                });
            }
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var existingProduct = databaseEntity.Carts.Where(s => s.Product_ID == productID && s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID).FirstOrDefault<Cart>();
                if (existingProduct != null)
                {
                    existingProduct.Quantity = quantity;
                    databaseEntity.SaveChanges();

                    return Json(new JsonObjectUtility()
                    {
                        Title = "Success",
                        Message = "Product quantity updated"
                    });
                }
                else
                {
                    return Json(new JsonObjectUtility()
                    {
                        Title = "Failed",
                        Message = "Product not found"
                    });
                }
            }
        }

        [HttpPost]
        public JsonResult SubmitOrder(string customerAddress, int basePrice, int shippingPrice, int discount)
        {
            if (!AuthenticationUtility.IsLoggedIn)
            {
                return Json(new JsonObjectUtility()
                {
                    Title = "Failed",
                    Message = "User is not logged in"
                });
            }

            using (var databaseEntity = new SoleStoreDBEntities())
            {
                databaseEntity.Customers.Where(s => s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID).FirstOrDefault().Address = customerAddress;
                AuthenticationUtility.CurrentCustomer.Address = customerAddress;

                int orderNO = new Random().Next(1000, 9999);

                var cartItems = databaseEntity.Carts.Where(
                    s => s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID 
                    && s.IsInCart == true).ToList<Cart>();

                foreach(var cartItem in cartItems)
                {
                    cartItem.IsInCart = false;

                    databaseEntity.Orders.Add(new Order
                    {
                        Order_NO = orderNO,
                        Customer_ID = AuthenticationUtility.CurrentCustomer.ID,
                        Order_Date = DateTime.Now,
                        Base_Price = basePrice,
                        Shipping_price = shippingPrice,
                        Discount = discount,
                        Cart_ID = cartItem.Cart_ID
                    });
                }

                databaseEntity.SaveChanges();

                return Json(new JsonObjectUtility
                {
                    Title = "Success",
                    Message = orderNO.ToString()
                });
            }
        }
    }
}

