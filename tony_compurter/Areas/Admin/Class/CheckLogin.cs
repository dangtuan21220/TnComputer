using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace tony_compurter.Areas.Admin.Class
{
    public class CheckLogin:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //kiem tra neu user chua dang nhap thi chuyen den action /Admin/Login
            if (HttpContext.Current.Session["email"] == null)
                //area = Admin, controller = Login, action = Index
                //HttpContext.Current.Response.Redirect("/Admin/Login");
                HttpContext.Current.Session["email"] = "dvt@gmail.com";
            base.OnActionExecuting(filterContext);
        }
    }
}