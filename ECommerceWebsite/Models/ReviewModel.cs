﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class ReviewModel
    {
        public string Customer_Name { get; set; }
        public int Product_ID { get; set; }
        public string Description { get; set; }
        public string Liking { get; set; }
    }
}