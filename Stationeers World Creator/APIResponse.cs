using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stationeers_World_Creator
{
    internal class APIResponse
    {
        public string state { get; set; }
        public int count { get; set; }
        public List<Worlds> data { get; set; }
    }
}
