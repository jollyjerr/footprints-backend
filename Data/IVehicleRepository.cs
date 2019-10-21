using System;
using System.Threading.Tasks;
using footprints.Models;

namespace footprints.Data
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Register(Vehicle vehicle);
    }
}
