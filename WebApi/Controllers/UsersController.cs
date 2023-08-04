using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly EmployeeDetailContext _context;

        public UsersController(ILogger<UsersController> logger, EmployeeDetailContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("Users")]
        //public List<User> GetAllUsers() => _context.getUsers();
        public List<User> GettblUser()
        {
            return _context.tblUser.ToList();
        }

        // multiple parameter GET: api/<UserController>/2
        [HttpGet("Users/{id}/{name}")]
        [Route("Users")]
        public List<User> GetUser(short id, string name)
        {
            var user = _context.tblUser
                            .Where(d => d.EmpID == id)
                            .Where(d => d.Username.Contains(name))
                            .ToList();

            if (user == null)
            {
               _logger.LogInformation("User not found.");
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Users")]
        //[AllowAnonymous]
        public IActionResult AddUser([FromBody] User user)
        {
            _logger.LogInformation("Add User for UserId: {UserId}", user.EmpID);
            //_context.AddUser(user);
            user.CreatedDt = DateTime.Now;
            _context.tblUser.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPut("Users/{id}")]
        [Route("Users")]
        //[AllowAnonymous]
        public async Task<IActionResult> UpdateUser(short id, User user)
        {
            if (id != user.EmpID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("Users/{id}")]
        [Route("Users")]
        public async Task<IActionResult> DeleteEmployeeDetail(short id)
        {
            var user = await _context.tblUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.tblUser.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(short id)
        {
            return _context.tblUser.Any(e => e.EmpID == id);
        }
    }
}
