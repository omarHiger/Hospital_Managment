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
    public class Surgery_RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Surgery_RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********************************************************
        public IActionResult DoctorIndex(int? id) // display doctor's Surgeries by passing the doctor's Id .... 
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
            var surgery_rooms = (from sr in _context.Surgery_Rooms.ToList()
                                 join s in doctor.Doctor_Surgeries
                                 on sr.Surgery_Room_Id equals s.Doctor_Id
                                 select sr).ToList(); // لازم المحجوزة
            return View(surgery_rooms);
        }

        //***********************************************************

        public IActionResult Index()
        {
            return View( _context.Surgery_Rooms.ToList());
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery_Room =  _context.Surgery_Rooms
                .FirstOrDefault(m => m.Surgery_Room_Id == id);
            if (surgery_Room == null)
            {
                return NotFound();
            }

            return View(surgery_Room);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Surgery_Room surgery_Room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surgery_Room);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(surgery_Room);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery_Room =  _context.Surgery_Rooms.Find(id);
            if (surgery_Room == null)
            {
                return NotFound();
            }
            return View(surgery_Room);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Surgery_Room surgery_Room)
        {
            if (id != surgery_Room.Surgery_Room_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surgery_Room);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Surgery_RoomExists(surgery_Room.Surgery_Room_Id))
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
            return View(surgery_Room);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surgery_Room =  _context.Surgery_Rooms
                .FirstOrDefault(m => m.Surgery_Room_Id == id);
            if (surgery_Room == null)
            {
                return NotFound();
            }

            return View(surgery_Room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var surgery_Room =  _context.Surgery_Rooms.Find(id);
            _context.Surgery_Rooms.Remove(surgery_Room);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool Surgery_RoomExists(int id)
        {
            return _context.Surgery_Rooms.Any(e => e.Surgery_Room_Id == id);
        }
    }
}
