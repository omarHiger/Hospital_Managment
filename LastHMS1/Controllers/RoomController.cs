using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastHMS1.Data;
using LastHMS1.Models;
using LastHMS1.ShowClasses;

namespace LastHMS1.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        //***********************************************************
        public IActionResult AvailableRooms(int? id)
        {
            if (id == null) return NotFound();
            var rooms = _context.Rooms.Where(r => r.Ho_Id == id && r.Room_Empty == true).ToList();
            return View(rooms);
        }
        public IActionResult BusyRooms(int id)
        {
            var rooms = _context.Rooms.Where(r => r.Ho_Id == id).ToList();
            var data = (from res in _context.Reservations.ToList()
                        join room in rooms
                        on res.Room_Id equals room.Room_Id
                        where res.End_Date == default(DateTime)
                        select new { res, room }
                        into a
                        join p in _context.Patients.ToList()
                        on a.res.Patient_Id equals p.Patient_Id
                        select new BusyRooms
                        {
                            RoomNumber = a.room.Room_Number,
                            StartDate = a.res.Start_Date,
                            PatientName = p.Patient_First_Name + " " + p.Patient_Last_Name
                        }).ToList();
            return View(data);
        }
        //***********************************************************

        public IActionResult Index()
        {
            return View( _context.Rooms.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms
                .FirstOrDefault(m => m.Room_Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.Room_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Room_Id))
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
            return View(room);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms
                .FirstOrDefault(m => m.Room_Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var room =  _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Room_Id == id);
        }
    }
}
