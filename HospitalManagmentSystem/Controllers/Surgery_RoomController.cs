using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Controllers
{
    public class Surgery_RoomController : Controller
    {
        // GET: Surgery_RoomController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Surgery_RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Surgery_RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surgery_RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Surgery_RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Surgery_RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Surgery_RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Surgery_RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
