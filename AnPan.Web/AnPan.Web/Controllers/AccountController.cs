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
            string result = ApiHelper.Post(ApiHelper.ApiUrl + "Account/Login", JsonConvert.SerializeObject(model.User));
            if (String.IsNullOrEmpty(result))
                return Redirect("/Home/Index");
            else
                return Content("");
        }

    }
}
