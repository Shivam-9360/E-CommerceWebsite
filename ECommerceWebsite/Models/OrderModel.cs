using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class OrderModel
    {
        public CustomerModel Customer { get; set; } = new CustomerModel();
        public DateTime OrderDate { get; set; }
        public int OrderNO { get; set; }
        public CartModel CartItems { get; set; }
        public int BasePrice { get; set;}
        public int ShippingPrice { get; set;}
        public int? Discount { get; set;}
    }
}