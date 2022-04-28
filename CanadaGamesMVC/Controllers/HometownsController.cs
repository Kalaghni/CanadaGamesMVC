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
    public class HometownsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public HometownsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Hometowns
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Index()
        {
            var canadaGamesContext = _context.Hometowns.Include(h => h.Contingent);
            return View(await canadaGamesContext.ToListAsync());
        }

        // GET: Hometowns/Details/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometown = await _context.Hometowns
                .Include(h => h.Contingent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hometown == null)
            {
                return NotFound();
            }

            return View(hometown);
        }

        // GET: Hometowns/Create

        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public IActionResult Create()
        {
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code");
            return View();
        }

        // POST: Hometowns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Create([Bind("ID,Name,ContingentID")] Hometown hometown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hometown);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Lookups");
            }
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", hometown.ContingentID);
            return View(hometown);
        }

        [Authorize(Roles = "Admin,Supervisor,Staff")]
        // GET: Hometowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometown = await _context.Hometowns.FindAsync(id);
            if (hometown == null)
            {
                return NotFound();
            }
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", hometown.ContingentID);
            return View(hometown);
        }

        // POST: Hometowns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ContingentID")] Hometown hometown)
        {

            

            if (id != hometown.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hometown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HometownExists(hometown.ID))
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
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", hometown.ContingentID);
            return View(hometown);
        }

        // GET: Hometowns/Delete/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometown = await _context.Hometowns
                .Include(h => h.Contingent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hometown == null)
            {
                return NotFound();
            }

            return View(hometown);
        }

        // POST: Hometowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.IsInRole("Staff"))
            {
                return RedirectToAction("Index", "Hometown");
            }

            var hometown = await _context.Hometowns.FindAsync(id);
            _context.Hometowns.Remove(hometown);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Hometown");
        }

        private bool HometownExists(int id)
        {
            return _context.Hometowns.Any(e => e.ID == id);
        }
    }
}
