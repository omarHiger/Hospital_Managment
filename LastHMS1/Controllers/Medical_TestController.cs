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
    public class Medical_TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Medical_TestController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public IActionResult Index()
        {
            return View( _context.Medical_Tests.ToList());
        }

       
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_Test =  _context.Medical_Tests
                .FirstOrDefault(m => m.Test_Id == id);
            if (medical_Test == null)
            {
                return NotFound();
            }

            return View(medical_Test);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Medical_Test medical_Test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medical_Test);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medical_Test);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_Test =  _context.Medical_Tests.Find(id);
            if (medical_Test == null)
            {
                return NotFound();
            }
            return View(medical_Test);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Medical_Test medical_Test)
        {
            if (id != medical_Test.Test_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical_Test);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Medical_TestExists(medical_Test.Test_Id))
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
            return View(medical_Test);
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_Test =  _context.Medical_Tests
                .FirstOrDefault(m => m.Test_Id == id);
            if (medical_Test == null)
            {
                return NotFound();
            }

            return View(medical_Test);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medical_Test =  _context.Medical_Tests.Find(id);
            _context.Medical_Tests.Remove(medical_Test);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool Medical_TestExists(int id)
        {
            return _context.Medical_Tests.Any(e => e.Test_Id == id);
        }
    }
}
