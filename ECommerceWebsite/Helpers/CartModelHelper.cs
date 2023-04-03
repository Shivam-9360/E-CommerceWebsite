using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Helpers
{
    public class CartModelHelper
    {
        public static CartModel ToCartModelList(List<Cart> cartList)
        {
            var cartModelList = new CartModel();  

            using (var databaseEntity = new SoleStoreDBEntities())
            {
                foreach (var cartItem in cartList)
                {
                    cartModelList.ProductList.Add(ProductModelHelper.ToProductModel(databaseEntity.Products.Where(s => s.Product_ID == cartItem.Product_ID).FirstOrDefault(), true, false));
                    cartModelList.Quantity.Add(cartItem.Quantity);
                }
            }

            return cartModelList;
        }
    }
}