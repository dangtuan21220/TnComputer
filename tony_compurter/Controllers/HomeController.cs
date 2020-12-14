using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tony_compurter.Areas.Admin.Class;
using tony_compurter.Models;
using System.Data;
namespace tony_compurter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //nhan email
        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Mailing(FormCollection fc)
        {
            string _email = fc["email"];
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter() { name = "@email", value = _email.ToString() });
            Database.Execute("insert into Mailings(email) values(@email)", parameters);
            return RedirectToAction("Index","Home");
        }

    }
}