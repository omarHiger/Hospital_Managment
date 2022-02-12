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
    public class RayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RayController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Rays.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ray =  _context.Rays
                .FirstOrDefault(m => m.Ray_Id == id);
            if (ray == null)
            {
                return NotFound();
            }

            return View(ray);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Ray ray)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ray);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ray);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ray =  _context.Rays.Find(id);
            if (ray == null)
            {
                return NotFound();
            }
            return View(ray);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Ray ray)
        {
            if (id != ray.Ray_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ray);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RayExists(ray.Ray_Id))
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
            return View(ray);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ray =  _context.Rays
                .FirstOrDefault(m => m.Ray_Id == id);
            if (ray == null)
            {
                return NotFound();
            }

            return View(ray);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ray = _context.Rays.Find(id);
            _context.Rays.Remove(ray);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RayExists(int id)
        {
            return _context.Rays.Any(e => e.Ray_Id == id);
        }
    }
}
