using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Models;

namespace RecipeBlog.Controllers
{
    public class PagecontentsController : Controller
    {
        private readonly ModelContext _context;

        public PagecontentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Pagecontents
        public async Task<IActionResult> Index()
        {
              return _context.Pagecontents != null ? 
                          View(await _context.Pagecontents.ToListAsync()) :
                          Problem("Entity set 'ModelContext.Pagecontents'  is null.");
        }

        // GET: Pagecontents/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Pagecontents == null)
            {
                return NotFound();
            }

            var pagecontent = await _context.Pagecontents
                .FirstOrDefaultAsync(m => m.Pagecontentid == id);
            if (pagecontent == null)
            {
                return NotFound();
            }

            return View(pagecontent);
        }

        // GET: Pagecontents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagecontents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pagecontentid,Pagename,Contentkey,Contentvalue")] Pagecontent pagecontent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagecontent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagecontent);
        }

        // GET: Pagecontents/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Pagecontents == null)
            {
                return NotFound();
            }

            var pagecontent = await _context.Pagecontents.FindAsync(id);
            if (pagecontent == null)
            {
                return NotFound();
            }
            return View(pagecontent);
        }

        // POST: Pagecontents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Pagecontentid,Pagename,Contentkey,Contentvalue")] Pagecontent pagecontent)
        {
            if (id != pagecontent.Pagecontentid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagecontent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagecontentExists(pagecontent.Pagecontentid))
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
            return View(pagecontent);
        }

        // GET: Pagecontents/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Pagecontents == null)
            {
                return NotFound();
            }

            var pagecontent = await _context.Pagecontents
                .FirstOrDefaultAsync(m => m.Pagecontentid == id);
            if (pagecontent == null)
            {
                return NotFound();
            }

            return View(pagecontent);
        }

        // POST: Pagecontents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Pagecontents == null)
            {
                return Problem("Entity set 'ModelContext.Pagecontents'  is null.");
            }
            var pagecontent = await _context.Pagecontents.FindAsync(id);
            if (pagecontent != null)
            {
                _context.Pagecontents.Remove(pagecontent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagecontentExists(decimal id)
        {
          return (_context.Pagecontents?.Any(e => e.Pagecontentid == id)).GetValueOrDefault();
        }
    }
}
