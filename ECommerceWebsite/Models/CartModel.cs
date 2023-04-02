using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class CartModel
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public List<int> Quantity { get; set; } = new List<int>();

        public CartModel(List<Cart> cart) 
        {
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                foreach (var cartItem in cart)
                {
                    ProductList.Add(databaseEntity.Products.Where(s => s.Product_ID == cartItem.Product_ID).FirstOrDefault());
                    Quantity.Add(cartItem.Quantity);
                }
            }
        }

    }
}