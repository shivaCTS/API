using FlightBooking.Admin.Models;
using FlightBooking.Admin.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class PromoCodeController : ControllerBase
    {
        private readonly IPromoCodeRepository repository;
        public PromoCodeController(IPromoCodeRepository repository)
        {
            this.repository = repository;
        }
        // GET: PromoCodeController
     [HttpPost]
     [ActionName("CreateCouponCode")]
        public IActionResult Add(PromoCode promoCode)
        {
            string message = string.Empty;
            try
            {
                message = repository.Add(promoCode);
                if (message != null)
                    return Ok(message);
            }
            catch (Exception)
            {

            }
            return StatusCode(200, message);
        }
        [HttpGet]
        [ActionName("CouponCodeList")]
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
        [ActionName("DeleteCouponCode")]
        public IActionResult List(string id)
        {
            string message = string.Empty;
            try
            {
                var item = repository.Delete(id);
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
