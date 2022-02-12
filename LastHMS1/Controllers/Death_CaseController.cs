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
    public class Death_CaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Death_CaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Death_Cases.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var death_Case =  _context.Death_Cases
                .FirstOrDefault(m => m.Death_Case_Number == id);
            if (death_Case == null)
            {
                return NotFound();
            }

            return View(death_Case);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Death_Case death_Case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(death_Case);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(death_Case);
        }

        // GET: Death_Case/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var death_Case =  _context.Death_Cases.Find(id);
            if (death_Case == null)
            {
                return NotFound();
            }
            return View(death_Case);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Death_Case death_Case)
        {
            if (id != death_Case.Death_Case_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(death_Case);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Death_CaseExists(death_Case.Death_Case_Number))
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
            return View(death_Case);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var death_Case =  _context.Death_Cases
                .FirstOrDefault(m => m.Death_Case_Number == id);
            if (death_Case == null)
            {
                return NotFound();
            }

            return View(death_Case);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var death_Case =  _context.Death_Cases.Find(id);
            _context.Death_Cases.Remove(death_Case);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool Death_CaseExists(int id)
        {
            return _context.Death_Cases.Any(e => e.Death_Case_Number == id);
        }
    }
}
