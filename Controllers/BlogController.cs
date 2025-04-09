using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Data;
using MyMvcProject.Models;

namespace MyMvcProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly DatabaseContext _context;

        public BlogController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.BlogPosts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost post)
        {
            if (!ModelState.IsValid)
                return View(post);

            post.CreatedAt = DateTime.Now;
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blogPost = _context.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
