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
                    var productModel = ProductModelHelper.ToProductModel(product, true, true);
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
                    Product_ID = userReview.Product_ID,
                    Customer_ID = AuthenticationUtility.CurrentCustomer.ID,
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