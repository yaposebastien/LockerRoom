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
    public class LockerCasesController : Controller
    {
        private readonly LockerDbContext _context;

        public LockerCasesController(LockerDbContext context)
        {
            _context = context;
        }

        // GET: LockerCases
        public async Task<IActionResult> Index()
        {
            return View(await _context.LockerCase.ToListAsync());
        }

        // GET: LockerCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lockerCase = await _context.LockerCase
                .FirstOrDefaultAsync(m => m.LockerCaseId == id);
            if (lockerCase == null)
            {
                return NotFound();
            }

            return View(lockerCase);
        }

        // GET: LockerCases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LockerCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LockerCaseId,LockerCaseName")] LockerCase lockerCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lockerCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lockerCase);
        }

        // GET: LockerCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lockerCase = await _context.LockerCase.FindAsync(id);
            if (lockerCase == null)
            {
                return NotFound();
            }
            return View(lockerCase);
        }

        // POST: LockerCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LockerCaseId,LockerCaseName")] LockerCase lockerCase)
        {
            if (id != lockerCase.LockerCaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lockerCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LockerCaseExists(lockerCase.LockerCaseId))
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
            return View(lockerCase);
        }

        // GET: LockerCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lockerCase = await _context.LockerCase
                .FirstOrDefaultAsync(m => m.LockerCaseId == id);
            if (lockerCase == null)
            {
                return NotFound();
            }

            return View(lockerCase);
        }

        // POST: LockerCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lockerCase = await _context.LockerCase.FindAsync(id);
            _context.LockerCase.Remove(lockerCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LockerCaseExists(int id)
        {
            return _context.LockerCase.Any(e => e.LockerCaseId == id);
        }
    }
}
