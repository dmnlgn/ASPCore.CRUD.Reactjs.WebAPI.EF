namespace ReservationService.Migrations
{
    using ReservationService.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservationService.DAL.DbReservations>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReservationService.DAL.DbReservations context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //IList<Guest> GuestList = new List<Guest>();

            context.Guests.AddOrUpdate(
                Guest => Guest.GuestId,
                new Guest
                {
                    GuestId = 1,
                    Name = "Jacek",
                    Surname = "Wichura",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1995, 5, 3),
                    ZipCode = "21-2500"
                },
                new Guest
                {
                    GuestId = 2,
                    Name = "Elżbieta",
                    Surname = "Sztok",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1991, 5, 3),
                    ZipCode = "12-2500"
                },
                new Guest
                {
                    GuestId = 3,
                    Name = "Karol",
                    Surname = "Pokrzywka",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1891, 5, 3),
                    ZipCode = "21-3700"
                }, 
                new Guest
                {
                    GuestId = 4,
                    Name = "Piotr",
                    Surname = "Fronczewski",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1946, 6, 8),
                    ZipCode = "21-3500"
                },
                new Guest
                {
                    GuestId = 5,
                    Name = "Piotr",
                    Surname = "Rubik",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1968, 9, 3),
                    ZipCode = "22-3500",
                    City = "Wrocław"
                },
                new Guest
                {
                    GuestId = 6,
                    Name = "Piotr",
                    Surname = "Rogucki",
                    Email = "test@test.com",
                    DateOfBirth = new DateTime(1968, 7, 5),
                    ZipCode = "22-3500",
                    City = "Wrocław"
                });
                context.SaveChanges();
            context.Reservations.AddOrUpdate(
               Reservation => Reservation.ReservationId,
                new Reservation
                {
                    ReservationId = 1,
                    ReservationCode = "D251",
                    CreationDate = new DateTime(2000, 7, 5),
                    Price = 1200,
                    CheckInDate = new DateTime(2001, 7, 22),
                    CheckOutDate = new DateTime(2004, 1, 5),
                    Currency = "PLN",
                    Commission = 1.2
                },
                new Reservation
                {
                    ReservationId = 2,
                    ReservationCode = "F281",
                    CreationDate = new DateTime(2004, 7, 5),
                    Price = 1500,
                    CheckInDate = new DateTime(2001, 7, 25),
                    CheckOutDate = new DateTime(2002, 1, 5),
                    Currency = "PLN",
                    Commission = 1.2
                },
                new Reservation
                {
                    ReservationId = 3,
                    ReservationCode = "K211",
                    CreationDate = new DateTime(2006, 2, 12),
                    Price = 1500,
                    CheckInDate = new DateTime(2001, 7, 25),
                    CheckOutDate = new DateTime(2005, 1, 21),
                    Currency = "PLN",
                    Commission = 1.5
                });
            context.SaveChanges();
        }
    }
}
