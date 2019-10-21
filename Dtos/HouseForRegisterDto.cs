using System;
using System.ComponentModel.DataAnnotations;
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
        public int UserId { get; set; }
    }
}