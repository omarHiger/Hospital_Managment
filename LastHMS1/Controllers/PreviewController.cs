using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastHMS1.Data;
using LastHMS1.Models;

namespace LastHMS1.Controllers
{
    public class PreviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Previews.ToList());
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preview =  _context.Previews
                .FirstOrDefault(m => m.Preview_Id == id);
            if (preview == null)
            {
                return NotFound();
            }

            return View(preview);
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Preview preview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preview);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(preview);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preview =  _context.Previews.Find(id);
            if (preview == null)
            {
                return NotFound();
            }
            return View(preview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Preview preview)
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
                     _context.SaveChanges();
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
