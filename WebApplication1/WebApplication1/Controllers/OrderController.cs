using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDbService _service;
        public OrderController(IOrderDbService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrder(string name) {
            return _service.GetOrder(name);
        }
    }
}
