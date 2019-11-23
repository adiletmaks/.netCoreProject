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
        private readonly BlogPlatformContext _context;

        public CountriesService(BlogPlatformContext context)
        {
            _context = context;
        }

        public void Store(Country country)
        {
            _context.Add(country);
            _context.SaveChangesAsync();
        }

        public void Update(Country country)
        {
            _context.Update(country);
            _context.SaveChangesAsync();
        }

        public void Destroy(uint id)
        {
            Country country = _context.Countries.Where(c => c.Id == id).First();
            _context.Countries.Remove(country);
            _context.SaveChangesAsync();
        }
    }
}
