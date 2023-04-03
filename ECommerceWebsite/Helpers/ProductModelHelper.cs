using ECommerceWebsite.Models;
using ECommerceWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ECommerceWebsite.Helpers
{
    public class ProductModelHelper
    {
        public static ProductModel ToProductModel(Product product, bool getCartInfo, bool getRelatedInfo)
        {
            var productModel = new ProductModel
            {
                ID = product.Product_ID,
                Name = product.Product_Name,
                Description = product.Description,
                Category = product.Category,
                ImagePath_1 = product.ImagePath_1,
                ImagePath_2 = product.ImagePath_2,
                ImagePath_3 = product.ImagePath_3,
                ImagePath_4 = product.ImagePath_4,
                Stock = product.Stock,
                Price = product.Price,
            };

            if (getCartInfo)
            {
                using (var databaseEntity = new SoleStoreDBEntities())
                {
                    var cartItem = databaseEntity.Carts.Where(s =>
                                        s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID
                                        && s.Product_ID == product.Product_ID).FirstOrDefault();
                    if (cartItem != null)
                    {
                        productModel.IsInCart = cartItem.IsInCart;
                        productModel.IsInWishList = cartItem.IsWished;
                    }
                    else
                    {
                        productModel.IsInCart = false;
                        productModel.IsInWishList = false;
                        productModel.IsOrdered = false;
                    }
                }
            }

            if (getRelatedInfo)
            {
                using (var databaseEntity = new SoleStoreDBEntities())
                {
                    productModel.Reviews = ReviewModelHelpers.ToReviewModelList(databaseEntity.Reviews.Where(s => s.Product_ID == product.Product_ID).ToList());
                    productModel.SimiliarProducts.ProductList = ProductModelHelper.ToProductListModel(databaseEntity.Products.Where(s => s.Product_ID != product.Product_ID && s.Category == product.Category).Take(3).ToList<Product>());
                }
            }

            return productModel;
        }

        public static List<ProductModel> ToProductListModel(List<Product> productList)
        {
            List<ProductModel> productModelList = new List<ProductModel>();

            foreach (Product product in productList)
            {
                productModelList.Add(new ProductModel
                {
                    ID = product.Product_ID,
                    Name = product.Product_Name,
                    Description = product.Description,
                    Category = product.Category,
                    ImagePath_1 = product.ImagePath_1,
                    ImagePath_2 = product.ImagePath_2,
                    ImagePath_3 = product.ImagePath_3,
                    ImagePath_4 = product.ImagePath_4,
                    Stock = product.Stock,
                    Price = product.Price,
                });
            }

            return productModelList;
        }
    }
}