using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    public class SearchFlight
    {
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool OneWayTrip { get; set; }
        public bool RoundTrip { get; set; }
    }
}
