using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Controllers
{
    public class Medical_TestController : Controller
    {
        // GET: Medical_TestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medical_TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medical_TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medical_TestController/Create
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

        // GET: Medical_TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medical_TestController/Edit/5
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

        // GET: Medical_TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medical_TestController/Delete/5
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
