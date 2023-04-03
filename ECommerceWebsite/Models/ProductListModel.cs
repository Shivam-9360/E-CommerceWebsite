using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class ProductListModel
    {
        public List<ProductModel> ProductList { get; set; } = new List<ProductModel>();
        public int CategorySort { get; set; }
        public int PriceSort { get; set; }
    }
}