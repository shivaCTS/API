using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    [Table("FlightInventoryMst")]
    public class Inventory
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        [ForeignKey("FlightNumber")]
        public string FlightNumber { get; set; }
        public  Flight FlightNo { get; set; }
        [Required]
        [MaxLength(100)]
        public string FromPlace { get; set; }
        [Required]
        [MaxLength(100)]
        public string ToPlace { get; set; }
        [Required]
        public decimal OneTripPrice { get; set; }
        [Required]
        public decimal RoundTripPrice { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
       
        [Required]
        [MaxLength(100)]
        public string ScheduledDays { get; set; }
        [Required]
        [MaxLength(100)]
        public string InstrumentUsed { get; set; }
        [Required]
        public int BussinessSeats { get; set; }
        [Required]
        public int NonBussinessSeats { get; set; }
        [Required]
        public int RowCounts { get; set; }
        [Required]
        public string Meals { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(250)]
        public string CreatedBy { get; set; }

    }
}
