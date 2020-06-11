using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class SqlServerOrderDbService : ControllerBase, IOrderDbService
    {
        public IActionResult GetOrder(string name)
        {
            return Ok("Hello");
        }
    }
}
