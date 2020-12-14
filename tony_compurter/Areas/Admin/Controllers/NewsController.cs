using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tony_compurter.Models;
using tony_compurter.Areas.Admin.Class;
//phan trang
using PagedList;
//thao tac voi file
using System.IO;

namespace tony_compurter.Areas.Admin.Controllers
{
    //kiem tra dang nhap
    [CheckLogin]
    public class NewsController : Controller
    {
        public DataContext db = new DataContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            return RedirectToAction("Read");
        }
        //int? page co nghia la neu page co gia tri thi gan cho no, khong thi se gan la null
        public ActionResult Read(int? page)
        {
            //khai bao so ban ghi tren mot trang
            int pageSize = 4;
            //so trang
            int pageNumber = page ?? 1; //neu page = null thi page = 1, sau do gan cho pageNumber
            //linq truyen thong
            //List<User> listRecord = (from anhxa in db.Users orderby anhxa.id descending select anhxa).ToList();
            //bieu thuc lamda
            List<News> listRecord = db.News.OrderByDescending(anhxa => anhxa.id).ToList();
            return View("Read", listRecord.ToPagedList(pageNumber, pageSize));
        }
        //update - GET
        public ActionResult Update(int id)
        {
            int _id = id;
            //lay mot ban ghi tuong ung voi id truyen vao
            News record = db.News.Where(tbl => tbl.id == _id).FirstOrDefault();
            //goi view, truyen du lieu ra view
            return View("Update", record);
        }
        //update - POST
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Update(FormCollection fc, int id)
        {
            string _name = Request.Form["name"].Trim();
            //do descript co ky tu html trong do, vi vay phai dung fc["ten form control"]
            string _descrition = fc["description"].Trim();
            string _content = fc["content"].Trim();
            int _hot = Request.Form["hot"] != null ? 1 : 0;
            //lay ban ghi de update
            News record = db.News.Where(tbl => tbl.id == id).FirstOrDefault();
            record.name = _name;
            record.description = _descrition;
            record.content = _content;
            record.hot = _hot;
            //neu user chon an thi thuc hien upload an
            //Request.Files["photo"] -> su dung cho the file
            if (Request.Files["photo"].ContentLength > 0)
            {
                //lay anh cu vao xoa
                //kiem tra xem file co ton tai khong, neu ton tai thi xoa file
                string pathDeleted = Path.Combine(Server.MapPath("~/Assets/Upload/News"), record.photo);
                if (System.IO.File.Exists(pathDeleted))
                    System.IO.File.Delete(pathDeleted);
                //---
                //thuc hien upload file
                string path = Path.Combine(Server.MapPath("~/Assets/Upload/News"), Path.GetFileName(id + "_" + Request.Files["photo"].FileName));
                Request.Files["photo"].SaveAs(path);
                record.photo = id + "_" + Request.Files["photo"].FileName;
            }
            //---
            db.SaveChanges();
            //---
            return RedirectToAction("Read", "News");
        }
        //create - GET
        public ActionResult Create()
        {
            //goi view
            return View("Create");
        }
        //update - POST
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create(FormCollection fc)
        {
            string _name = Request.Form["name"].Trim();
            //do descript co ky tu html trong do, vi vay phai dung fc["ten form control"]
            string _descrition = fc["description"].Trim();
            string _content = fc["content"].Trim();
            int _hot = Request.Form["hot"] != null ? 1 : 0;
            //lay ban ghi de update
            News record = new News();
            record.name = _name;
            record.description = _descrition;
            record.content = _content;
            record.hot = _hot;
            //neu user chon an thi thuc hien upload an
            //Request.Files["photo"] -> su dung cho the file
            if (Request.Files["photo"].ContentLength > 0)
            {
                //thuc hien upload file
                string path = Path.Combine(Server.MapPath("~/Assets/Upload/News"), Path.GetFileName(Request.Files["photo"].FileName));
                Request.Files["photo"].SaveAs(path);
                record.photo = Request.Files["photo"].FileName;
            }
            //---
            db.News.Add(record);
            db.SaveChanges();
            //---
            return RedirectToAction("Read", "News");
        }
        //delete
        public ActionResult Delete(int id)
        {
            //lay ban ghi de xoa
            News record = db.News.Where(tbl => tbl.id == id).FirstOrDefault();
            //kiem tra xem file co ton tai khong, neu ton tai thi xoa file
            string path = Path.Combine(Server.MapPath("~/Assets/Upload/News"), record.photo);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            //---
            db.News.Remove(record);
            db.SaveChanges();
            //---
            return RedirectToAction("Read", "News");
        }
    }
}