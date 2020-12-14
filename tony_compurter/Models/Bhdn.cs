using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace tony_compurter.Models
{
    public class Bhdn
    {
        [Key]
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
    }
}