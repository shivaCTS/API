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
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository repository;
       public FlightController(IFlightRepository repository)
        {
            this.repository = repository;
        }

            [HttpPost]
            public IActionResult Add([FromBody] Flight airline)
            {
                string message = string.Empty;
                try
                {
                    message = repository.Add(airline);
                    if (message != null)
                        return Ok(message);
                }
                catch (Exception)
                {

                }
                 return StatusCode(200, message);
        }

        [HttpPost]
        public IActionResult SearchFlight([FromBody] SearchFlight search)
        {
            string message = string.Empty;
            try
            {
                var item = repository.SeachFilght(search);
                if (item != null)
                    return Ok(item);
            }
            catch (Exception)
            {

            }
            return Ok(message);
        }
        [HttpGet]
        public IActionResult List()
        {
            string message = string.Empty;
            try
            {
                var item = repository.list();
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
