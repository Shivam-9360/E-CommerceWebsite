using ECommerceWebsite.Helpers;
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

            List<Product> productList = new List<Product>();
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                productList.Add(databaseEntity.Products.Where(s => s.Category == "Backpack").FirstOrDefault());
                productList.Add(databaseEntity.Products.Where(s => s.Category == "Duffel").FirstOrDefault());
                productList.Add(databaseEntity.Products.Where(s => s.Category == "Purse").FirstOrDefault());
                productList.Add(databaseEntity.Products.Where(s => s.Category == "Suitcase").FirstOrDefault());
            }

            var productListModel = new ProductListModel
            {
                CategorySort = 0,
                PriceSort = 0,
                ProductList = ProductModelHelper.ToProductListModel(productList),
            };

            return View(productListModel);
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

            string productCategory = categorySort == 1 ? "Backpack" : categorySort == 2 ? "Duffel" : categorySort == 3 ? "Purse" : categorySort == 4 ? "Suitcase" : "No Category";

            List<Product> productList = new List<Product>();
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                if (categorySort != 0 && priceSort != 0)
                {
                    if (priceSort == 1)
                    {
                        productList = databaseEntity.Products.Where(s => s.Category == productCategory).OrderBy(s => s.Price).ToList<Product>();
                    }
                    else
                    {
                        productList = databaseEntity.Products.Where(s => s.Category == productCategory).OrderByDescending(s => s.Price).ToList<Product>();
                    }
                }
                else if (priceSort != 0)
                {
                    if (priceSort == 1)
                    {
                        productList = databaseEntity.Products.OrderBy(s => s.Price).ToList<Product>();

                    }
                    else
                    {
                        productList = databaseEntity.Products.OrderByDescending(s => s.Price).ToList<Product>();
                    }
                }
                else if (categorySort != 0)
                {
                    productList = databaseEntity.Products.Where(s => s.Category == productCategory).ToList<Product>();
                }
                else
                {
                    productList = databaseEntity.Products.ToList<Product>();
                }
            }

            var productListModel = new ProductListModel
            {
                CategorySort = categorySort,
                PriceSort = priceSort,
                ProductList =  ProductModelHelper.ToProductListModel(productList),
            };

            return View(productListModel);
        }
    }
}