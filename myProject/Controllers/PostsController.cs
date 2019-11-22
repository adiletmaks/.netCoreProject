using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myProject.Data;
using myProject.Models;

namespace myProject.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogPlatformContext _context;

        private readonly ILogger _logger;

        public PostsController(BlogPlatformContext context, ILogger<PostsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            _logger.LogWarning("Index method...");
            _logger.LogInformation("Index method INFO...");
            var blogPlatformContext = _context.Posts.Include(p => p.Category).Include(p => p.User);
            return View(await blogPlatformContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
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

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["TagsList"] = new SelectList(_context.Tags, "Id", "Name");

            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostVM viewmodel)
        {
            if (viewmodel.Post == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            Post post = viewmodel.Post;
            _logger.LogInformation("viewmodel.SelectedTags {0}", viewmodel.SelectedTags);

            _context.Add(post);
            await _context.SaveChangesAsync();

            List<PostTag> postTags = new List<PostTag>();
            foreach (var postTagId in viewmodel.SelectedTags)
            {
                postTags.Add(new PostTag { TagId = postTagId, PostId = post.Id});
            }

            _logger.LogInformation($"postTags {postTags}");
            post.PostTags = postTags;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.PostTags).Where(p => p.Id == id).FirstOrDefaultAsync();
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", post.UserId);

            _logger.LogInformation("test post {0} {1}", post.PostTags, post.Title);

            var viewModel = new PostVM
            {
                Post = post,
                TagsList = new SelectList(_context.Tags, "Id", "Name"),
                SelectedTags = post.PostTags.Select(pt => pt.TagId)
            };

            return View(viewModel);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, PostVM viewModel)
        {
            if (id != viewModel.Post.Id)
            {
                return NotFound();
            }

            if (! ModelState.IsValid)
            {
                return BadRequest();      
            }

            try
            {
                Post post = viewModel.Post;
                _context.PostTag.RemoveRange(_context.PostTag.Where(pt => pt.PostId == id));
                await _context.SaveChangesAsync();

                //List<PostTag> postTags = new List<PostTag>();
                foreach (var postTagId in viewModel.SelectedTags)
                {
                    _context.PostTag.Add(new PostTag { TagId = postTagId, PostId = post.Id });
                }
                //post.PostTags = postTags;
                _context.Update(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(viewModel.Post.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
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

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(uint id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
