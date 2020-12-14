using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace tony_compurter.Models
{
    public class Rating
    {
        [Key]
        public int id { get; set; }
        public int product_id { get; set; }
        public int star { get; set; }
        public string comment { get; set; }
        public int customer_id { get; set; }
        public DateTime date { get; set; }
    }
}