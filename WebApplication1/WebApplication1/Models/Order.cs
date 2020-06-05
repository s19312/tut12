using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }

        [ForeignKey("idCustomer")]
        public int IdClient { get; set; }

        [ForeignKey("idEmployee")]
        public int IdEmployee { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
