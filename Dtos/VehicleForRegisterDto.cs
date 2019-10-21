using System;
using System.ComponentModel.DataAnnotations;
using footprints.Models;

namespace footprints.Dtos
{
    public class VehicleForRegisterDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public int Mpg { get; set; }
        public int UserId { get; set; }
    }
}