using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tut12.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public virtual Customer IdCustomerNavigation{ get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
