using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public class ScheduledRepository : IScheduleRepository
    {
        private FlightDBContext dBContext;
      public  ScheduledRepository(FlightDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public string Add(Inventory inventory)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.Inventories.Where(x => x.FlightNumber.ToLower() == inventory.FlightNumber.ToLower()).FirstOrDefault();
                if (item == null)
                {
                    Inventory itemVal = new Inventory()
                    {
                        Id = Convert.ToString(Guid.NewGuid()),
                        FlightNumber = inventory.FlightNumber,
                        ScheduledDays = inventory.ScheduledDays,
                        FromPlace = inventory.FromPlace,
                        ToPlace=inventory.ToPlace,
                        StartDateTime=inventory.StartDateTime,
                        EndDateTime=inventory.EndDateTime,
                        BussinessSeats=inventory.BussinessSeats,
                        NonBussinessSeats=inventory.NonBussinessSeats,
                        InstrumentUsed=inventory.InstrumentUsed,
                        Meals=inventory.Meals,
                        RowCounts=inventory.RowCounts,
                        OneTripPrice=inventory.OneTripPrice,
                        RoundTripPrice=inventory.RoundTripPrice,
                        CreatedBy=inventory.CreatedBy,
                        CreatedAt = DateTime.Now

                    };
                    dBContext.Inventories.Add(itemVal);
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

        public Inventory GetDetailsById(string id)
        {
            var item = dBContext.Inventories.Where(x => x.FlightNumber == id).FirstOrDefault();
            return item;
        }
    }
}

