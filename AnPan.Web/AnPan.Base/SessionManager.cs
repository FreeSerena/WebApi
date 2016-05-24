using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnPan.Entity;
using AnPan.Entity.CustomModel;

namespace AnPan.Base
{
    public class SessionManager
    {
        public const string SYS_USER_COOKIE_KEY = "SYS_USER_COOKIE_KEY";
        public const string SYS_USER_ACCOUNT_SESSION_KEY = "SYS_USER_ACCOUNT_SESSION_KEY";
        public const string SYS_USER_SESSION_KEY = "SYS_USER_SESSION_KEY";
        public const string SYS_USER_ROLES_SESSION_KEY = "SYS_USER_ROLES_SESSION_KEY";
        public const string SYS_USER_RIGHT_DATA_SESSION_KEY = "SYS_USER_RIGHT_DATA_SESSION_KEY";

        public static UT_SYS_USER CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[SYS_USER_ACCOUNT_SESSION_KEY] != null)
                    return HttpContext.Current.Session[SYS_USER_ACCOUNT_SESSION_KEY] as UT_SYS_USER;

                HttpCookie cookie = HttpContext.Current.Request.Cookies[SYS_USER_COOKIE_KEY];
                if (cookie != null &&
                    cookie[SYS_USER_COOKIE_KEY] != null &&
                    cookie[SYS_USER_COOKIE_KEY].ToString() != string.Empty)
                {
                    string cookieValue = cookie[SYS_USER_COOKIE_KEY].ToString();

                    using (CustomsEntities db = new CustomsEntities())
                    {
                        HttpContext.Current.Session[SYS_USER_ACCOUNT_SESSION_KEY] = db.UT_SYS_USER.FirstOrDefault(x => x.ACCOUNT.Equals(cookieValue));
                        return HttpContext.Current.Session[SYS_USER_ACCOUNT_SESSION_KEY] as UT_SYS_USER;
                    }

                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[SYS_USER_ACCOUNT_SESSION_KEY] = value;
            }
        }

        public static IList<RightModel> GridSource
        {
            get;
            set;
        }
    }
}