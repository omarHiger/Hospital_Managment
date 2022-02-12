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
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********************************************************
        public IActionResult DoctorIndex(int? id) // display doctor's patients by passing the doctor's Id .... 
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctor = _context.Doctors.FirstOrDefault(m => m.Doctor_Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            var patients = (from p in _context.Patients
                            join c in _context.Carings
                            on p.Patient_Id equals c.Patient_Id
                            where c.Doctor_Id == doctor.Doctor_Id
                            select p).ToList();
            ViewBag.DoctorId = id;
            return View(patients);
        }
        public IActionResult DisplayPatients(int id)
        {
            var patients = (from p in _context.Patients
                            join c in _context.Carings
                            on p.Patient_Id equals c.Patient_Id into AllPatients
                            from allpat in AllPatients.DefaultIfEmpty()
                            where allpat.Doctor_Id != id
                            select p).ToList();
            ViewBag.DoctorId = id;
            return View(patients);
        }

        public IActionResult HoPatients(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Ho_Id == id);
            if (hospital != null) return NotFound();
            var patients = _context.Patients.Where(p => p.Ho_Id == hospital.Ho_Id).ToList();
            ViewBag.HospitalId = hospital.Ho_Id;
            return View(patients);
        }
        //***********************************************************
        // GET: Patient

        public IActionResult Index()
        {
            return View( _context.Patients.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient =  _context.Patients
                .FirstOrDefault(m => m.Patient_Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        public IActionResult Create(int id)
        {
            Patient p = new Patient()
            {
                Ho_Id = id,
                Patient_Email = "mmmmmmmmmmmmmmmmm",
                Patient_Password = "mmmmmmmmmmmmmmm"
            };
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Patient_Email = patient.Patient_EmailName.Replace(" ","_"); // Name in english
                patient.Patient_Password = patient.Patient_National_Number;
                _context.Add(patient);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient =  _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Patient patient)
        {
            if (id != patient.Patient_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Patient_Id))
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
            return View(patient);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient =  _context.Patients
                .FirstOrDefault(m => m.Patient_Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient =  _context.Patients.Find(id);
            _context.Patients.Remove(patient);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Patient_Id == id);
        }
    }
}
