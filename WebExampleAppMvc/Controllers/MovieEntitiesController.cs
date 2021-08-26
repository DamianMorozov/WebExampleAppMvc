using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebExampleAppMvc.Data;
using WebExampleAppMvc.Models;

namespace WebExampleAppMvc.Controllers
{
    public class MovieEntitiesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MovieEntitiesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MovieEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieEntity.ToListAsync());
        }

        // GET: MovieEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await _context.MovieEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return View(movieEntity);
        }

        // GET: MovieEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] MovieEntity movieEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieEntity);
        }

        // GET: MovieEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await _context.MovieEntity.FindAsync(id);
            if (movieEntity == null)
            {
                return NotFound();
            }
            return View(movieEntity);
        }

        // POST: MovieEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] MovieEntity movieEntity)
        {
            if (id != movieEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieEntityExists(movieEntity.Id))
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
            return View(movieEntity);
        }

        // GET: MovieEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await _context.MovieEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return View(movieEntity);
        }

        // POST: MovieEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieEntity = await _context.MovieEntity.FindAsync(id);
            _context.MovieEntity.Remove(movieEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieEntityExists(int id)
        {
            return _context.MovieEntity.Any(e => e.Id == id);
        }
    }
}
