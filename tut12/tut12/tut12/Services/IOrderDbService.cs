using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Services
{
    public interface IOrderDbService
    {
        public List<GetOrderByName> GetOrder(string name);
        public void AddOrder(int idCustomer,NewOrderInfo orderInfo);
    }
}
