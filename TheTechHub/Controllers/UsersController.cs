
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using TechHub.Models;
using TechHub.Models.Seller;
using TechHub.Models.Users;

namespace TechHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Dbcontext _context;

        public UsersController(Dbcontext context)
        {
            _context = context;
        }
        // GET: api/Sellers

        [HttpGet("Login")]
        public async Task<ActionResult<Users>> Login([FromQuery] string email, [FromQuery] string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("SignUp")]

        public async Task<IActionResult> SignUp([FromBody] Users userObjsignup)
        {
            if (userObjsignup == null)
                return BadRequest();

            await _context.Users.AddAsync(userObjsignup); //we add the user to the database
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User Added!" });

        }
        [HttpGet("UserExists")]
        public async Task<ActionResult<Users>> UserExists([FromQuery] string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}