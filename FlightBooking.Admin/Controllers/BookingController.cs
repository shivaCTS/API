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
    public class BookingController : Controller
    {
        private readonly IBookingRepository repository;
        public BookingController(IBookingRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult TicketBooking(BookingTicketDtos ticket)
        {
            string message = string.Empty;
            try
            {
                message = repository.BookingTicket(ticket);
                if (message != null)
                    return Ok(message);
            }
            catch (Exception)
            {

            }
            return Ok(message);
        }
        [HttpGet]
        public IActionResult PNrDetails(int pnrNo)
        {
            string message = string.Empty;
            try
            {
                var item = repository.PNRStatus(pnrNo);
                if (item != null)
                    return Ok(item);
            }
            catch (Exception)
            {

            }
            return Ok(message);
        }
        [HttpGet]
        public IActionResult CancelTicket(int pnrNo)
        {
            string message = string.Empty;
            try
            {
                var item = repository.CancelTicket(pnrNo);
                if (item != null)
                    return Ok(item);
            }
            catch (Exception)
            {

            }
            return Ok(message);
        }

        [HttpPost]
        public IActionResult TicketHistory(TicketDto ticket)
        {
            string message = string.Empty;
            try
            {
                var item = repository.TicketHistory(ticket);
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
