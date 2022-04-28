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

namespace CanadaGamesMVC.Controllers
{
    [Authorize]
    public class AthletePlacementsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public AthletePlacementsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: AthletePlacement
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Index(int? page, int? pageSizeID, int? EventID, int? AthleteID, string actionButton,
            string SearchString, string sortDirection = "desc", string sortField = "Event")
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Athletes");

            if (!AthleteID.HasValue)
            {
                return Redirect(ViewData["returnURL"].ToString());
            }

            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            PopulateDropDownLists();

            ViewData["Filtering"] = "btn-outline-dark"; 

            string[] sortOptions = new[] { "Event", "Sport", "Place" };

            var placements = from a in _context.Placements
                        .Include(a => a.Event)
                        .Include(a => a.Event.Sport)
                        .Include(a => a.Athlete.Sport)
                        .Include(a => a.Athlete)
                             where a.AthleteID == AthleteID.GetValueOrDefault()
                             select a;
            #region Filtering
            if (EventID.HasValue)
            {
                placements = placements.Where(p => p.EventID == EventID);
                ViewData["Filtering"] = "btn-danger";
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                placements = placements.Where(p => p.Comments.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = "btn-danger";
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
            if (sortField == "Event")
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Event.Name);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Event.Name);
                }
            }
            else if (sortField == "Sport")
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Event.Sport.Name);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Event.Sport.Name);
                }
            }
            else if (sortField == "Place")
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Place);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Place);
                }
            }
            #endregion
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            Athlete athlete = _context.Athletes
                .Include(a => a.AthleteThumbnail)
                .Include(a => a.Coach)
                .Include(a => a.Gender)
                .Include(a => a.Sport)
                .Include(a => a.Hometown)
                .Include(a => a.Contingent)
                .Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                .Where(a => a.ID == AthleteID.GetValueOrDefault()).FirstOrDefault();
            ViewBag.Athlete = athlete;

            //Handle Paging
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Placement>.CreateAsync(placements.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: AthletePlacements/Details/5
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placement = await _context.Placements
                .Include(p => p.Athlete)
                .Include(a => a.Event.Sport)
                .Include(p => p.Event)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // GET: AthletePlacements/Create
        [Authorize(Roles = "Admin,Supervisor")]
        public IActionResult Add(int? AthleteID, string AthleteName)
        {
            ViewDataReturnURL();

            if (!AthleteID.HasValue)
            {
                return Redirect(ViewData["returnURL"].ToString());
            }

            ViewData["AthleteName"] = AthleteName;
            Placement p = new Placement()
            {
                AthleteID = AthleteID.GetValueOrDefault()
            };
            PopulateDropDownLists();
            return View(p);
        }

        // POST: AthletePlacements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Add([Bind("ID,Place,Comments,EventID,AthleteID")] Placement placement, string AthleteName)
        {
            ViewDataReturnURL();
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(placement);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(ViewData["returnURL"].ToString());
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(placement);
            ViewData["AthleteName"] = AthleteName;
            return View(placement);
        }

        // GET: AthletePlacements/Edit/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewDataReturnURL();

            var placement = await _context.Placements
                .Include(p => p.Event)
                .Include(p => p.Athlete)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (placement == null)
            {
                return NotFound();
            }
            PopulateDropDownLists();
            return View(placement);
        }

        // POST: AthletePlacements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Update(int id)
        {
            ViewDataReturnURL();

            var placementToUpdate = await _context.Placements
                .Include(a => a.Event)
                .Include(a => a.Athlete)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (id != placementToUpdate.ID)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Placement>(placementToUpdate, "",
            p => p.Place, p => p.Comments, p => p.EventID))
            {
                try
                    {
                       _context.Update(placementToUpdate);
                       await _context.SaveChangesAsync();
                       return Redirect(ViewData["returnURL"].ToString());
                    }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(placementToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateDropDownLists(placementToUpdate);
            return View(placementToUpdate);
        }

        // GET: AthletePlacements/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placement = await _context.Placements
                .Include(p => p.Athlete)
                .Include(a => a.Event.Sport)
                .Include(p => p.Event)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // POST: AthletePlacements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placement = await _context.Placements.FindAsync(id);
            _context.Placements.Remove(placement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementExists(int id)
        {
            return _context.Placements.Any(e => e.ID == id);
        }
        private SelectList PlacementEventSelectList(int? id)
        {
            var dQuery = from d in _context.Events
                         orderby d.Name
                         select d;
            return new SelectList(dQuery, "ID", "Name", id);
        }

        private void PopulateDropDownLists(Placement placement = null)
        {
            ViewData["EventID"] = PlacementEventSelectList(placement?.EventID);
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
