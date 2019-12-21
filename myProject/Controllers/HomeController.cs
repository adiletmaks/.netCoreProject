using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myProject.Data;
using myProject.Models;

namespace myProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly BlogPlatformContext _context;
        private readonly ILogger _logger;

        public HomeController(BlogPlatformContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _context.Posts.Include(p => p.Category).Include(p => p.User).ToListAsync();
            ViewBag.posts = posts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetPostById(uint? id)
        {
            _logger.LogWarning("getPost");
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            ViewBag.post = post;

            return View();
        }

        public async Task<IActionResult> GetPostsByCategory(string categorySlug = "")
        {
            _logger.LogWarning("GetPostsByCategoryMethod {0}", categorySlug);
            if (categorySlug == null || categorySlug == "")
            {
                return NotFound();
            }

            var category = _context.Categories.Where(c => c.Slug == categorySlug).First();
            if(category == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .Where(p => p.CategoryId == category.Id)
                .ToListAsync();

            if (posts == null)
            {
                return NotFound();
            }

            ViewBag.posts = posts;

            return View();
        }
    }
}
