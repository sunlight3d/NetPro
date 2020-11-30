using BlueYonder.Flights.Database;
using BlueYonder.Flights.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueYonder.Flights.Repository
{
    public class HotelBookingRepository
    {
        private DbContextOptions<MyDbContext> _options;

        public HotelBookingRepository()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer(@"Server=DESKTOP-7PS7HG8\\SQLEXPRESS;Database=Mod1DB;User Id=sa;password=123456;Trusted_Connection=False;MultipleActiveResultSets=true;")
                .Options;
        }
        public HotelBookingRepository(DbContextOptions<MyDbContext> options)
        {
            _options = options;
        }
        public async Task<Booking> Add(int travelerId, int roomId, DateTime checkIn, int guest = 1)
        {
            using (MyDbContext context = new MyDbContext(_options))
            {
                Traveler traveler = context.Travelers.FirstOrDefault(t => t.TravelerId == travelerId);
                Room room = context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
                if (traveler != null && room != null)
                {
                    Booking newBooking = new Booking()
                    {
                        DateCreated = DateTime.Now,
                        CheckIn = checkIn,
                        CheckOut = checkIn.AddDays(1),
                        Guests = guest,
                        Paid = false,
                        Traveler = traveler,
                        Room = room
                    };
                    Booking booking = (await context.Bookings.AddAsync(newBooking))?.Entity;
                    await context.SaveChangesAsync();
                    return booking;
                }
                return null;
            }
        }
        public async Task<Booking> Update(Booking bookingToUpdate)
        {
            using (MyDbContext context = new MyDbContext(_options))
            {
                Booking booking = context.Bookings.Update(bookingToUpdate)?.Entity;
                await context.SaveChangesAsync();
                return booking;
            }
        }
        public async void Delete(int bookingId)
        {
            using (MyDbContext context = new MyDbContext(_options))
            {
                Booking booking = context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);

                if (booking != null)
                {
                    context.Bookings.Remove(booking);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
