using System;
using System.Threading.Tasks;
using footprints.Models;
using Microsoft.EntityFrameworkCore;

namespace footprints.Data
{
    public class HouseRepository : IHouseRepository
    {
        private readonly DataContext _context;
        public HouseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<House> Register(House house)
        {
            await _context.Houses.AddAsync(house); 
            await _context.SaveChangesAsync(); 

            return house;
        }
    }
}