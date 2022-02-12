using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastHMS1.Data;
using LastHMS1.Models;
using Microsoft.AspNetCore.Http;

namespace LastHMS1.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********************************************************

        // GET: /Doctor/Master/5
        // in view onclick (إلغاء حجز غرفة) ==> /Surgery_Room/DoctorIndex/Model.Doctor_Id
        // in view onclick (حجز غرفة عمليات) ==> /Surgery_Room/Create/Model.Doctor_Id
        // in view onclick (حجز موعد ) ==> /Preview/Create/Model.Doctor_Id
        // in view onclick (المرضى) ==> /Patient/DoctorIndex/Model.Doctor_Id
        public IActionResult Master(int? id)
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

            var Department = _context.Departments.FirstOrDefault(m => m.Dept_Manager.Doctor_Id == doctor.Doctor_Id);
            if (Department != null)
            {
                return RedirectToAction("MasterDeptMgr", new { id = id });
            }

            //var doctorPreviews = doctor.Doctor_Previews;

            var doctorPreviews = (from previews in _context.Previews
                                  join doctors in _context.Doctors
                                  on previews.Doctor_Id equals doctor.Doctor_Id
                                  select previews).ToList();

            ViewBag.DoctorName = doctor.Doctor_First_Name + " " + doctor.Doctor_Last_Name;
            ViewBag.DoctorId = doctor.Doctor_Id;
            return View(doctorPreviews);
        }
        // Doctor + 
        // in view on click (أطباء) ==> /Doctor/DisplayDoctrosByDeptId/@Model.DoctorId      done
        // in view on click (إستعراض دوام الأطباء) ==> /Work_days/DisplayDoctroDays/@Model.DoctorId
        public IActionResult MasterDeptMgr(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(m => m.Doctor_Id == id);
            var doctorPreviews = (from previews in _context.Previews
                                  join doctors in _context.Doctors
                                  on previews.Doctor_Id equals doctor.Doctor_Id
                                  select previews).ToList();
            ViewBag.DeptMgrName = doctor.Doctor_First_Name + " " + doctor.Doctor_Last_Name;
            ViewBag.DeptMgrId = doctor.Doctor_Id;
            return View(doctorPreviews);
        }
        public IActionResult DisplayDoctrosByDeptId(int id)
        {
            var Deptmanager = _context.Doctors.FirstOrDefault(d => d.Doctor_Id == id);
            var doctors = _context.Doctors.Where(d => d.Department_Id == Deptmanager.Department_Id);
            if (doctors == null) return Ok("this deprtment is empty !!");
            ViewBag.DeptId = Deptmanager.Department_Id;
            return View(doctors);
        }
      
        // in view onclick (استعراض التقارير ) ==> wtf 
        // in view onclick (استعراض الموضفين  ) ==> /Employee/HoEmployees/@Model.Doctor_Id done // IT/Resception
        public IActionResult MasterHoMgr(int? id)
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
            var Hospital = _context.Hospitals.FirstOrDefault(m => m.Manager.Doctor_Id == doctor.Doctor_Id);
            if (Hospital == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult HoDoctors(int id)
        { // تفاصيل عامة ===> ساعات الدوام 
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Ho_Id == id);
            var departments = _context.Departments.Where(d => d.Ho_Id == hospital.Ho_Id).ToList();
            var doctors = (from d in _context.Doctors.ToList()
                           join dept in departments
                           on d.Department_Id equals dept.Department_Id
                           select d).ToList();


            return View(doctors);
        }
        public IActionResult DeptManagers(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Manager.Doctor_Id == id);
            var departments = _context.Departments.Where(d => d.Ho_Id == hospital.Ho_Id);
            var deptManagers = departments.Select(d => d.Dept_Manager).ToList();
            ViewBag.HospitalId = hospital.Ho_Id;
            return View(deptManagers);
        }

        public IActionResult LogIn()
        {
            var hospitals = _context.Hospitals.ToList();
            return View(hospitals);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(IFormCollection fr)
        {
            var doctors = _context.Doctors.Where(d => d.Doctor_Email == fr["email"].ToString() && d.Doctor_Password == fr["password"].ToString()).ToList();
            if (doctors == null) return NotFound();
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Ho_Id == int.Parse(fr["hospital"]));
            foreach (Doctor doctor in doctors)
            {
                var department = _context.Departments.FirstOrDefault(d => d.Ho_Id == hospital.Ho_Id && d.Department_Id == doctor.Department_Id);
                if (department == null) return NotFound();
                return RedirectToAction("Master", new { id = doctor.Doctor_Id });
            }
            return NotFound();

        }
        public IActionResult LogInHoMgr()
        {
            var hospitals = _context.Hospitals.ToList();
            return View(hospitals);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogInHoMgr(IFormCollection fr)
        {
            var doctors = _context.Doctors.Where(d => d.Doctor_Email == fr["email"].ToString() && d.Doctor_Password == fr["password"].ToString()).ToList();
            if (doctors == null) return NotFound();
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Ho_Id == int.Parse(fr["hospital"]));
            if (hospital == null) return NotFound();
            var doc = doctors.FirstOrDefault(d => hospital.Manager.Doctor_Id == d.Doctor_Id);
            if (doc == null) return NotFound();
            return RedirectToAction("MasterHoMgr", new { id = doc.Doctor_Id });
        }
        public IActionResult CreateDeptManager(int id)
        {
            Doctor d = new Doctor()
            {
                Doctor_Email = "mmmmmmmmmm",
                Doctor_Password = "mmmmmmmmmmmmmmm",
                Doctor_Hire_Date = DateTime.Now
            };
            var departments = _context.Departments.Where(d => d.Ho_Id == id).Select(d => new { Id = d.Department_Id, Name = d.Department_Name }).ToList();
            ViewBag.Departments = departments;
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeptManager(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Doctor_Email = doctor.Doctor_EmailName.Replace(" ", "_");
                doctor.Doctor_Password = doctor.Doctor_National_Number;
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Hospital", new { id = doctor.Doctor_Id });
            }
            return View(doctor);
        }
        public IActionResult CreateManager()
        {
            Doctor mgr = new Doctor()
            {
                Department_Id = null ,
                Doctor_Email = "mmmmmmmmmm",
                Doctor_Password = "mmmmmmmmmmmmmmm",
                Doctor_Hire_Date = DateTime.Now
            };
            return View(mgr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult CreateManager(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Doctor_Email = doctor.Doctor_EmailName.Replace(" ", "_");
                doctor.Doctor_Password = doctor.Doctor_National_Number;
                _context.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Create", "Hospital", new { id = doctor.Doctor_Id });
            }
            return View(doctor);
        }

        //***********************************************************


        public IActionResult Index()
        {
            return View( _context.Doctors.ToList());
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _context.Doctors
                .FirstOrDefault(m => m.Doctor_Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
        public IActionResult Create(int id)
        {
            Doctor d = new Doctor()
            {
                Department_Id = id,
                Doctor_Email = "mmmmmmmmmm",
                Doctor_Password = "mmmmmmmmmmmmmmm",
                Doctor_Hire_Date = DateTime.Now
            };
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Doctor_Email = doctor.Doctor_EmailName.Replace(" ", "_");
                doctor.Doctor_Password = doctor.Doctor_National_Number;
                _context.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor =  _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Doctor doctor)
        {
            if (id != doctor.Doctor_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Doctor_Id))
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
            return View(doctor);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _context.Doctors
                .FirstOrDefault(m => m.Doctor_Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctors.Find(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Doctor_Id == id);
        }
    }
}
