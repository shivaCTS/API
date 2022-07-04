using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    [Table("CouponMst")]
    public class PromoCode
    {
       
       
            [Key]
            [MaxLength(50)]
            public string Id { get; set; }
            [Required]
            [MaxLength(150)]
            public string Code { get; set; }
            [Required]
            public decimal Value { get; set; }
           
        }
    [Table("TicketCouponTrans")]
    public class TicketCoupon
    {


        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Code { get; set; }
        [Required]
        public decimal Value { get; set; }

        public int PNRNumber { get; set; }

    }
}
