using FlightBooking.Admin.Models;
using FlightBooking.Admin.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class InventoryController : Controller
    {
        private readonly IScheduleRepository repository;
     public   InventoryController(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Inventory inventory)
        {
            string message = string.Empty;
            try
            {
                message = repository.Add(inventory);
                if (message != null)
                    return Ok(message);
            }
            catch (Exception)
            {

            }
            return StatusCode(200,message);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            string message = string.Empty;
            try
            {
                var item = repository.GetDetailsById(id);
                if (item != null)
                    return Ok(item);
            }
            catch (Exception)
            {

            }
            return Ok(message);
        }
    }
}
