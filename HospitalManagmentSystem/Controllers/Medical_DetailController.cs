using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Controllers
{
    public class Medical_DetailController : Controller
    {
        // GET: Medical_DetailController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medical_DetailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medical_DetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medical_DetailController/Create
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

        // GET: Medical_DetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medical_DetailController/Edit/5
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

        // GET: Medical_DetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medical_DetailController/Delete/5
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
