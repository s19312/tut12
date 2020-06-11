using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tut12.Exceptions;
using tut12.Models;
using tut12.Services;

namespace tut12.Controllers
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
            List<GetOrderByName> list = new List<GetOrderByName>();
            try {
                list = _service.GetOrder(name);
            }
            catch(CustomerNotFoundException ex) {
                return BadRequest("Such customer does not exists");
            }
            return Ok(list);
        }

        [HttpPost("/api/clients/{id}/orders")]
        public IActionResult AddOrder(int id,NewOrderInfo orderInfo) {
            try
            {
                _service.AddOrder(id, orderInfo);
            }
            catch (CustomerNotFoundException ex)
            {
                return BadRequest("Such customer does not exists");
            }
            catch (ConfectioneryNameNotFoundException ex) {
                return BadRequest("No such confectionery name");
            }
            return Ok("Done");
        }
    }
}
