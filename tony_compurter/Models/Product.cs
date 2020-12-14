using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace tony_compurter.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public int product_type { get; set; }
        public string photo { get; set; }
        public int discount { get; set; }
        public double price { get; set; }
        public string title { get; set; }
        public string infor { get; set; }
    }
}