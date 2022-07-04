using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    [Table("AirlinesMst")]
    public class Airline
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string logoUrl { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        public bool IsBlocked { get; set; }

        public DateTime CreatedAt { get; set; }
        [MaxLength(250)]
        public string CreatedBy { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
    [Table("FlightsMst")]
    public class Flight
    {
        [Key]
        [MaxLength(50)]
        public string FlightNumber { get; set; }

        [ForeignKey("AirlineNunmber")]
        public string AirlineNunmber { get; set; }
        public  Airline AirlineNo { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(250)]
        public string CreatedBy { get; set; }
    }
}
