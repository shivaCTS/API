using FlightBooking.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
  public  interface IScheduleRepository
    {
        string Add(Inventory inventory);
        Inventory GetDetailsById(string id);
    }
}
