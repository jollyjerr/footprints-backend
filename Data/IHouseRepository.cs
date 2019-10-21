using System;
using System.Threading.Tasks;
using footprints.Models;

namespace footprints.Data
{
    public interface IHouseRepository
    {
        Task<House> Register(House house);
    }
}