using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechHub.Models;
using TechHub.Models.Seller;

namespace TechHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly Dbcontext _context;

        public SellersController(Dbcontext context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        public async Task<ActionResult<Seller>> Login([FromQuery] string email, [FromQuery] string password)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }

    }
}
