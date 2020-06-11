using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class NewOrderInfo
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        public ConfectioneryInfo Confectionery  { get; set; }
    }
}
