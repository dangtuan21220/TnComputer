using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tony_compurter.Models;
using tony_compurter.Areas.Admin.Class;
using PagedList;
using System.Data; //su dung doi tg dataTable
using System.Data.SqlClient; //su dung doi tg connection
//doc cac tham so tu file Web.Config
using System.Configuration;

namespace tony_compurter.Areas.Admin.Controllers
{
    //kiem tra dang nhap
    [CheckLogin]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read(int? page)
        {
            //khai bao so ban ghi tren 1 trang
            int pageSize = 5;
            //so trang
            int pageNumber = page ?? 1; //neu page=null thi page=1, sau do gan cho pageNumber
            //linq truyen thong
            //List<User> listRecord = (from anhxa in db.Categories orderby anhxa.id descending select anhxa).ToList();
            //--
            //su dung ADO
            //lay chuoi ket noi tu file config
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            //tao ket noi csdl
            SqlConnection conn = new SqlConnection(connectionString);
            //tao dtg cmd thuc hien truy van
            SqlCommand cmd = new SqlCommand("select * from Categories where parent_id = 0 order by id desc", conn);
            //tao dtg DataTable de chuan bi nhan du lieu
            DataTable dt = new DataTable();
            //tao dtg DataAdapter de fill du lieu vao datatable
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //--
            //khoi tao dtg Categories
            List<Category> listRecord = new List<Category>();
            //duyet cac phan tu cua datatbale, gan vao datalist
            foreach (DataRow item in dt.Rows)
            {
                Category record = new Category();
                record.id = Convert.ToInt32(item["id"]);
                record.parent_id = Convert.ToInt32(item["parent_id"]);
                record.name = item["name"].ToString();
                listRecord.Add(record);
            }
            //--
            return View("Read", listRecord.ToPagedList(pageNumber, pageSize));
        }
        //update-Get
        public ActionResult Update(int id)
        {
            int _id = id;
            //--
            //lay ra ban ghi tg ung vs danh muc truyen vao
            //lay chuoi ket noi tu fike Web.Config
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from Categories where id =@id", conn);
                cmd.Parameters.AddWithValue("@id", _id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //--
                DataRow dr = dt.NewRow();
                if (dt.Rows.Count > 0)
                    dr = dt.Rows[0];
                return View("Update", dr);
            }
            //--

        }
        //update-post
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(FormCollection fc, int id)
        {
            int _id = id;
            string _name = Request.Form["name"];
            string _parent_id = Request.Form["Parent_id"];
            //--
            //lay ra ban ghi tg ung vs danh muc truyen vao
            //lay chuoi ket noi tu fike Web.Config
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("update Categories set name =@name, parent_id=@parent_id where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.Parameters.AddWithValue("@name", _name);
                cmd.Parameters.AddWithValue("@parent_id", _parent_id);
                //mo lech ket noi 
                conn.Open();
                //thuc thi lech sql
                cmd.ExecuteNonQuery();
            }
            //--
            //di chuyen den url
            return RedirectToAction("Read", "Categories");
        }
        //Create-get
        public ActionResult Create()
        {
            return View("Create");
        }
        //Create-post
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string _name = Request.Form["name"];
            string _parent_id = Request.Form["Parent_id"];
            //--
            //lay ra ban ghi tg ung vs danh muc truyen vao
            //lay chuoi ket noi tu fike Web.Config
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into Categories(name,parent_id) values(@name,@parent_id) ", conn);
                cmd.Parameters.AddWithValue("@name", _name);
                cmd.Parameters.AddWithValue("@parent_id", _parent_id);
                //mo lech ket noi 
                conn.Open();
                //thuc thi lech sql
                cmd.ExecuteNonQuery();
            }
            //--
            //di chuyen den url
            return RedirectToAction("Read", "Categories");
        }
        //delete
        public ActionResult Delete(int id)
        {
            int _id = id;
            //--
            //lay ra ban ghi tg ung vs danh muc truyen vao
            //lay chuoi ket noi tu fike Web.Config
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("delete from Categories where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", _id);
                //mo lech ket noi 
                conn.Open();
                //thuc thi lech sql
                cmd.ExecuteNonQuery();
            }
            //--
            //di chuyen den url
            return RedirectToAction("Read", "Categories");
        }
    }
}