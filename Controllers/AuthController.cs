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

namespace footprints.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public AuthController(IAuthRepository repo, IConfiguration config, DataContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        [HttpPost("register")] //<host>/api/auth/register
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto){ //Data Transfer Object containing username and password.
            // validate request
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower(); //Convert username to lower case before storing in database.

            if(await _repo.UserExists(userForRegisterDto.Username)) 
                return BadRequest("Username is already taken");

            var userToCreate = new User{
                Username = userForRegisterDto.Username
            };

            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return Ok(new {userToCreate.Id});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForRegisterDto)
        {
            var userFromRepo = await _repo.Login(userForRegisterDto.Username.ToLower(), userForRegisterDto.Password);
            if (userFromRepo == null) //User login failed
                return Unauthorized();
            
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var footprintsJWT = tokenHandler.WriteToken(token);

            var user = _context.Users.Select(o => new
            {
                o.Id,
                o.Username,
                Vehicles = o.Vehicles.Select(u => new
                {
                    u.Id,
                    u.Make,
                    u.Model,
                    u.Mpg,
                    u.Fuel,
                    u.Year
                }).ToList(),
                Houses = o.Houses.Select(h => new
                {
                    h.Location,
                    h.SquareFootage,
                    h.Food,
                    h.Solar,
                    h.Wind,
                    h.Geothermal
                }).ToList()
            })
                .First(test => test.Id == userFromRepo.Id );

            return Ok(new
            {
                footprintsJWT,
                user
            });
        }
    }
}