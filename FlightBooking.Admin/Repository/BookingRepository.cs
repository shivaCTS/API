using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private FlightDBContext dBContext;
        private UserManager<AppUsers> userManager;
        public BookingRepository(FlightDBContext dBContext, UserManager<AppUsers> userManager)
        {
            this.dBContext = dBContext;
            this.userManager = userManager;
        }
        public string BookingTicket(BookingTicketDtos ticket)
        {
            string message = string.Empty;
            try
            {
                //only worked  on Non Business class
                var item = dBContext.Inventories.Where(x => x.FlightNumber == ticket.FlightNumber).FirstOrDefault();
                if (item.NonBussinessSeats > 0)
                {
                    TicketBooking itemVal = new TicketBooking()
                    {
                        // PNRNumber = num,
                        IsCancel = false,
                        BockedSeats = ticket.Passenger.Count(),
                        FlightNumber = ticket.FlightNumber,
                        CreatedAt = DateTime.Now,
                        TotalPrice = ticket.TotalPrice,
                        // Passengers=ticket.Passengers,
                        IsMeals = ticket.IsMeals,
                        CreatedBy = ticket.CreatedBy,

                    };
                    dBContext.FlightTickets.Add(itemVal);
                    int status = dBContext.SaveChanges();
                    if (status == 1)
                    {
                        SavePassenger(ticket.Passenger, itemVal.PNRNumber);
                        SaveCouponWithUser(ticket, itemVal.PNRNumber);
                        if (item != null)
                        {
                            item.NonBussinessSeats = item.NonBussinessSeats-ticket.Passenger.Count();
                            dBContext.Inventories.Update(item);
                            dBContext.SaveChanges();
                          //  message = Constants.DeleteRecord;
                        }
                    }
                    message = Constants.CreateRecord;
                }
                else
                    message = "No seats available";
            }
            catch (Exception ex)
            {
                message = Constants.InternalServerError;
            }
            return message;
        }

        public string CancelTicket(int pnrNo)
        {
            string message = string.Empty;
            try
            {
                var item = dBContext.FlightTickets.Where(x => x.PNRNumber == pnrNo).FirstOrDefault();
                if (item != null)
                {
                    item.IsCancel = true;
                    dBContext.FlightTickets.Update(item);
               int status= dBContext.SaveChanges();
                    if (status == 1)
                    {
                        var itemVal = dBContext.Inventories.Where(x => x.FlightNumber == item.FlightNumber).FirstOrDefault();
                        itemVal.NonBussinessSeats = itemVal.NonBussinessSeats - item.BockedSeats;
                        dBContext.Inventories.Update(itemVal);
                        dBContext.SaveChanges();
                    }

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

        public dynamic PNRStatus(int pnrNo)
        {
            Dictionary<string, dynamic> ss = new Dictionary<string, dynamic>();
            try
            {
                var item = dBContext.FlightTickets.Where(x => x.PNRNumber == pnrNo).FirstOrDefault();
                var passenger = dBContext.Passengers.Where(x => x.PNRNumber == pnrNo).ToList();
                var coupon = dBContext.ticketCoupons.Where(x => x.PNRNumber == pnrNo).FirstOrDefault();
                ss.Add("flight", item);
                ss.Add("Passenger", passenger);
                ss.Add("coupon", coupon);
                return ss;
            }
            catch (Exception)
            {
             //Constants.InternalServerError;
            }
            return null;
        }

        public  IEnumerable<dynamic> TicketHistory(TicketDto ticket)
        { 
            try
            {
                var userinfo = userManager.Users.Where(x => x.Id == ticket.userId).FirstOrDefault();
                if (userinfo != null)
                {
                    string userid = userinfo.Id;
                    var list = dBContext.FlightTickets. Where(x => (x.CreatedBy == userid) && (x.PNRNumber==ticket.pnrNumber || ticket.pnrNumber==0)).ToList();
                    return list;
                }
               
            }
            catch (Exception ex)
            {
              //  message = Constants.InternalServerError;
            }
            return null;
        }


       private void SavePassenger(List<PassengerDto> passengerDto, int pnrNumber)
        {


            foreach(var item in passengerDto)
            {
                PassengerDetails itemVal = new PassengerDetails()
                {
                    Id = Convert.ToString(Guid.NewGuid()),
                    PNRNumber = pnrNumber,
                    Name = item.Name,
                    SeatNo = item.SeatNo,
                    Age = item.Age,
                    Meals = item.Meals,
                    Gender=item.Gender,
                     CreatedAt=DateTime.Now
                };
                dBContext.Passengers.Add(itemVal);
            }
        }
        private void SaveCouponWithUser(BookingTicketDtos ticketDtos, int pnrNumber)
        {

            var item = dBContext.ticketCoupons.Where(x => x.PNRNumber == pnrNumber).FirstOrDefault();
            if (item == null)
            {
                var Val = new TicketCoupon()
                {
                    Id = Convert.ToString(Guid.NewGuid()),
                    Value=ticketDtos.discount,
                    Code=ticketDtos.couponCode,
                    PNRNumber=pnrNumber

                };
                dBContext.ticketCoupons.Add(Val);
                dBContext.SaveChanges();
            }
        }
    }
}
