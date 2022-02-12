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
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********************************************************

        public IActionResult Master(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _context.Employees.FirstOrDefault(e => e.Employee_Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            if (employee.Employee_Job == "IT") return RedirectToAction("IT", new { id = id });
            if (employee.Employee_Job == "Resception") return RedirectToAction("Resception", new { id = id });
            if (employee.Employee_Job == "Nurse") return RedirectToAction("Nurse", new { id = id });

            return NotFound();
        }
        // in view onclick (إضافة غرفة) ==> /Rooms/Create/@Model.Ho_Id 
        // in view onclick (عرض الأقسام) ==> /Department/HoDepartments/Model.Ho_Id
        // in view onclick (إضافة موظف استقبال) ==> /Employee/CreateResception/Model.Ho_Id done
        // in view onclick (استعراض رؤساء الأقسام ) ==> /Doctor/DeptManagers/@Model.Doctor_Id  done
        // discuss omar about deleting it b4 the interview
        public IActionResult IT(int id)
        {
            var IT = _context.Employees.Find(id);
            if (IT == null) return NotFound();
            return View(IT);
        }
        // in view onclick (إلغاء حجز غرفة) ==> /Room/BusyRooms/@Model.Ho_Id //محجوزة done
        // in view onclick (حجز غرفة) ==> /Room/AvailableRooms/@Model.Ho_Id done
        // in view onclick (عرض الأطباء) ==> /Doctor/HoDoctors/@Model.Ho_Id  // From caring done
        // in view onclick (عرض المرضى) ==> /Patient/HoPatients/@Model.Ho_Id  // From caring done
        // in view onclick (حجز موعد للمريض) ==> /Patient/HoPatients/@Model.Ho_Id  // From caring deleted
        // in view onclick (تسجيل مريض) ==> /Patient/Create/@Model.Ho_Id  // From caring done
        public IActionResult Resception(int id)
        {
            var Resception = _context.Employees.Find(id);
            if (Resception == null) return NotFound();
            ViewBag.HospitalName = _context.Hospitals.Find(Resception.Ho_Id).Ho_Name;

            return View(Resception);
        }

        public IActionResult HoEmployees(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Manager.Doctor_Id == id);
            var Employees = _context.Employees.Where(e => e.Ho_Id == hospital.Ho_Id && (e.Employee_Job == "Resception" || e.Employee_Job == "IT"));
            ViewBag.HospitalId = hospital.Ho_Id;
            return View(Employees);
        }
        public IActionResult CreateEmp(int id)
        {
            Employee emp = new Employee()
            {
                Ho_Id = id
            };
            return View(emp);
        }

        public IActionResult LogInIT()
        {
            var hospitals = _context.Hospitals.ToList();
            return View(hospitals);
        }
        public IActionResult LogInResception()
        {
            var hospitals = _context.Hospitals.ToList();
            return View(hospitals);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(IFormCollection fr)
        {
            var employees = _context.Employees.Where(d => d.Employee_Email == fr["email"].ToString() && d.Employee_Password == fr["password"].ToString()).ToList();
            if (employees == null) return NotFound();
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Ho_Id == int.Parse(fr["hospital"]));
            if (hospital == null) return NotFound();
            foreach (Employee employee in employees)
            {
                return RedirectToAction("Master", new { id = employee.Employee_Id });
            }
            return NotFound();
        }

        //***********************************************************
        // GET: Employee

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

       
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.Employee_Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Employee_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Employee_Id))
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
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.Employee_Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee =  _context.Employees.Find(id);
            _context.Employees.Remove(employee);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Employee_Id == id);
        }
    }
}
