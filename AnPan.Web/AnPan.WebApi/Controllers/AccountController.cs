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
        [HttpGet]
        public string Login(string account)
        {
            using (CustomsEntities db = new CustomsEntities())
            {
                var user = db.UT_SYS_USER.FirstOrDefault(p => p.ACCOUNT == account && p.ISDELETED == "0");
                return JsonConvert.SerializeObject(user);
            }
        }
    }
}
