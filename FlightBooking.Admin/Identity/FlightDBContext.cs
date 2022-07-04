using FlightBooking.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Admin.Identity
{
    public class FlightDBContext: IdentityDbContext<AppUsers>
    {
        public FlightDBContext()
        {

        }
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CTSDOTNET187\\MSSQLSERVER01;Initial Catalog=FlightDB; Persist Security Info=False; User ID=sa; Password=pass@word1;Trusted_Connection=True;MultipleActiveResultSets=False; Connection Timeout=30;",
            builder => builder.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TicketBooking>().Property(x => x.PNRNumber).UseIdentityColumn(seed: 1237658976, increment: 1);
            base.OnModelCreating(builder);
        }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<TicketBooking> FlightTickets { get; set; }
        public DbSet<PassengerDetails> Passengers { get; set; }
        public DbSet<PromoCode> promocodes { get; set; }

        public DbSet<TicketCoupon> ticketCoupons { get; set; }
    }
}
