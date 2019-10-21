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
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _repo;
        private readonly IConfiguration _config;
        public VehicleController(IVehicleRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
    }
}
