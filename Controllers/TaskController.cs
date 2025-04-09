using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcProject.Data;

namespace MyMvcProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly DatabaseContext _context;

        public TaskController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                task.CreatedAt = DateTime.Now;
                task.IsCompleted = false;
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async Task<IActionResult> Complete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            task.IsCompleted = true;
            _context.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
