using ECommerceWebsite.Models;
using ECommerceWebsite.Utilities;
using ECommerceWebsite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int productID)
        {
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var product = databaseEntity.Products.Where(s => s.Product_ID == productID).FirstOrDefault<Product>();
                if (product != null)
                {
                    var productModel = new ProductModel()
                    {
                        ID = product.Product_ID,
                        Name = product.Product_Name,
                        Description = product.Description,
                        ImagePath_1 = product.ImagePath_1,
                        ImagePath_2 = product.ImagePath_2,
                        ImagePath_3 = product.ImagePath_3,
                        ImagePath_4 = product.ImagePath_4,
                        Price = product.Price,
                        Stock = product.Stock,
                        Category = product.Category,
                        Reviews = ReviewModelHelpers.ToReviewModelList(databaseEntity.Reviews.Where(s => s.Product_ID == product.Product_ID).ToList()),
                    };
                    return View(productModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpPost]
        public JsonResult Reviews(ReviewModel userReview)
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
                var newReview = new Review
                {
                    Product_ID = databaseEntity.Products.Where(s => s.Product_Name == userReview.Product_Name).FirstOrDefault<Product>().Product_ID,
                    Customer_ID = databaseEntity.Customers.Where(s => s.Email == AuthenticationUtility.CurrentCustomer.Email).FirstOrDefault<Customer>().Customer_ID,
                    Liking = userReview.Liking,
                    Description = userReview.Description
                };

                databaseEntity.Reviews.Add(newReview);
                databaseEntity.SaveChanges();
            }
            return Json(new JsonObjectUtility()
            {
                Title = "Success",
                Message = "Thank you for your review!"
            });
        }
    }
}