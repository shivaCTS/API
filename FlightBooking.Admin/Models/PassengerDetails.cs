using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    [Table("PassengerDetails")]
    public class PassengerDetails
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [ForeignKey("PNRNumber")]
        public int PNRNumber { get; set; }
        public TicketBooking PNRNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Gender { get; set; }
        [Range(0, int.MinValue, ErrorMessage = "Please enter valid number")]
        public int Age { get; set; }
        [Required]
        [MaxLength(30)]
        public string SeatNo { get; set; }
        [Required]
        [MaxLength(30)]
        public string Meals { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(250)]
        public string CreatedBy { get; set; }
    }
}
