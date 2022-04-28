using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanadaGamesMVC.Data;
using CanadaGamesMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanadaGamesMVC.Controllers
{
    [Authorize]
    public class ContingentsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public ContingentsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Contingents
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Lookups");
        }

        // GET: Contingents/Details/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contingent = await _context.Contingents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contingent == null)
            {
                return NotFound();
            }

            return View(contingent);
        }

        // GET: Contingents/Create
        [Authorize(Roles = "Admin,Supervisor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contingents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Name")] Contingent contingent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contingent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Lookups");
            }
            return View(contingent);
        }

        // GET: Contingents/Edit/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contingent = await _context.Contingents.FindAsync(id);
            if (contingent == null)
            {
                return NotFound();
            }
            return View(contingent);
        }

        // POST: Contingents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Name")] Contingent contingent)
        {
            if (id != contingent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contingent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContingentExists(contingent.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Lookups");
            }
            return View(contingent);
        }

        // GET: Contingents/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contingent = await _context.Contingents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contingent == null)
            {
                return NotFound();
            }

            return View(contingent);
        }

        // POST: Contingents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contingent = await _context.Contingents.FindAsync(id);
            _context.Contingents.Remove(contingent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Lookups");
        }

        private bool ContingentExists(int id)
        {
            return _context.Contingents.Any(e => e.ID == id);
        }
    }
}
