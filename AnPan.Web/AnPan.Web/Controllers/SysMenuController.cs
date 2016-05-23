using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnPan.Web.Controllers
{
    public class SysMenuController : Controller
    {
        public ActionResult SysMenu()
        {
            string re = ApiHelper.Get(ApiHelper.ApiUrl + "SysMenu/GetSysMenu?userID=1");
            return View();
        }
    }
}
