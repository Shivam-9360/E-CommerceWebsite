using ECommerceWebsite.Models;
using ECommerceWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Helpers
{
    public class OrderModelHelper
    {
        public static OrderModel ToOrderModel(int orderNO)
        {
            using (var databaseEntity = new SoleStoreDBEntities())
            {
                var orderList = databaseEntity.Orders.Where(s => s.Order_NO == orderNO && s.Customer_ID == AuthenticationUtility.CurrentCustomer.ID).ToList();

                if(orderList.Count == 0 )
                {
                    return null;
                }

                List<Cart> cartList = new List<Cart>();
                foreach (var order in orderList)
                {
                    cartList.Add(databaseEntity.Carts.Where(s => s.Cart_ID == order.Cart_ID).FirstOrDefault());
                }

                return new OrderModel
                {
                    OrderNO = orderNO,
                    OrderDate = orderList[0].Order_Date,
                    BasePrice = orderList[0].Base_Price,
                    ShippingPrice = orderList[0].Shipping_price,
                    Discount = orderList[0].Discount,
                    Customer = AuthenticationUtility.CurrentCustomer,
                    CartItems = CartModelHelper.ToCartModelList(cartList)
                };
            }
        }
    }
}