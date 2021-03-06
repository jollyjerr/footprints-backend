﻿using System;
using System.Threading.Tasks;
using footprints.Models;
using Microsoft.EntityFrameworkCore;

namespace footprints.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> Register(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle); 
            await _context.SaveChangesAsync(); 

            return vehicle;
        }
    }
}
