using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vikings_2.Data;
using Vikings_2.Models;

namespace Vikings_2.Controllers
{
    public class PreviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Preview
        public async Task<IActionResult> Index(int id)
        {
            List<Preview> previewsList = await (from preview in _context.Previews
                                                join pat in _context.Patients
                                                on preview.Patient_Id equals pat.Patient_Id
                                                into PatientPreviews
                                                from sub in PatientPreviews.DefaultIfEmpty()
                                                where preview.Patient_Id == id
                                                select new Preview
                                                {
                                                    Preview_Id = preview.Preview_Id,
                                                    Patient_Id = id,
                                                    Preview_Date = preview.Preview_Date
                                                }).ToListAsync();

            return View(previewsList);

            //public async Task<IActionResult> Index(int categoryId)
            //{

            //    List<CategoryItem> list = await (from catItem in _context.CategoryItem
            //                                     join contentItem in _context.Content
            //                                     on catItem.Id equals contentItem.CategoryItem.Id
            //                                     into gj
            //                                     from subContent in gj.DefaultIfEmpty()
            //                                     where catItem.CategoryId == categoryId
            //                                     select new CategoryItem
            //                                     {
            //                                         Id = catItem.Id,
            //                                         Title = catItem.Title,
            //                                         Description = catItem.Description,
            //                                         DateTimeItemReleased = catItem.DateTimeItemReleased,
            //                                         MediaTypeId = catItem.MediaTypeId,
            //                                         CategoryId = categoryId,
            //                                         ContentId = (subContent != null) ? subContent.Id : 0

            //                                     }).ToListAsync();


            //    ViewBag.CategoryId = categoryId;

            //    return View(list);
            //}
        }

        // GET: Preview/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preview = await _context.Previews
                .FirstOrDefaultAsync(m => m.Preview_Id == id);
            if (preview == null)
            {
                return NotFound();
            }

            return View(preview);
        }

        // GET: Preview/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Preview/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preview_Id,Preview_Date,Patient_Id")] Preview preview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preview);
        }

        // GET: Preview/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preview = await _context.Previews.FindAsync(id);
            if (preview == null)
            {
                return NotFound();
            }
            return View(preview);
        }

        // POST: Preview/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preview_Id,Preview_Date,Patient_Id")] Preview preview)
        {
            if (id != preview.Preview_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreviewExists(preview.Preview_Id))
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
            return View(preview);
        }

        // GET: Preview/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preview = await _context.Previews
                .FirstOrDefaultAsync(m => m.Preview_Id == id);
            if (preview == null)
            {
                return NotFound();
            }

            return View(preview);
        }

        // POST: Preview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preview = await _context.Previews.FindAsync(id);
            _context.Previews.Remove(preview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreviewExists(int id)
        {
            return _context.Previews.Any(e => e.Preview_Id == id);
        }
    }
}
