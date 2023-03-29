using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Utilities
{
    public class AuthenticationUtility
    {
        public static bool IsLoggedIn { get; set; }
        public static CustomerModel CurrentCustomer { get; set; } = new CustomerModel();
    }
}