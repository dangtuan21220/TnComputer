using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tony_compurter.Models;
using tony_compurter.Areas.Admin.Class;
//phan trang
using PagedList;
using System.Web.Helpers;

namespace tony_compurter.Areas.Admin.Controllers
{
    //kiem tra dang nhap
    [CheckLogin]
    public class UsersController : Controller
    {
        
        public DataContext db = new DataContext();
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }
        //int? page co nghia la neu page co gtri thi gan no, k thi = null
        public ActionResult Read(int? page)
        {
            //khai bao so ban ghi tren 1 trang
            int pageSize = 5;
            //so trang
            int pageNumber = page ?? 1; //neu page=null thi page=1, sau do gan cho pageNumber
            //linq truyen thong
            //List<User> listRecord = (from anhxa in db.Users orderby anhxa.id descending select anhxa).ToList();
            //bieu thu lamda
            List<User> listRecord = db.Users.OrderByDescending(anhxa => anhxa.id).ToList();
            return View("Read", listRecord.ToPagedList(pageNumber, pageSize));
        }

        //update
        public ActionResult Update(int id)
        {
            int _id = id;
            //lay 1 ban ghi tg ung id truyen vao
            User record = db.Users.Where(tbl => tbl.id == _id).FirstOrDefault();
            //goi view truyen du lieu vao
            return View("Update", record);
        }
        // update - POST
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(FormCollection fc, int id)
        {
            int _id = id;
            // lay du lieu cach 1: su dung dtg Request.Form
            string _name = Request.Form["name"];
            //lay du lieu cach 2: su dung doi tg FormCollection
            string _email = fc["email"];
            string _password = fc["password"];

            //lay 1 ban ghi tg ung vs id truyen vao
            //sdug lamda
            User record = db.Users.Where(tbl => tbl.id == _id).FirstOrDefault();
            //sdug linq truyen thong
            //User record1 = (from anhxa in db.Users where anhxa.id == _id select anhxa).FirstOrDefault();
            //--
            record.name = _name;
            //neu password ko rong thi ma hoa password
            if (!String.IsNullOrEmpty(_password))
                _password = Crypto.SHA256(_password);
            //kiem tra xem email da ton tai chua, neu chua thi update
            User checkRecord = db.Users.Where(tbl => tbl.email == _email && tbl.id != _id).FirstOrDefault();
            if (checkRecord == null)
                record.email = _email;
            db.SaveChanges();
            //--
            //di chuyen den url
            return RedirectToAction("Read", "Users");
        }
        //create - GET
        public ActionResult Create()
        {
            return View("Create");
        }
        //Create - Post
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            // lay du lieu cach 1: su dung dtg Request.Form
            string _name = Request.Form["name"];
            //lay du lieu cach 2: su dung doi tg FormCollection
            string _email = fc["email"];
            string _password = fc["password"];
            //ma hoa password
            _password = Crypto.SHA256(_password);
            //kiem tra neu email chua ton tai trg csdl thi them moi ban ghi
            User checkRecord = db.Users.Where(tbl => tbl.email == _email).FirstOrDefault();
            if (checkRecord == null)
            {
                //khoi tao 1 ban ghi moi
                User record = new User();
                //them du lieu cho ban ghi
                record.email = _email;
                record.name = _name;
                record.password = _password;
                //them ban ghi vao csdl
                db.Users.Add(record);
                //cap nhat thay doi
                db.SaveChanges();
            }
            else
                return RedirectToAction("Create", "Users", new { notify = "emailExists" });
            //new { notify="emailExists" } -> /Admin/Users/Create?notify=emailExists
            //di chuyen den url
            return RedirectToAction("Read", "Users");
        }
        //xoa ban ghi
        public ActionResult Delete(int id)
        {
            int _id = id;
            //lay 1 ban ghi tg vs id truyen vao
            User record = db.Users.Where(tbl => tbl.id == _id).FirstOrDefault();
            //xoa ban ghi vua lay ra
            if (record != null)
            {
                db.Users.Remove(record);
                //cap nhat thay doi
                db.SaveChanges();
            }
            //di chuyen den url
            return RedirectToAction("Read", "Users");
        }
    }
}