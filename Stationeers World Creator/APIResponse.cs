using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stationeers_World_Creator
{
    public class XVersion
    {
        public string currentVersion { get; set; }
    }

    public class APIResponse
    {
        public string state { get; set; }
        public int count { get; set; }
        //public List<WorldsDEPRACTED> data { get; set; }
        public List<XVersion> data { get; set; }
    }
}
