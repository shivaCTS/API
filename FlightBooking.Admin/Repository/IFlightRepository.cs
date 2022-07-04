using FlightBooking.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
   public interface IFlightRepository
    {
        string Add(Flight airline);
        IEnumerable<dynamic> SeachFilght (SearchFlight model);
        IEnumerable<dynamic> list();
    }
}
