using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Confectionery_Order
    {
        public int IdConfection { get; set; }
        public int Order { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
