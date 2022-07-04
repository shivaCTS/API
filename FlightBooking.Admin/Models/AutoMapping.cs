using AutoMapper;
using FlightBooking.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Models
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Airline, AirlineDto>();
            CreateMap<PassengerDetails, PassengerDto>();
        }
    }
}
