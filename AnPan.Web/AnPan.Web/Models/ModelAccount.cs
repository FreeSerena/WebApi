using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnPan.Entity;

namespace AnPan.Web.Models
{
    public class ModelAccount
    {
        public UT_SYS_USER User { get; set; }
        public bool IsChecked { get; set; }
    }
}