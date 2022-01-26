using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Controllers
{
    public class Death_CaseController : Controller
    {
        // GET: Death_CaseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Death_CaseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Death_CaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Death_CaseController/Create
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

        // GET: Death_CaseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Death_CaseController/Edit/5
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

        // GET: Death_CaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Death_CaseController/Delete/5
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
