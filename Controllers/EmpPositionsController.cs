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
    public class EmpPositionsController : Controller
    {
        private readonly DBITCompanyContext _context;

        public EmpPositionsController(DBITCompanyContext context)
        {
            _context = context;
        }

        // GET: EmpPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Positions.ToListAsync());
        }

        // GET: EmpPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empPosition = await _context.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empPosition == null)
            {
                return NotFound();
            }

            return View(empPosition);
        }

        // GET: EmpPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position")] EmpPosition empPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empPosition);
        }

        // GET: EmpPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empPosition = await _context.Positions.FindAsync(id);
            if (empPosition == null)
            {
                return NotFound();
            }
            return View(empPosition);
        }

        // POST: EmpPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position")] EmpPosition empPosition)
        {
            if (id != empPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpPositionExists(empPosition.Id))
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
            return View(empPosition);
        }

        // GET: EmpPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empPosition = await _context.Positions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empPosition == null)
            {
                return NotFound();
            }

            return View(empPosition);
        }

        // POST: EmpPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empPosition = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(empPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpPositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
