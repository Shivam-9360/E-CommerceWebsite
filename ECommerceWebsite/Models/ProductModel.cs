using ECommerceWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImagePath_1 { get; set; }
        public string ImagePath_2 { get; set; }
        public string ImagePath_3 { get; set; }
        public string ImagePath_4 { get; set; }
        public int Stock { get; set; }
        public int? Price { get; set; }
        public bool? IsInCart { get; set; }
        public bool? IsInWishList { get; set; }
        public bool? IsOrdered { get; set; }
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public ProductListModel SimiliarProducts { get; set; }  = new ProductListModel();
    }
}