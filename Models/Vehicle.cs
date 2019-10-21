using System;
using footprints.Models;

namespace footprints.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public int Mpg { get; set; }
        public User User { get; set; }
    }
}