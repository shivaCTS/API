using FlightBooking.Admin.Models;
using FlightBooking.Admin.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class AirlineController : ControllerBase
    {

        private readonly IAirlineRepository repository;

        public AirlineController(IAirlineRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AirlineDto airline)
        {
            string message = string.Empty;
            try
            {
                message =  repository.Add(airline);
                if (message != null)
                    return StatusCode(200, message);
            }
            catch (Exception)
            {
               
            }
            return StatusCode(200, message);
        }
        [HttpGet]
        public IActionResult BlockedAirline(string id)
        {
            string message = string.Empty;
            try
            {
                message = repository.BlockedAirline(id);
                if (message != null)
                    return Ok(message);
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
        [HttpGet]
        public IActionResult ddlAirline()
        {
            string message = string.Empty;
            try
            {
                var item = repository.ddlAirline();
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
