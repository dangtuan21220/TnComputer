using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tony_compurter.Areas.Admin.Class;
using tony_compurter.Models;
using System.Web.Helpers;

namespace tony_compurter.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        //khi nhan nut submit
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc)
        {
            //ham Trim() dung de cat khoang trang trc va sau chuoi
            //lay gtri cua form theo dtg Request
            string _email = Request.Form["email"];
            //lay gtri cua form theo dtg FormCollection
            string _password = fc["password"].Trim();
            //ma hoa password
            _password = Crypto.SHA256(_password);
            //--
            //lay gia tri ban ghi
            //su truy van linq
            //User record = (from anhxa in db.Users where anhxa.email == _email select anhxa).FirstOrDefault();
            //su dung bieu thu lamda
            //FirstOrDefault() lay 1 ban ghi
            User record = db.Users.Where(tbl => tbl.email == _email).FirstOrDefault();
            if (record != null && record.password == _password)
            {
                //khoi tao session
                this.Session["email"] = _email;
                //di chuyen den url: /Admin/Home
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Dang xuat
        public ActionResult Logout()
        {
            this.Session["email"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}