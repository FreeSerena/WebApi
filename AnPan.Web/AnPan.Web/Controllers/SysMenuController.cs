using AnPan.Entity.CustomModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnPan.Base;
using AnPan.Web.Models;

namespace AnPan.Web.Controllers
{
    public class SysMenuController : Controller
    {
        public ActionResult SysMenu()
        {
            ModelSysRight model = new ModelSysRight();
            model.RetriveData();
            return View(model);
        }
    }
}
