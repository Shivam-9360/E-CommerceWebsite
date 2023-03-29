using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class ProductListModel
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public int CategorySort { get; set; }
        public int PriceSort { get; set; }
    }
}