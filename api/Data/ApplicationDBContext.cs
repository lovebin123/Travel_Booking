using System;
using api.Models;
using api.Models.Car_Rental;
using api.Models.Flights;
using api.Models.Hotels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace api.Data
{
    public class ApplicationDBContext:IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightBooking>FlightBookings { get; set; }
        public  DbSet<Hotel>hotels { get; set; }
        public DbSet<HotelBooking>HotelBookings { get; set; }
        public  DbSet<HotelPayment>HotelPayments { get; set; }
        public DbSet<FlightPayement> flightPayements { get; set; }
        public DbSet<CarRental>CarRentals { get; set; }
        public DbSet<CarRentalBooking>CarRentalBookings { get; set; }
        public DbSet<CarRentalPayment>CarRentalPayments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>().HasKey(i => i.id);
            modelBuilder.Entity<Flight>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightBooking>().HasKey(i => i.id);
            modelBuilder.Entity<FlightPayement>().HasKey(fp => fp.id);
            modelBuilder.Entity<FlightBooking>().Property(i => i.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightPayement>().Property(i => i.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightBooking>().HasOne(u => u.AppUser).WithMany(p => p.FlightBookings).HasForeignKey(p => p.user_id);
            modelBuilder.Entity<FlightBooking>().HasOne(s => s.Flight).WithMany(p => p.FlightBookings).HasForeignKey(p => p.flight_id);
            modelBuilder.Entity<FlightPayement>().HasOne(b => b.flightBooking).WithMany(f => f.flightPayements).HasForeignKey(i => i.FlightBookingId);
            modelBuilder.Entity<FlightBooking>().HasIndex(fb => new { fb.flight_id, fb.user_id }).IsUnique();

            modelBuilder.Entity<HotelBooking>().HasKey(x => x.id);
            modelBuilder.Entity<HotelBooking>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelBooking>().HasOne(x => x.hotel).WithMany(x => x.hotelBookings).HasForeignKey(x => x.hotel_id);
            modelBuilder.Entity<HotelBooking>().HasOne(x => x.user).WithMany(x => x.HotelBookings).HasForeignKey(x => x.user_id);
            modelBuilder.Entity<HotelBooking>().HasIndex(x => new { x.hotel_id, x.user_id }).IsUnique();

            modelBuilder.Entity<HotelPayment>().HasKey(x => x.Id);
            modelBuilder.Entity<HotelPayment>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelPayment>().HasOne(x => x.hotelBooking).WithMany(x => x.hotelPayments).HasForeignKey(x => x.bookingId);

            modelBuilder.Entity<CarRentalBooking>().HasKey(x => x.id);
            modelBuilder.Entity<CarRentalBooking>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CarRentalBooking>().HasOne(x => x.user).WithMany(x => x.CarRentalBookings).HasForeignKey(x => x.user_id);
            modelBuilder.Entity<CarRentalBooking>().HasOne(x => x.carRental).WithMany(x => x.CarRentalBookings).HasForeignKey(x => x.bookingId);
            modelBuilder.Entity<CarRentalBooking>().HasIndex(x => new { x.bookingId, x.user_id }).IsUnique();

            modelBuilder.Entity<CarRentalPayment>().HasKey(x => x.id);
            modelBuilder.Entity<CarRentalPayment>().HasOne(x => x.carRentalBooking).WithMany(x => x.CarRentalPayments).HasForeignKey(x => x.bookingId);
            modelBuilder.Entity<CarRentalPayment>().Property(x => x.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CarRental>().HasKey(x => x.id);
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole{
                    Name="User",
                    NormalizedName="USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
