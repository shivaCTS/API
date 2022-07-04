using AutoMapper;
using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.User.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityUser> roleManager;
        //private UserManager<IdentityUser> userManager;
        private  FlightDBContext dBContext;
       public AirlineRepository(FlightDBContext dBContext)
        {
           // this.mapper = mapper;
           // this.roleManager = roleManager;
            //this.userManager = userManager;
            this.dBContext = dBContext;
        }
        public  string Add(AirlineDto airline)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.Airlines.Where(x => x.Name.ToLower() == airline.Name.ToLower()).FirstOrDefault();
                if (item == null)
                {
                    Airline itemVal = new Airline()
                    {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Name = airline.Name,
                        logoUrl = airline.logoUrl,
                        Address = airline.Address,
                        Phone = airline.Phone,
                        IsBlocked = false,
                        CreatedAt = DateTime.Now

                    };
                    dBContext.Airlines.Add(itemVal);
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

        public string BlockedAirline(string id)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.Airlines.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    item.IsBlocked = true;
                    dBContext.Airlines.Update(item);
                    dBContext.SaveChanges();
                    message = "Airline blocked successfully";
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

        public IEnumerable<Airline> ddlAirline()
        {
            var item = dBContext.Airlines.Where(x=>x.IsBlocked==false).ToList();
            return item;
        }

        public IEnumerable<Airline> list()
        {
                var item = dBContext.Airlines.ToList();
                return item;
        }
    }
}
