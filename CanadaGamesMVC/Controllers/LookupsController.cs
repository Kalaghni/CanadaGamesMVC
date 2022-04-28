using CanadaGamesMVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Controllers
{
    [Authorize]
    public class LookupsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public LookupsController(CanadaGamesContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public IActionResult Index()
        {
            ViewData["ContingentID"] = new SelectList(_context.Contingents.OrderBy(a => a.Name), "ID", "Name");
            ViewData["GenderID"] = new SelectList(_context.Genders.OrderBy(a => a.Name), "ID", "Name");
            ViewData["HometownID"] = new SelectList(_context.Hometowns.OrderBy(a => a.Name), "ID", "Name");
            return View();
        }

    }
}
