using Microsoft.EntityFrameworkCore;
using myProject.Data;
using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Services
{
    public class CountriesService
    {
        private readonly ICountriesRepository _countriesRepo;

        public CountriesService(ICountriesRepository countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        public async Task Store(Country country)
        {
            _countriesRepo.Store(country);
            await _countriesRepo.Save();
        }

        public async Task Update(Country country)
        {
            _countriesRepo.Update(country);
            await _countriesRepo.Save();
        }

        public async Task Destroy(uint id)
        {
            _countriesRepo.Destroy(id);
            await _countriesRepo.Save();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _countriesRepo.GetAll();
        }

        public async Task<Country> GetById(uint? id)
        {
            return await _countriesRepo.GetById(id);
        }

        public bool Exists(uint id) {
            return _countriesRepo.Exists(id);
        }
    }
}
