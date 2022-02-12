using LastHMS1.BreakTables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS1.Controllers
{
    public class CaringController : Controller
    {
        // GET: CaringController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CaringController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaringController/Create
        public ActionResult Create(int id , int DId)
        {
            Caring car= new Caring()
            {
                Patient_Id = id,
                Doctor_Id = DId
            };
            return View(car);
        }

        // POST: CaringController/Create
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

        // GET: CaringController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaringController/Edit/5
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

        // GET: CaringController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaringController/Delete/5
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
