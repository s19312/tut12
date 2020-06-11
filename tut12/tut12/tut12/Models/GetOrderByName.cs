using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public class GetOrderByName
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }

        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }

        public string ConfectioneryName { get; set; }
        public string ConfectioneryType { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }

        public string OrderNotes { get; set; }
    }
}
