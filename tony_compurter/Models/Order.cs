using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace tony_compurter.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int customer_id { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public int status { get; set; }
    }
}