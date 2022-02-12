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
    public class SurgeryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurgeryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Surgeries.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery =  _context.Surgeries
                .FirstOrDefault(m => m.Surgery_Number == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        // GET: Surgery/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Surgery surgery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surgery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(surgery);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery =  _context.Surgeries.Find(id);
            if (surgery == null)
            {
                return NotFound();
            }
            return View(surgery);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Surgery surgery)
        {
            if (id != surgery.Surgery_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surgery);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurgeryExists(surgery.Surgery_Number))
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
            return View(surgery);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery =  _context.Surgeries
                .FirstOrDefault(m => m.Surgery_Number == id);
            if (surgery == null)
            {
                return NotFound();
            }

            return View(surgery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var surgery =_context.Surgeries.Find(id);
            _context.Surgeries.Remove(surgery);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SurgeryExists(int id)
        {
            return _context.Surgeries.Any(e => e.Surgery_Number == id);
        }
    }
}
