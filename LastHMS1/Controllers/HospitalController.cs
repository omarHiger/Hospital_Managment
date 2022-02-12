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
    public class HospitalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HospitalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Hospitals.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital =  _context.Hospitals
                .FirstOrDefault(m => m.Ho_Id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }
        public IActionResult Create(int id)
        {
            Hospital hospital = new Hospital()
            {
                Ho_Mge_Id = id,
                Ho_Subscribtion_Date = DateTime.Now
            };
            return View(hospital);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hospital hospital)
        {

            if (ModelState.IsValid)
            {
                hospital.Manager = _context.Doctors.Find(hospital.Ho_Mge_Id);
                
                _context.Add(hospital);
                _context.SaveChanges();
                return RedirectToAction("LogInHoMgr","Doctor",new {id=hospital.Ho_Id });
            }
            return View(hospital);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital =  _context.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Hospital hospital)
        {
            if (id != hospital.Ho_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalExists(hospital.Ho_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Master","Admin");
            }
            return View(hospital);
        }

       
        public  IActionResult  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital =  _context.Hospitals
                .FirstOrDefault(m => m.Ho_Id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hospital =  _context.Hospitals.Find(id);
            _context.Doctors.Remove(_context.Doctors.Find(hospital.Manager.Doctor_Id));
            _context.Hospitals.Remove(hospital);
             _context.SaveChanges();
            return RedirectToAction("Master","Admin");
        }

        private bool HospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.Ho_Id == id);
        }
    }
}
