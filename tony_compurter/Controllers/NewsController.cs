using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using tony_compurter.Models;
using tony_compurter.Areas.Admin.Class;

namespace tony_compurter.Controllers
{
    public class NewsController : Controller
    {
        public DataContext db = new DataContext();
        // GET: News
        public ActionResult Index(int? page)
        {
            //khai bao so ban ghi tren mot trang
            int pageSize = 10;
            //so trang
            int pageNumber = page ?? 1; //neu page = null thi page = 1, sau do gan cho pageNumber
            //linq truyen thong
            //List<User> listRecord = (from anhxa in db.Users orderby anhxa.id descending select anhxa).ToList();
            //bieu thuc lamda
            List<News> listRecord = db.News.OrderByDescending(anhxa => anhxa.id).ToList();
            return View("Index", listRecord.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int id)
        {
            //lay mot ban ghi
            News record = db.News.Where(tbl => tbl.id == id).FirstOrDefault();
            return View("Detail", record);
        }
    }
}