using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace tony_compurter.Models
{
    public class Mailing
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
    }
}