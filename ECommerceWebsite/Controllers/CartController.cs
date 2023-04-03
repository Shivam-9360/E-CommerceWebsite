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
                && s.IsInCart == true
                && s.IsOrdered == false).ToList());
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
                s.Customer_ID == databaseEntity.Customers.Where(customer => customer.Email == AuthenticationUtility.CurrentCustomer.Email).FirstOrDefault<Customer>().Customer_ID
                && s.IsWished == true
                && s.IsOrdered == false).ToList());
            }

            return View(cartModel);
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
                        IsOrdered = false,
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
                    }

                    if (existingProduct.IsInCart == false && existingProduct.IsWished == false && existingProduct.IsOrdered == false)
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
    }
}

