using FlightBooking.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
   public interface IAirlineRepository
    {
        string Add(AirlineDto airline);
        string BlockedAirline(string id);
        IEnumerable<Airline> list();
        IEnumerable<Airline> ddlAirline();
    }
}
