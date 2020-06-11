using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Exceptions;
using tut12.Models;

namespace tut12.Services
{
    public class SqlServerOrderDbService : ControllerBase, IOrderDbService
    {
        List<GetOrderByName> result = new List<GetOrderByName>();
        private int idCustomer = 0;
        private readonly OrderDbContext _context;
        

        public SqlServerOrderDbService(OrderDbContext context) {
            _context = context;
        }
        public List<GetOrderByName> GetOrder(string name)
        {
            //var confectioneriesList = new List<Confectionery>();
            
            //if (name != null)
            //{
            //    idCustomer = _context.Customer.Where(c => c.Name == name).Select(c => c.IdCustomer).FirstOrDefault();
            //    if (idCustomer == 0)
            //    {
            //        throw new CustomerNotFoundException();
            //    }
                
            //    var list = _context.Confectionery_Order
            //    .Join(_context.Order, co => co.IdOrder, o => o.IdOrder, (co, o) => new { c_order = co, order = o })
            //    .Join(_context.Confectionery, co => co.c_order.IdConfectionery, c => c.IdConfectionery, (co, c) => new { c_order = co, confectionery = c })
            //    .Where(e => e.c_order.order.IdCustomer == idCustomer && e.c_order.c_order.IdOrder == e.c_order.order.IdOrder)          
            //    .ToList();

          
            //    foreach (var res in list)
            //    {
            //        GetOrderByName info = new GetOrderByName();
            //        info.IdOrder = res.c_order.c_order.IdOrder;
            //        info.IdCustomer = res.c_order.order.IdCustomer;
            //        info.DateAccepted = res.c_order.order.DateAccepted;
            //        info.DateFinished = res.c_order.order.DateFinished;
            //        info.ConfectioneryName = res.confectionery.Name;
            //        info.ConfectioneryType = res.confectionery.Type;
            //        info.PricePerItem = res.confectionery.PricePerItem;
            //        info.Quantity = res.c_order.c_order.Quantity;
            //        info.OrderNotes = res.c_order.order.Notes;
            //        result.Add(info);
            //    }
            //}
            //else {
                
            //    var list = _context.Confectionery_Order
            //    .Join(_context.Order, co => co.IdOrder, o => o.IdOrder, (co, o) => new { c_order = co, order = o })
            //    .Join(_context.Confectionery, co => co.c_order.IdConfectionery, c => c.IdConfectionery, (co, c) => new { c_order = co, confectionery = c })
            //    .ToList();

            //    foreach (var res in list)
            //    {
            //        GetOrderByName info = new GetOrderByName();
            //        info.IdOrder = res.c_order.c_order.IdOrder;
            //        info.IdCustomer = res.c_order.order.IdCustomer;
            //        info.DateAccepted = res.c_order.order.DateAccepted;
            //        info.DateFinished = res.c_order.order.DateFinished;
            //        info.ConfectioneryName = res.confectionery.Name;
            //        info.ConfectioneryType = res.confectionery.Type;
            //        info.PricePerItem = res.confectionery.PricePerItem;
            //        info.Quantity = res.c_order.c_order.Quantity;
            //        info.OrderNotes = res.c_order.order.Notes;
            //        result.Add(info);
            //    }            
            //}
            return result;
        }

        public void AddOrder(int idCustomer, NewOrderInfo orderInfo)
        {
            int idConfectionery = _context.Confectionery.Where(c => c.Name == orderInfo.Confectionery.Name)
                                                        .Select(c => c.IdConfectionery)
                                                        .FirstOrDefault();
            if (idConfectionery == 0)
            {
                throw new ConfectioneryNameNotFoundException();
            }

            if (!_context.Customer.Any(e => e.IdCustomer == idCustomer))
            {
                throw new CustomerNotFoundException();
            }

            Random random = new Random();
     
            Order newOrder = new Order()
            {
                IdOrder = _context.Order.Max(o => o.IdOrder) + 1,
                IdCustomer = idCustomer,
                IdEmployee = random.Next(1, _context.Employee.Max(e => e.IdEmployee)),
                DateAccepted = orderInfo.DateAccepted,
                DateFinished = orderInfo.DateAccepted,
                Notes = orderInfo.Notes,
            };

            Confectionery_Order newConfectionery_Order = new Confectionery_Order()
            {
                IdOrder = newOrder.IdOrder,
                IdConfectionery = idConfectionery,
                Quantity = orderInfo.Confectionery.Quantity,
                Notes = orderInfo.Confectionery.Notes
            };

            _context.Order.Add(newOrder);
            _context.Confectionery_Order.Add(newConfectionery_Order);
            _context.SaveChanges();
        }
    }
}
