using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    public class BookingTicketDtos
    {

        public string FlightNumber { get; set; }
        [Required]
        public bool IsMeals { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public bool IsCancel { get; set; }
        public string CreatedBy { get; set; }

        public string couponCode { get; set; }
        public int discount { get; set; }
        public List<PassengerDto> Passenger { get; set; }

    }

    public class PassengerDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
        public string Meals { get; set; }
        public string CreatedBy { get; set; }
    }
}
