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
    [Route("api/[controller]")] //<host>/api/vehicle/register
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public VehicleController(IVehicleRepository repo, IConfiguration config, DataContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        [HttpPost("register")] //<host>/api/vehicle/register
        public async Task<IActionResult> Register([FromBody] VehicleForRegisterDto vehicleForRegisterDto)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FirstOrDefaultAsync(test => test.Id == vehicleForRegisterDto.UserId);

            var vehicleToCreate = new Vehicle
            {
                Make = vehicleForRegisterDto.Make,
                Model = vehicleForRegisterDto.Model,
                Year = vehicleForRegisterDto.Year,
                Fuel = vehicleForRegisterDto.Fuel,
                Mpg = vehicleForRegisterDto.Mpg,
                User = user
            };

            var createVehicle = await _repo.Register(vehicleToCreate);

            return Ok();
        }
    }
}
