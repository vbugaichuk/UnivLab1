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
    public class EmpSubsController : Controller
    {
        private readonly DBITCompanyContext _context;

        public EmpSubsController(DBITCompanyContext context)
        {
            _context = context;
        }

        // GET: EmpSubs
        public async Task<IActionResult> Index()
        {
            var dBITCompanyContext = _context.EmpSubs.Include(e => e.Employer).Include(e => e.Position).Include(e => e.Subdivision);
            return View(await dBITCompanyContext.ToListAsync());
        }

        // GET: EmpSubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSub = await _context.EmpSubs
                .Include(e => e.Employer)
                .Include(e => e.Position)
                .Include(e => e.Subdivision)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empSub == null)
            {
                return NotFound();
            }

            return View(empSub);
        }

        // GET: EmpSubs/Create
        public IActionResult Create()
        {
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name");
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Position");
            ViewData["SubdivisionId"] = new SelectList(_context.Subdivisions, "Id", "Name");
            return View();
        }

        // POST: EmpSubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Salary,PositionId,SubdivisionId,EmployerId")] EmpSub empSub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empSub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name", empSub.EmployerId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Position", empSub.PositionId);
            ViewData["SubdivisionId"] = new SelectList(_context.Subdivisions, "Id", "Name", empSub.SubdivisionId);
            return View(empSub);
        }

        // GET: EmpSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSub = await _context.EmpSubs.FindAsync(id);
            if (empSub == null)
            {
                return NotFound();
            }
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name", empSub.EmployerId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Position", empSub.PositionId);
            ViewData["SubdivisionId"] = new SelectList(_context.Subdivisions, "Id", "Name", empSub.SubdivisionId);
            return View(empSub);
        }

        // POST: EmpSubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Salary,PositionId,SubdivisionId,EmployerId")] EmpSub empSub)
        {
            if (id != empSub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empSub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpSubExists(empSub.Id))
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
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name", empSub.EmployerId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Position", empSub.PositionId);
            ViewData["SubdivisionId"] = new SelectList(_context.Subdivisions, "Id", "Name", empSub.SubdivisionId);
            return View(empSub);
        }

        // GET: EmpSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSub = await _context.EmpSubs
                .Include(e => e.Employer)
                .Include(e => e.Position)
                .Include(e => e.Subdivision)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empSub == null)
            {
                return NotFound();
            }

            return View(empSub);
        }

        // POST: EmpSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empSub = await _context.EmpSubs.FindAsync(id);
            _context.EmpSubs.Remove(empSub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpSubExists(int id)
        {
            return _context.EmpSubs.Any(e => e.Id == id);
        }
    }
}
