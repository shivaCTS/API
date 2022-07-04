using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private FlightDBContext dBContext;
        public PromoCodeRepository(FlightDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public string Add(PromoCode airline)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.promocodes.Where(x => x.Code.ToLower() == airline.Code.ToLower()).FirstOrDefault();
                if (item == null)
                {
                    PromoCode itemVal = new PromoCode()
                    {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Code = airline.Code,
                        Value = airline.Value,

                    };
                    dBContext.promocodes.Add(itemVal);
                    dBContext.SaveChanges();
                    message = Constants.CreateRecord;
                }
                else
                    message = Constants.AlreadyExist;
            }
            catch (Exception)
            {
                message = Constants.InternalServerError;
            }
            return message;
        }
        public string Delete(string id)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.promocodes.Where(x => x.Id.ToLower() == id.ToLower()).FirstOrDefault();
                if (item != null)
                {
                  
                    dBContext.promocodes.Remove(item);
                    dBContext.SaveChanges();
                    message = Constants.DeleteRecord;
                }
                else
                    message = Constants.NoRecord;
            }
            catch (Exception)
            {
                message = Constants.InternalServerError;
            }
            return message;
        }

        public IEnumerable<PromoCode> list()
        {
            var itemList = dBContext.promocodes.ToList();
            return itemList;
        }
    }
}
