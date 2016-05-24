using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnPan.Web.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AnPan.Entity;
using AnPan.Entity.CustomModel;
using AnPan.Base;

namespace AnPan.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ModelAccount model, FormCollection collection)
        {
            string result = ApiHelper<int>.Post( "Account/Login", JsonConvert.SerializeObject(model.User));
            if (String.IsNullOrEmpty(result))
            {
                SessionManager.CurrentUser.USERID = 1;
                SessionManager.GridSource = ApiHelper<RightModel>.GetModel(String.Format("SysMenu/GetSysMenu?userID={0}", SessionManager.CurrentUser.USERID));
                return Redirect("/Home/Index");
            }
            else
                return Content("");
        }

        public ActionResult LogOff()
        {
            return View();
        }

    }
}
