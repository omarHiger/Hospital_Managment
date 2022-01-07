using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViKings_1.Class_Attriputes;
using ViKings_1.Data;
using ViKings_1.Models;

namespace ViKings_1.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Patient> patients = _context.Patients.ToList();
            return View(patients);
        }     
        [HttpGet]

        public IActionResult Create()
        {
            Patient patient = new Patient();
            patient.Patient_Phone_Numbers.Add(new Patient_Phone_Numbers() { Id = 1 });
            //patient.Patient_Phone_Numbers.Add(new Patient_Phone_Numbers() { Id = 2 });
            //patient.Patient_Phone_Numbers.Add(new Patient_Phone_Numbers() { Id = 3 });
            return View(patient);
        }  
        [HttpPost]

        public IActionResult Create(Patient patient)
        {
            foreach(Patient_Phone_Numbers pn in patient.Patient_Phone_Numbers)
            {
                if(pn.Patient_Phone_Number==null || pn.Patient_Phone_Number.Length==0)
                        patient.Patient_Phone_Numbers.Remove(pn);
            }
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
