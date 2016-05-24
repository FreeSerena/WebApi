using AnPan.Base;
using AnPan.Entity.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnPan.Web.Models
{
    public class ModelSysRight
    {
        public IList<RightModel> GridSource { get; set; }

        public void RetriveData()
        {
            GridSource = ApiHelper<RightModel>.GetModel(String.Format("SysMenu/GetSysMenu?userID=1", SessionManager.CurrentUser.USERID));
        }
    }
}