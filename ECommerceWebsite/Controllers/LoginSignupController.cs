using ECommerceWebsite.Models;
using ECommerceWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class LoginSignupController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerModel customerLogin)
        {
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var existingCustomer = databaseEntity.Customers.Where(s => s.Email == customerLogin.Email).FirstOrDefault<Customer>();
                if (existingCustomer != null)
                {

                    if(EncryptionDecryptionUtility.ValidatePassword(customerLogin.Password, existingCustomer.HashPassword, existingCustomer.HashSalt))
                    {
                        AuthenticationUtility.CurrentCustomer.FullName = existingCustomer.FullName;
                        AuthenticationUtility.CurrentCustomer.Email = existingCustomer.Email;
                        AuthenticationUtility.CurrentCustomer.PhoneNumber = existingCustomer.PhoneNumber;

                        AuthenticationUtility.IsLoggedIn = true;

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SignUp(CustomerModel customerSignup)
        {
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var existingCustomer = databaseEntity.Customers.Where(s => s.Email == customerSignup.Email).FirstOrDefault<Customer>();
                if(existingCustomer == null)
                {
                    var newCustomer = new Customer()
                    {
                        FullName = customerSignup.FullName,
                        Email = customerSignup.Email,
                        PhoneNumber = customerSignup.PhoneNumber
                    };
                    (newCustomer.HashPassword, newCustomer.HashSalt) = EncryptionDecryptionUtility.PasswordToHash(customerSignup.Password);

                    AuthenticationUtility.CurrentCustomer = customerSignup;
                    AuthenticationUtility.IsLoggedIn = true;

                    databaseEntity.Customers.Add(newCustomer);
                    databaseEntity.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            
        }
    }
}