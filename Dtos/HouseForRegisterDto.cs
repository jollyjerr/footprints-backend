using System;
using System.Collections.Generic;
using footprints.Models;

namespace footprints.Dtos
{
    public class HouseForRegisterDto
    {
        public string Location { get; set; }
        public int SquareFootage { get; set; }
        public string Food { get; set; }
        public bool Solar { get; set; }
        public bool Wind { get; set; }
        public bool Geothermal { get; set; }
        public User User { get; set; }
    }
}