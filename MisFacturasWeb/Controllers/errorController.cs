using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.TokenProvider;

namespace MisFacturasWeb.Controllers
{
    [JwtAuthentication]
    public class errorController : BaseController
    {
        // GET: error
        public ActionResult Index()
        {
            return View();
        }

        // GET: error/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: error/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: error/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: error/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: error/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: error/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: error/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}