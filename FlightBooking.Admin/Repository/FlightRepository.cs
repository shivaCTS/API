using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private FlightDBContext dBContext;
      public  FlightRepository(FlightDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public string Add(Flight airline)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.Flights.Where(x => x.Name.ToLower() == airline.Name.ToLower()).FirstOrDefault();
                if (item == null)
                {
                    Flight itemVal = new Flight()
                    {
                        FlightNumber = Convert.ToString(Guid.NewGuid()),
                       AirlineNunmber = airline.AirlineNunmber,
                        Name = airline.Name,
                        IsBlocked = false,
                        CreatedAt = DateTime.Now

                    };
                    dBContext.Flights.Add(itemVal);
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

        public IEnumerable<dynamic> list()
        {
            var itemList = dBContext.Flights.Select(st=> new Flight {
            Name=st.Name,
            FlightNumber=st.FlightNumber,
            AirlineNunmber= (from c in dBContext.Airlines where(c.Id==st.AirlineNunmber) select c.Name ).FirstOrDefault()
            
            }). ToList();
            return itemList;
        }

        public IEnumerable<dynamic> SeachFilght(SearchFlight model)
        {

            var itemList = dBContext.Inventories.Select(b=>new Inventory
            {
FromPlace=b.FromPlace,
ToPlace=b.ToPlace,
OneTripPrice=b.OneTripPrice,
BussinessSeats=b.BussinessSeats,
NonBussinessSeats=b.NonBussinessSeats,
InstrumentUsed=b.InstrumentUsed,
RoundTripPrice=b.RoundTripPrice,
ScheduledDays=b.ScheduledDays,
Id=b.FlightNumber,
FlightNumber=(from c in dBContext.Flights where(c.FlightNumber == b.FlightNumber) select  c.Name) .FirstOrDefault()
            })
               . Where(x=>(x.FromPlace.ToLower().Contains(model.FromPlace.ToLower()) || model.FromPlace=="") && (x.ToPlace.ToLower().Contains(model.ToPlace.ToLower())|| model.ToPlace=="")).
                ToList();

            return itemList;
        }
    }
}
