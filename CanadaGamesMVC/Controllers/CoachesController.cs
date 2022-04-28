using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanadaGamesMVC.Data;
using CanadaGamesMVC.Models;
using CanadaGamesMVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.IO;

namespace CanadaGamesMVC.Controllers
{
    [Authorize]
    public class CoachesController : Controller
    {
        private readonly CanadaGamesContext _context;

        public CoachesController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Coaches
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Index(string SearchString, int? page, int? pageSizeID,
            string actionButton, string sortDirection = "asc", string sortField = "Last Name")
        {
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            string[] sortOptions = new[] { "First Name", "Last Name" };

            var coaches = (from c in _context.Coaches select c);

            if (!String.IsNullOrEmpty(SearchString))
            {
                coaches = coaches.Where(c => c.FirstName.Contains(SearchString) || c.LastName.Contains(SearchString));
            }

            if (!String.IsNullOrEmpty(actionButton))
            {
                page = 1;
                if (sortOptions.Contains(actionButton))
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }

            if (sortField == "First Name")
            {
                if (sortDirection == "asc")
                {
                    coaches = coaches.OrderBy(c => c.FirstName);
                }
                else
                {
                    coaches = coaches.OrderByDescending(c => c.FirstName);
                }
            }

            if (sortField == "Last Name")
            {
                if (sortDirection == "asc")
                {
                    coaches = coaches.OrderBy(c => c.LastName);
                }
                else
                {
                    coaches = coaches.OrderByDescending(c => c.LastName);
                }
            }

            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Coach>.CreateAsync(coaches.AsNoTracking(), page ?? 1, pageSize);

            ViewDataReturnURL();

            return View(pagedData);
        }

        // GET: Coaches/Details/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .FirstOrDefaultAsync(m => m.ID == id);

            if (coach == null)
            {
                return NotFound();
            }

            ViewDataReturnURL();

            return View(coach);
        }

        // GET: Coaches/Create
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public IActionResult Create()
        {
            ViewDataReturnURL();

            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Create([Bind("ID,FirstName,MiddleName,LastName")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coach);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Athletes");
            }

            ViewDataReturnURL();

            return View(coach);
        }

        // GET: Coaches/Edit/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            ViewDataReturnURL();

            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,MiddleName,LastName")] Coach coach)
        {
            if (id != coach.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Athletes");
            }

            ViewDataReturnURL();

            return View(coach);
        }

        // GET: Coaches/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coach == null)
            {
                return NotFound();
            }

            ViewDataReturnURL();

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Athletes");

        }

        [HttpPost]
        public async Task<IActionResult> InsertFromExcel(IFormFile theExcel)
        {
            ExcelPackage excel;
            using (var memoryStream = new MemoryStream())
            {
                await theExcel.CopyToAsync(memoryStream);
                excel = new ExcelPackage(memoryStream);
            }
            var workSheet = excel.Workbook.Worksheets[0];
            var start = workSheet.Dimension.Start;
            var end = workSheet.Dimension.End;

            List<Coach> coaches = new List<Coach>();

            for (int row = start.Row; row <= end.Row; row++)
            {
                Coach c = new Coach
                {
                    FirstName = workSheet.Cells[row, 1].Text,
                    MiddleName = workSheet.Cells[row, 1].Text,
                    LastName = workSheet.Cells[row, 1].Text
                };

                if (!_context.Coaches.Where(a => a.FullName == c.FullName).Any()) 
                {
                    coaches.Add(c);
                }
            }

            _context.Coaches.AddRange(coaches);
            _context.SaveChanges();
            return RedirectToAction("Index", this.ControllerName());
        }

        private bool CoachExists(int id)
        {
            return _context.Coaches.Any(e => e.ID == id);
        }
        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }
    }
}
