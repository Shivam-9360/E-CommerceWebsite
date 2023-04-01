using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Helpers
{
    public class ReviewModelHelpers
    {
        public static List<ReviewModel> ToReviewModelList(List<Review> reviewList)
        {
            var reviewModelList = new List<ReviewModel>();
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                foreach (var review in reviewList.ToList())
                {
                    var reviewModel = new ReviewModel()
                    {
                        Product_Name = databaseEntity.Products.Where(s => s.Product_ID ==  review.Product_ID).FirstOrDefault<Product>().Product_Name,
                        Description = review.Description,
                        Liking = review.Liking,
                        Customer_Name = databaseEntity.Customers.Where(s => s.Customer_ID == review.Customer_ID).FirstOrDefault<Customer>().FullName
                    };
                    reviewModelList.Add(reviewModel);
                }
            }
            return reviewModelList;
        }
    }
}