using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AnPan.Entity;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AnPan.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public string Login(UT_SYS_USER model)
        {
            using (CustomsEntities db = new CustomsEntities())
            {
                var user = db.UT_SYS_USER.FirstOrDefault(p => p.ACCOUNT == model.ACCOUNT && p.ISDELETED == "0");
                if (user == null)
                {
                    return "用户名不存在！";
                }
                return String.Empty;
            }
            //DataClassesDataContext db = new DataClassesDataContext();
            
            //using (DataClassesDataContext db = new DataClassesDataContext())
            //{
            //    //UT_SYS_USER user = (from c in db.UT_SYS_USERs
            //    //            where c.ACCOUNT == userName
            //    //            select c).SingleOrDefault();

            //    //if (user == null)
            //    //{
            //    //    return "";
            //    //}

            //    //if (user.PASSWORD != userPwd)
            //    //{
            //    //    return "";
            //    //}

            //    
            //}
        }
    }
}
