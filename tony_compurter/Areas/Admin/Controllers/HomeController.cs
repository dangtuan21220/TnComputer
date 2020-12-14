using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// using folder class de nhin thay cac file ben trg
using tony_compurter.Areas.Admin.Class;

namespace tony_compurter.Areas.Admin.Controllers
{
    //kiem tra dang nhap
    [CheckLogin]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //return RedirectToAction("Read", "Users", new { Area = "Admin" });
            return View();
        }
    }
}