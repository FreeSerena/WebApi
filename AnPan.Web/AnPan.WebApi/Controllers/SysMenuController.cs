using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnPan.Entity;
using Newtonsoft.Json;
using AnPan.Entity.CustomModel;

namespace AnPan.WebApi.Controllers
{
    public class SysMenuController : ApiController
    {
        public string GetSysMenu(int userID)
        {
            using (CustomsEntities db = new CustomsEntities())
            {
                var query = from A in db.UT_SYS_USERROLE
                            join B in db.UT_SYS_ROLERIGHT
                            on A.ROLEID equals B.RoleID
                            join C in db.UT_SYS_RIGHT
                            on B.SystemRightID equals C.RIGHTID
                            join D in db.UT_SYS_RIGHT
                            on C.PARENTRIGHTID equals D.RIGHTID
                            where A.USERID == userID && C.TYPE != 2
                            select new SysRight 
                            {
                                ParentID = C.PARENTRIGHTID,
                                Name = C.RIGHTNAME,
                                NavUrl = C.NAVIGATEURL,
                                SystemID = C.RIGHTID,
                                ImageUrl = C.IMAGEURL,
                                ParentName = D.RIGHTNAME,
                            };

                //return JsonConvert.SerializeObject(query.ToList());
                var firstMenu = query.Where(q=>q.ParentID!=0).GroupBy(p =>new  {p.ParentID,p.ParentName}).Select(q => new {q.Key});

                List<RightModel> result = new List<RightModel>();

                var parentList = db.UT_SYS_RIGHT.Where(p => p.PARENTRIGHTID == 0).ToList();

                firstMenu.ToList().ForEach(p =>
                {
                    result.Add(new RightModel
                    {
                        ParentID = p.Key.ParentID,
                        Name = p.Key.ParentName,
                        ImageUrl = parentList.FirstOrDefault(q=>q.RIGHTID == p.Key.ParentID).IMAGEURL,
                        ChildList = query.Where(q => q.ParentID == p.Key.ParentID).ToList()
                    });
                });
                return  JsonConvert.SerializeObject(result);
            }

            
        }
    }
}
