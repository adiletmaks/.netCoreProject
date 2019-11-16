using Microsoft.AspNetCore.Mvc;
using myProject.Controllers;
using myProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace myProject.Tests
{
    public class RolesControllerTests
    {

        private readonly BlogPlatformContext _context;

        public RolesControllerTests(BlogPlatformContext context)
        {
            _context = context;
        }

        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            //RolesController controller = new RolesController(_context);

            // Act
           // ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }
    }
}
