using System;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using footprints.Models;
using footprints.Data;
using footprints.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace footprints.Controllers
{
    //[Authorize]
    [Route("api/[controller]")] 
    public class HouseController : Controller
    {
        private readonly IHouseRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public HouseController(IHouseRepository repo, IConfiguration config, DataContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        [HttpPost("register")] //<host>/api/house/register
        public async Task<IActionResult> Register([FromBody] HouseForRegisterDto houseForRegisterDto)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FirstOrDefaultAsync(test => test.Id == houseForRegisterDto.UserId);

            var houseToCreate = new House
            {
                Location = houseForRegisterDto.Location,
                SquareFootage = houseForRegisterDto.SquareFootage,
                Food = houseForRegisterDto.Food,
                Solar = houseForRegisterDto.Solar,
                Wind = houseForRegisterDto.Wind,
                Geothermal = houseForRegisterDto.Geothermal,
                User = user
            };

            var createHouse = await _repo.Register(houseToCreate);

            return Ok(new {createHouse.Location, createHouse.SquareFootage});
        }
    }
}