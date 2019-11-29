using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Services
{
    public interface ICountriesRepository
    {
        void Store(Country country);
        void Update(Country country);
        void Destroy(uint id);
        Task<List<Country>> GetAll();
        Task<Country> GetById(uint? id);
        bool Exists(uint id);
        Task Save();
    }
}