using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public String PhoneNumber { get; set; } 
        public String Email { get; set; }
        public String Password { get; set; } 
        public String Address { get; set; }
    }
}