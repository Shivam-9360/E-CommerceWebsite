using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "HOME";
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Title = "ABOUT US";
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Title = "CONTACT US";
            return View();
        }

        public ActionResult Shop(int categorySort = 0, int priceSort = 0)
        {
            ViewBag.Title = "SHOP";

            string productCategory = categorySort == 1 ? "Sneakers" : categorySort == 2 ? "Formals" : categorySort == 3 ? "Sports Shoes" : "No Category";

            var productListModel = new ProductListModel();
            productListModel.CategorySort = categorySort;
            productListModel.PriceSort = priceSort;
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                if (categorySort != 0 && priceSort != 0)
                {
                    if (priceSort == 1)
                    {
                        productListModel.ProductList = databaseEntity.Products.Where(s => s.Category == productCategory).OrderBy(s => s.Price).ToList<Product>();
                    }
                    else
                    {
                        productListModel.ProductList = databaseEntity.Products.Where(s => s.Category == productCategory).OrderByDescending(s => s.Price).ToList<Product>();
                    }
                }
                else if (priceSort != 0)
                {
                    if (priceSort == 1)
                    {
                        productListModel.ProductList = databaseEntity.Products.OrderBy(s => s.Price).ToList<Product>();

                    }
                    else
                    {
                        productListModel.ProductList = databaseEntity.Products.OrderByDescending(s => s.Price).ToList<Product>();
                    }
                }
                else if (categorySort != 0)
                {
                    productListModel.ProductList = databaseEntity.Products.Where(s => s.Category == productCategory).ToList<Product>();
                }
                else
                {
                    productListModel.ProductList = databaseEntity.Products.ToList<Product>();
                }

            }
            return View(productListModel);
        }
    }
}