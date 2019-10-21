using System;
using footprints.Models;

namespace footprints.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int SquareFootage { get; set; }
        public string Food { get; set; }
        public bool Solar { get; set; }
        public bool Wind { get; set; }
        public bool Geothermal { get; set; }
        public User User { get; set; }
    }
}