using Microsoft.EntityFrameworkCore;
using myProject.Data;
using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Services
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly BlogPlatformContext _context;

        public CountriesRepository(BlogPlatformContext context)
        {
            _context = context;
        }

        public void Store(Country country)
        {
            _context.Add(country);
        }

        public void Update(Country country)
        {
            _context.Update(country);
        }

        public void Destroy(uint id)
        {
            Country country = _context.Countries.Where(c => c.Id == id).First();
            _context.Countries.Remove(country);
        }

        public Task<List<Country>> GetAll()
        {
            return _context.Countries.ToListAsync();
        }

        public Task<Country> GetById(uint? id)
        {
            return _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Exists(uint id) {
            return _context.Countries.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
