using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Controllers
{
    public class RayController : Controller
    {
        // GET: RayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RayController/Create
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

        // GET: RayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RayController/Edit/5
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

        // GET: RayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RayController/Delete/5
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
