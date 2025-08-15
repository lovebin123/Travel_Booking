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
        public DbSet<FlightEnitity> Flights { get; set; }
        public DbSet<FlightBookingEntity>FlightBookings { get; set; }
        public  DbSet<HotelEntity>hotels { get; set; }
        public DbSet<HotelBookingEnitity>HotelBookings { get; set; }
        public  DbSet<HotelPaymentEntity>HotelPayments { get; set; }
        public DbSet<FlightPayementEntity> flightPayements { get; set; }
        public DbSet<CarRentalEntity>CarRentals { get; set; }
        public DbSet<CarRentalBookingEntity>CarRentalBookings { get; set; }
        public DbSet<CarRentalPaymentEntity>CarRentalPayments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FlightEnitity>().HasKey(i => i.id);
            modelBuilder.Entity<FlightEnitity>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightBookingEntity>().HasKey(i => i.id);
            modelBuilder.Entity<FlightPayementEntity>().HasKey(fp => fp.id);
            modelBuilder.Entity<FlightBookingEntity>().Property(i => i.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightPayementEntity>().Property(i => i.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FlightBookingEntity>().HasOne(u => u.AppUser).WithMany(p => p.FlightBookings).HasForeignKey(p => p.user_id);
            modelBuilder.Entity<FlightBookingEntity>().HasOne(s => s.Flight).WithMany(p => p.FlightBookings).HasForeignKey(p => p.flight_id);
            modelBuilder.Entity<FlightPayementEntity>().HasOne(b => b.flightBooking).WithMany(f => f.flightPayements).HasForeignKey(i => i.FlightBookingId);
            modelBuilder.Entity<FlightBookingEntity>().HasIndex(fb => new { fb.flight_id, fb.user_id }).IsUnique();

            modelBuilder.Entity<HotelBookingEnitity>().HasKey(x => x.id);
            modelBuilder.Entity<HotelBookingEnitity>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelBookingEnitity>().HasOne(x => x.hotel).WithMany(x => x.hotelBookings).HasForeignKey(x => x.hotel_id);
            modelBuilder.Entity<HotelBookingEnitity>().HasOne(x => x.user).WithMany(x => x.HotelBookings).HasForeignKey(x => x.user_id);
            modelBuilder.Entity<HotelBookingEnitity>().HasIndex(x => new { x.hotel_id, x.user_id }).IsUnique();

            modelBuilder.Entity<HotelPaymentEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<HotelPaymentEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelPaymentEntity>().HasOne(x => x.hotelBooking).WithMany(x => x.hotelPayments).HasForeignKey(x => x.bookingId);

            modelBuilder.Entity<CarRentalBookingEntity>().HasKey(x => x.id);
            modelBuilder.Entity<CarRentalBookingEntity>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CarRentalBookingEntity>().HasOne(x => x.user).WithMany(x => x.CarRentalBookings).HasForeignKey(x => x.user_id);
            modelBuilder.Entity<CarRentalBookingEntity>().HasOne(x => x.carRental).WithMany(x => x.CarRentalBookings).HasForeignKey(x => x.bookingId);
            modelBuilder.Entity<CarRentalBookingEntity>().HasIndex(x => new { x.bookingId, x.user_id }).IsUnique();

            modelBuilder.Entity<CarRentalPaymentEntity>().HasKey(x => x.id);
            modelBuilder.Entity<CarRentalPaymentEntity>().HasOne(x => x.carRentalBooking).WithMany(x => x.CarRentalPayments).HasForeignKey(x => x.bookingId);
            modelBuilder.Entity<CarRentalPaymentEntity>().Property(x => x.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<AppUser>().HasIndex(x => x.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique(false);
            modelBuilder.Entity<CarRentalEntity>().HasKey(x => x.id);
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
