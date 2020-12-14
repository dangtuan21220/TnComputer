using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tony_compurter.Models;
using tony_compurter.Areas.Admin.Class;
namespace tony_compurter.Controllers
{
    public class AdvController : Controller
    {
        public DataContext db = new DataContext();
        // GET: Adv
        public ActionResult Index(int id)
        {
            Adv record = db.Advs.Where(tbl => tbl.id == id).FirstOrDefault();
            return View("Index", record);
        }
    }
}