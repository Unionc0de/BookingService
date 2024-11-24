using BookingService.Data;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(long id, string name, string email)
        {
            var user = new User(id, name, email);
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok($"Пользователь создан id: {user.Id}");
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(long id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {

                return BadRequest($"Пользователь с id: {id} не сущесвует");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(long id, string name, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {

                return BadRequest($"Пользователь с id: {id} не сущесвует");
            }
            else
            {
                user.Email = email;
                user.Name = name;
                return Ok(user);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {

                return BadRequest($"Пользователь с id: {id} не найден");
            }
            _context.Users.Remove(user);
            return NoContent();
        }

    }
}
