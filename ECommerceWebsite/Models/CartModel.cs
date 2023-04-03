using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class CartModel
    {
        public List<ProductModel> ProductList { get; set; } = new List<ProductModel>();
        public List<int> Quantity { get; set; } = new List<int>();
    }
}