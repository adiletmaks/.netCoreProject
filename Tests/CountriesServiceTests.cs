using System;
using System.Threading.Tasks;
using Xunit;
using myProject.Models;
using myProject.Services;
using Moq;
using System.Collections.Generic;

namespace Tests
{
    public class CountriesServiceTests
    {
        [Fact]
        public async Task StoreTest()
        {
            var fakeRepository = Mock.Of<ICountriesRepository>();
            var countriesService = new CountriesService(fakeRepository);

            var country = new Country() { Name = "SomeCountry" };
            await countriesService.Store(country);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<ICountriesRepository>();
            var countriesService = new CountriesService(fakeRepository);

            var country = new Country() { Id = 1, Name = "UpdatedCountry" };
            await countriesService.Update(country);
        }

        [Fact]
        public async Task DestroyTest()
        {
            var fakeRepository = Mock.Of<ICountriesRepository>();
            var countriesService = new CountriesService(fakeRepository);

            var country = new Country() { Id = 1, Name = "DestroyedCountry" };
            await countriesService.Destroy(country.Id);
        }

        [Fact]
        public async Task GetById()
        {
            var fakeRepository = Mock.Of<ICountriesRepository>();
            var countriesService = new CountriesService(fakeRepository);

            await countriesService.GetById(1);
        }

        [Fact]
        public async Task GetAllTest()
        {
            var countries = new List<Country>
            {
                new Country() { Name = "Country-1" },
                new Country() { Name = "Country-2" },
            };

            var fakeRepositoryMock = new Mock<ICountriesRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(countries);


            var countriesService = new CountriesService(fakeRepositoryMock.Object);

            var result = await countriesService.GetAll();

            Assert.Collection(result, country =>
            {
                Assert.Equal("Country-1", country.Name);
            },
            country =>
            {
                Assert.Equal("Country-2", country.Name);
            });
        }

    }
}
