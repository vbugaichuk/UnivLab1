using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBIT;

namespace DBIT.Controllers
{
    public class SubdivisionsController : Controller
    {
        private readonly DBITCompanyContext _context;

        public SubdivisionsController(DBITCompanyContext context)
        {
            _context = context;
        }

        // GET: Subdivisions
        public async Task<IActionResult> Index()
        {
            var dBITCompanyContext = _context.Subdivisions.Include(s => s.Office);
            return View(await dBITCompanyContext.ToListAsync());
        }

        // GET: Subdivisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivisions
                .Include(s => s.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // GET: Subdivisions/Create
        public IActionResult Create()
        {
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Address");
            return View();
        }

        // POST: Subdivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OfficeId")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subdivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Address", subdivision.OfficeId);
            return View(subdivision);
        }

        // GET: Subdivisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivisions.FindAsync(id);
            if (subdivision == null)
            {
                return NotFound();
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Address", subdivision.OfficeId);
            return View(subdivision);
        }

        // POST: Subdivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OfficeId")] Subdivision subdivision)
        {
            if (id != subdivision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subdivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubdivisionExists(subdivision.Id))
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Address", subdivision.OfficeId);
            return View(subdivision);
        }

        // GET: Subdivisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivisions
                .Include(s => s.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // POST: Subdivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subdivision = await _context.Subdivisions.FindAsync(id);
            _context.Subdivisions.Remove(subdivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubdivisionExists(int id)
        {
            return _context.Subdivisions.Any(e => e.Id == id);
        }
    }
}
