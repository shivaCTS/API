using FlightBooking.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Repository
{
    public interface IBookingRepository
    {
        string BookingTicket(BookingTicketDtos ticket);
       dynamic PNRStatus(int pnrNo);
        IEnumerable<dynamic> TicketHistory(TicketDto ticket);
        string CancelTicket(int pnrNo);
    }
}
