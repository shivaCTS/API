using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    [Table("FlightTicketTran")]
    public class TicketBooking
    {
        [Key]
        public int PNRNumber { get; set; }

        [ForeignKey("FlightNumber")]
        public string FlightNumber { get; set; }
        public Flight FlightNo { get; set; }
       [Range(0,int.MinValue,ErrorMessage ="Please enter valid number")]
        public int BockedSeats { get; set; }
        [Required]
        public bool IsMeals { get; set; }
        [Range(0, int.MinValue, ErrorMessage = "Please enter valid number")]
        public decimal TotalPrice { get; set; }
        [Required]
        public bool IsCancel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<PassengerDetails> Passengers { get; set; }
    }
}
