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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using Microsoft.AspNetCore.Http.Features;
using CanadaGamesMVC.ViewModels;

namespace CanadaGamesMVC.Controllers
{

    [Authorize]
    public class AthletesController : Controller
    {
        private readonly CanadaGamesContext _context;

        public AthletesController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Athletes
        public async Task<IActionResult> Index(string SearchString, string MediaSearchString, int? CoachID, int? ContingentID, int? SportID, int? GenderID, int? page, int? pageSizeID,
            string actionButton, string sortDirection = "asc", string sortField = "Athlete")
        {
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            string[] sortOptions = new[] { "Athlete", "Hometown", "Age", "Sport"};

            PopulateDropDownLists();

            var athletes = from a in _context.Athletes.Include(a => a.AthleteThumbnail).Include(a => a.AthleteDocuments).Include(a => a.Coach).Include(a => a.Sport).Include(a => a.Gender).Include(a => a.Hometown).Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                select a;

            if (CoachID.HasValue)
            {
                athletes = athletes.Where(a => a.CoachID == CoachID);
            }
            if (SportID.HasValue)
            {
                athletes = athletes.Where(a => a.SportID == SportID);
            }
            if (GenderID.HasValue)
            {
                athletes = athletes.Where(a => a.GenderID == GenderID);
            }


            if (!String.IsNullOrEmpty(SearchString))
            {
                athletes = athletes.Where(a => a.LastName.ToUpper().Contains(SearchString.ToUpper())
                                        || a.FirstName.ToUpper().Contains(SearchString.ToUpper()));
            }
            if (!String.IsNullOrEmpty(MediaSearchString))
            {
                athletes = athletes.Where(a => a.MediaInfo.ToUpper().Contains(MediaSearchString.ToUpper()));
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

            if (sortField == "Sport")
            {
                if (sortDirection == "asc")
                {
                    athletes = athletes.OrderBy(a => a.Sport.Name);
                }
                else
                {
                    athletes = athletes.OrderByDescending(a => a.Sport.Name);
                }
            }

            else if (sortField == "Hometown")
            {
                if (sortDirection == "asc")
                {
                    athletes = athletes.OrderBy(a => a.Hometown.Name);
                }
                else
                {
                    athletes = athletes.OrderByDescending(a => a.Hometown.Name);
                }
            }
            else if (sortField == "Age")
            {
                if (sortDirection == "asc")
                {
                    athletes = athletes.OrderByDescending(a => a.DOB);
                }
                else
                {
                    athletes = athletes.OrderBy(a => a.DOB);
                }
            }

            else if (sortField == "Athlete")
            {
                if (sortDirection == "asc")
                {
                    athletes = athletes.OrderBy(a => a.LastName)
                                        .ThenBy(a => a.FirstName);
                }
                else
                {
                    athletes = athletes.OrderByDescending(a => a.LastName)
                                                  .ThenBy(a => a.FirstName);
                }
            }

            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Athlete>.CreateAsync(athletes.AsNoTracking(), page ?? 1, pageSize);

            ViewDataReturnURL();

            return View(pagedData);


        }

        // GET: Athletes/Details/5
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .Include(a => a.AthletePhoto)
                .Include(a => a.Coach)
                .Include(a => a.Contingent)
                .Include(a => a.Hometown)
                .Include(a => a.Gender)
                .Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // GET: Athletes/Create
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public IActionResult Create()
        {
            PopulateDropDownLists();
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code");
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Code");
            ViewData["SportID"] = new SelectList(_context.Sports, "ID", "Code");
            ViewData["HometownID"] = new SelectList(_context.Hometowns, "ID", "Name");

            ViewDataReturnURL();

            return View();
        }

        // POST: Athletes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor,Staff")]
        public async Task<IActionResult> Create([Bind("ID,AthleteCode,FirstName,MiddleName,LastName,DOB,HometownID,Height,Weight,YearsInSport,Affiliation,Goals,Position,RoleModel,MediaInfo,ContingentID,SportID,GenderID,CoachID")] Athlete athlete,
            string[] selectedOptions, List<IFormFile> theFiles, List<IFormFile> thePicture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await AddPicture(athlete, thePicture.FirstOrDefault());
                    await AddDocumentsAsync(athlete, theFiles);
                    _context.Add(athlete);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "AthletePlacements", new { AthleteID = athlete.ID});
                }
                PopulateDropDownLists(athlete);
                ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", athlete.ContingentID);
                ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Code", athlete.GenderID);
                ViewData["SportID"] = new SelectList(_context.Sports, "ID", "Code", athlete.SportID);
                ViewData["HometownID"] = new SelectList(_context.Hometowns, "ID", "Name", athlete.HometownID);
                return View(athlete);
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE contraint failed: Athletes"))
                {
                    ModelState.AddModelError("AthleteCode", "Unable to save changes. remember, you can not have two athletes with the same code");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again");
                }
            }

            PopulateDropDownLists(athlete);

            ViewDataReturnURL();

            return RedirectToAction("Details", new { athlete.ID });
        }

        // GET: Athletes/Edit/5
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int? id, List<IFormFile> theFiles)
        {

            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .Include(a => a.AthletePhoto)
                .Include(a => a.AthleteDocuments)
                .Include(a => a.Coach)
                .Include(a => a.Contingent)
                .Include(a => a.Hometown)
                .Include(a => a.Gender)
                .Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (athlete == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(athlete);
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", athlete.ContingentID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Code", athlete.GenderID);
            ViewData["SportID"] = new SelectList(_context.Sports, "ID", "Code", athlete.SportID);
            ViewData["HometownID"] = new SelectList(_context.Hometowns, "ID", "Name", athlete.HometownID);

            ViewDataReturnURL();

            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AthleteCode,FirstName,MiddleName,LastName,HometownID,DOB,Height,Weight,YearsInSport,Affiliation,Goals,Position,RoleModel,MediaInfo,ContingentID,SportID,GenderID,CoachID")] Athlete athlete,
            List<IFormFile> theFiles, string chkRemoveImage, IFormFile thePicture)
        {
            ViewDataReturnURL();

            var athleteToUpdate = await _context.Athletes
                .Include(a => a.AthletePhoto)
                .Include(a => a.AthleteDocuments)
                .Include(a => a.Coach)
                .Include(a => a.Contingent)
                .Include(a => a.Hometown)
                .Include(a => a.Gender)
                .Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (!User.IsInRole("Supervisor"))
            {
                    return Redirect(ViewData["returnURL"].ToString());
            }

            if (athleteToUpdate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                
                {
                    if (chkRemoveImage != null)
                    {
                        athleteToUpdate.AthleteThumbnail = _context.AthleteThumbnails.Where(p => p.AthleteID == athleteToUpdate.ID).FirstOrDefault();
                        athleteToUpdate.AthletePhoto = null;
                        athleteToUpdate.AthleteThumbnail = null;
                    }
                    else
                    {
                        await AddPicture(athleteToUpdate, thePicture);
                    }

                    await AddDocumentsAsync(athleteToUpdate, theFiles);
                    _context.Update(athleteToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteExists(athleteToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "AthletePlacements", new { AthleteID = athleteToUpdate.ID });
            }
            PopulateDropDownLists(athlete);
            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code", athlete.ContingentID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Code", athlete.GenderID);
            ViewData["SportID"] = new SelectList(_context.Sports, "ID", "Code", athlete.SportID);
            ViewData["HometownID"] = new SelectList(_context.Hometowns, "ID", "Name", athlete.HometownID);

            ViewDataReturnURL();

            return View();
        }

        // GET: Athletes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .Include(a => a.Coach)
                .Include(a => a.Contingent)
                .Include(a => a.Gender)
                .Include(a => a.Hometown)
                .Include(a => a.AthleteSports).ThenInclude(a => a.Sport)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (athlete == null)
            {
                return NotFound();
            }

            ViewDataReturnURL();

            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Athletes");
        }


        public IActionResult PlacementReport()
        {
            var sumQ = _context.Placements.Include(a => a.Athlete)
                .GroupBy(a => new { a.AthleteID, a.Athlete.LastName, a.Athlete.FirstName, a.Athlete.MiddleName, a.Athlete.Contingent.Code })
                .Select(grp => new PlacementReport
                {
                    ID = grp.Key.AthleteID,
                    FirstName = grp.Key.FirstName,
                    MiddleName = grp.Key.MiddleName,
                    LastName = grp.Key.LastName,
                    Contingent = grp.Key.Code,
                    AveragePlacement = Convert.ToInt32(grp.Average(a => a.Place)),
                    HighestPlacement = grp.Max(a => a.Place),
                    LowestPlacement = grp.Min(a => a.Place),
                    EventCount = grp.Count()
                });

            ViewData["ContingentID"] = new SelectList(_context.Contingents, "ID", "Code");
            return View(sumQ.AsNoTracking().ToList());
        }
        #region Select Lists
        private SelectList CoachSelectList(int? selectedId)
        {
            return new SelectList(_context.Coaches
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName), "ID", "FullName", selectedId);
        }
        private SelectList ContingentSelectList(int? selectedId)
        {
            return new SelectList(_context.Contingents
                .OrderBy(c => c.Name), "ID", "Name", selectedId);
        }
        private SelectList GenderSelectList(int? selectedId)
        {
            return new SelectList(_context.Genders
                .OrderBy(c => c.Name), "ID", "Name", selectedId);
        }
        private SelectList SportSelectList(int? selectedId)
        {
            return new SelectList(_context.Sports
                .OrderBy(c => c.Name), "ID", "Name", selectedId);
        }

        private SelectList HometownSelectList(int? selectedId)
        {
            return new SelectList(_context.Hometowns
                .OrderBy(c => c.Name), "ID", "Name", selectedId);
        }
        #endregion
        private void PopulateDropDownLists(Athlete athlete = null)
        {
            ViewData["CoachID"] = CoachSelectList(athlete?.CoachID);
            ViewData["ContingentID"] = ContingentSelectList(athlete?.ContingentID);
            ViewData["GenderID"] = GenderSelectList(athlete?.GenderID);
            ViewData["SportID"] = SportSelectList(athlete?.SportID);
            ViewData["HometownID"] = HometownSelectList(athlete?.HometownID);

        }
        private bool AthleteExists(int id)
        {
            return _context.Athletes.Any(e => e.ID == id);
        }
        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }

        private async Task AddPicture(Athlete Athlete, IFormFile thePicture)
        {
            //Get the picture and save it with the Athlete (2 sizes)
            if (thePicture != null)
            {
                string mimeType = thePicture.ContentType;
                long fileLength = thePicture.Length;
                if (!(mimeType == "" || fileLength == 0))
                {
                    if (mimeType.Contains("image"))
                    {
                        using var memoryStream = new MemoryStream();
                        await thePicture.CopyToAsync(memoryStream);
                        var pictureArray = memoryStream.ToArray();//Gives us the Byte[]

                        //Check if we are replacing or creating new
                        if (Athlete.AthletePhoto != null)
                        {
                            //We already have pictures so just replace the Byte[]
                            Athlete.AthletePhoto.Content = ResizeImage.shrinkImageWebp(pictureArray, 500, 600);

                            //Get the Thumbnail so we can update it.  Remember we didn't include it
                            Athlete.AthleteThumbnail = _context.AthleteThumbnails.Where(p => p.AthleteID == Athlete.ID).FirstOrDefault();
                            Athlete.AthleteThumbnail.Content = ResizeImage.shrinkImageWebp(pictureArray, 100, 120);
                        }
                        else 
                        {
                            Athlete.AthletePhoto = new AthletePhoto
                            {
                                Content = ResizeImage.shrinkImageWebp(pictureArray, 500, 600),
                                MimeType = "image/webp"
                            };
                            Athlete.AthleteThumbnail = new AthleteThumbnail
                            {
                                Content = ResizeImage.shrinkImageWebp(pictureArray, 100, 120),
                                MimeType = "image/webp"
                            };
                        }
                    }
                }
            }
        }

        public async Task<FileContentResult> Download(int id)
        {
            var theFile = await _context.UploadedFiles
                .Include(d => d.FileContent)
                .Where(f => f.ID == id)
                .FirstOrDefaultAsync();
            return File(theFile.FileContent.Content, theFile.FileContent.MimeType, theFile.FileName);
        }
        private async Task AddDocumentsAsync(Athlete athlete, List<IFormFile> theFiles)
        {
            foreach (var f in theFiles)
            {
                if (f != null)
                {
                    string mimeType = f.ContentType;
                    string fileName = Path.GetFileName(f.FileName);
                    long fileLength = f.Length;

                    if (!(fileName == "" || fileLength == 0))
                    {
                        AthleteDocument a = new AthleteDocument();
                        using (var memoryStream = new MemoryStream())
                        {
                            await f.CopyToAsync(memoryStream);
                            a.FileContent.Content = memoryStream.ToArray();
                        }
                        a.FileContent.MimeType = mimeType;
                        a.FileName = fileName;
                        athlete.AthleteDocuments.Add(a);
                    };
                }
            }
        }



        [Authorize(Roles = "Admin")]
        public IActionResult DownloadPlacements(int? ContingentID)
        {
            var athletes = from a in _context.Athletes.Include(a => a.Placements)
                           orderby a.Placements.Count() descending
                           select new
                           {
                               Athlete = a.FormalName,
                               Contingent = a.Contingent.Code,                             
                               AveragePlacement = Convert.ToInt32(a.Placements.DefaultIfEmpty().Average(p => p.Place)),
                               HighestPlacement = a.Placements.DefaultIfEmpty().Max(p => p.Place),
                               LowestPlacement = a.Placements.DefaultIfEmpty().Min(p => p.Place),
                               EventCount = a.Placements.Count(),
                               MediaInfo = "Info",
                               a.ContingentID
                           };

           

            var athleteMedia = from a in _context.Athletes.Include(a => a.Placements)
                               orderby a.Placements.Count() descending
                               select new
                               {
                                   a.ContingentID,
                                   a.MediaInfo
                               };

            string contCode = "All";

            if (ContingentID.HasValue)
            {
                athletes = athletes.Where(a => a.ContingentID == ContingentID);
                athleteMedia = athleteMedia.Where(a => a.ContingentID == ContingentID);

                //File name changes based on contingent selection
                contCode = _context.Contingents.Where(c => c.ID == ContingentID).FirstOrDefault().Code;
            }
            int numRows = athletes.Count();

            if (numRows > 0)
            {
                using (ExcelPackage excel = new ExcelPackage())
                {


                    var workSheet = excel.Workbook.Worksheets.Add("Placements");

                    workSheet.Cells[3, 1].LoadFromCollection(athletes, true);

                    workSheet.Cells[4, 1, numRows + 5, 2].Style.Font.Bold = true;
                    
                    int i = 0;
                    foreach(var a in athleteMedia)
                    {
                        workSheet.Cells[4 + i, 7, 4 + i, 7].AddComment(a.MediaInfo, "REF");
                        i++;
                    }

                    using (ExcelRange headings = workSheet.Cells[3, 1, 3, 7])
                    {
                        headings.Style.Font.Bold = true;
                        var fill = headings.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.LightBlue);
                    }

                    workSheet.Cells.AutoFitColumns();

                    workSheet.Cells[1, 1].Value = "Placement Report";

                    workSheet.Cells[numRows + 4, 1].Value = "Total Athletes";

                    workSheet.Cells[numRows + 4, 2].Value = athletes.Count();

                    workSheet.Cells[numRows + 5, 1].Value = "Total Events";

                    workSheet.Cells[numRows + 5, 2].Value = athletes.Sum(a => a.EventCount);

                    workSheet.Cells[3, 8, numRows + 3, 8].Value = "";

                    using (ExcelRange Rng = workSheet.Cells[1, 1, 1, 6])
                    {
                        Rng.Merge = true;
                        Rng.Style.Font.Bold = true;
                        Rng.Style.Font.Size = 18;
                        Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    DateTime utcDate = DateTime.UtcNow;
                    TimeZoneInfo esTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime localDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, esTimeZone);
                    using (ExcelRange Rng = workSheet.Cells[2, 7])
                    {
                        Rng.Value = "Created: " + localDate.ToShortTimeString() + " on " +
                            localDate.ToShortDateString();
                        Rng.Style.Font.Bold = true;
                        Rng.Style.Font.Size = 12;
                        Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }


                    var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
                    if (syncIOFeature != null)
                    {
                        syncIOFeature.AllowSynchronousIO = true;
                        using (var memoryStream = new MemoryStream())
                        {
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.Headers["content-disposition"] = "attachment;  filename=Placements-" + contCode + ".xlsx";
                            excel.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.Body);
                        }
                    }
                    else
                    {
                        try
                        {
                            Byte[] theData = excel.GetAsByteArray();
                            string filename = "Placements-" + contCode + ".xlsx";
                            string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            return File(theData, mimeType, filename);
                        }
                        catch (Exception)
                        {
                            return NotFound();
                        }
                    }
                }
            }
            return NotFound();
        }

    }
}
