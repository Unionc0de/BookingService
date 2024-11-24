using BookingService.Data;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookingsController:Controller
    {
        private DataContext _context;

        public BookingsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(string name,string details)
        {
            var booking = new Bookings(name, DateTime.Now, details);
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return Ok(booking.Id);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(Guid id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return NotFound("Брони с таким ID не найдено");
            }
            return Ok(booking);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Guid id, string name,DateTime bookingDate,string details)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return NotFound("Брони с таким ID не найдено");
            }
            booking.Name = name;
            booking.BookingDate = bookingDate;
            booking.Details = details;
            _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return NotFound("Брони с таким ID не найдено");
            }

            _context.Remove(booking);
            _context.SaveChangesAsync();

            return Ok($"Booking {id} успешно удален");
        }

    }
}


