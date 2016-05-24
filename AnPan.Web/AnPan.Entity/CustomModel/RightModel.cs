using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnPan.Entity.CustomModel
{
    [Serializable]
    public class RightModel
    {
        public decimal ParentID { get; set; }
        public string Name { get; set; }
        public List<SysRight> ChildList = new List<SysRight>();
    }
    [Serializable]
    public class SysRight
    {
        public decimal SystemID { get; set; }
        public decimal ParentID { get; set; }
        public string Name { get; set; }
        public string NavUrl { get; set; }
        public string ImageUrl { get; set; }
        public string ParentName { get; set; }
    }

    public class A
    {
        public List<SysRight> result { get; set; }
    }
}
