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
            var user = ApiHelper<UT_SYS_USER>.GetEntity(String.Format("Account/Login?account={0}", model.User.ACCOUNT));

            if (user == null)
                return Content("");
            SessionManager.CurrentUser = user;
            SessionManager.GridSource = ApiHelper<RightModel>.GetModel(String.Format("SysMenu/GetSysMenu?userID={0}", Convert.ToInt32(SessionManager.CurrentUser.USERID)));
            return Redirect("/Home/Index");
        }

        public ActionResult LogOff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnjularPostData()
        {
            return Json(ApiHelper<RightModel>.GetModel(String.Format("SysMenu/GetSysMenu?userID={0}", Convert.ToInt32(SessionManager.CurrentUser.USERID))));
        }

    }
}
