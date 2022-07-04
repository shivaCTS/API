using FlightBooking.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
   public interface IPromoCodeRepository
    {
        string Add(PromoCode airline);
        IEnumerable<PromoCode> list();
        string Delete(string id);
    }
}
