using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locker.Models;

namespace Locker.Controllers
{
    public class AssignedEmployeeLockerCasesController : Controller
    {
        private readonly LockerDbContext _context;

        public AssignedEmployeeLockerCasesController(LockerDbContext context)
        {
            _context = context;
        }

        // GET: AssignedEmployeeLockerCases
        public async Task<IActionResult> Index()
        {
            var lockerDbContext = _context.AssignedEmployeeLockerCase.Include(a => a.LockerCase);
            return View(await lockerDbContext.ToListAsync());
        }

        // GET: AssignedEmployeeLockerCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedEmployeeLockerCase = await _context.AssignedEmployeeLockerCase
                .Include(a => a.LockerCase)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (assignedEmployeeLockerCase == null)
            {
                return NotFound();
            }

            return View(assignedEmployeeLockerCase);
        }

        // GET: AssignedEmployeeLockerCases/Create
        public IActionResult Create()
        {
            ViewData["LockerCaseId"] = new SelectList(_context.LockerCase, "LockerCaseId", "LockerCaseId");
            return View();
        }

        // POST: AssignedEmployeeLockerCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,LockerCaseId")] AssignedEmployeeLockerCase assignedEmployeeLockerCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignedEmployeeLockerCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LockerCaseId"] = new SelectList(_context.LockerCase, "LockerCaseId", "LockerCaseId", assignedEmployeeLockerCase.LockerCaseId);
            return View(assignedEmployeeLockerCase);
        }

        // GET: AssignedEmployeeLockerCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedEmployeeLockerCase = await _context.AssignedEmployeeLockerCase.FindAsync(id);
            if (assignedEmployeeLockerCase == null)
            {
                return NotFound();
            }
            ViewData["LockerCaseId"] = new SelectList(_context.LockerCase, "LockerCaseId", "LockerCaseId", assignedEmployeeLockerCase.LockerCaseId);
            return View(assignedEmployeeLockerCase);
        }

        // POST: AssignedEmployeeLockerCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,LockerCaseId")] AssignedEmployeeLockerCase assignedEmployeeLockerCase)
        {
            if (id != assignedEmployeeLockerCase.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignedEmployeeLockerCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedEmployeeLockerCaseExists(assignedEmployeeLockerCase.EmployeeId))
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
            ViewData["LockerCaseId"] = new SelectList(_context.LockerCase, "LockerCaseId", "LockerCaseId", assignedEmployeeLockerCase.LockerCaseId);
            return View(assignedEmployeeLockerCase);
        }

        // GET: AssignedEmployeeLockerCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedEmployeeLockerCase = await _context.AssignedEmployeeLockerCase
                .Include(a => a.LockerCase)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (assignedEmployeeLockerCase == null)
            {
                return NotFound();
            }

            return View(assignedEmployeeLockerCase);
        }

        // POST: AssignedEmployeeLockerCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignedEmployeeLockerCase = await _context.AssignedEmployeeLockerCase.FindAsync(id);
            _context.AssignedEmployeeLockerCase.Remove(assignedEmployeeLockerCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignedEmployeeLockerCaseExists(int id)
        {
            return _context.AssignedEmployeeLockerCase.Any(e => e.EmployeeId == id);
        }
    }
}
