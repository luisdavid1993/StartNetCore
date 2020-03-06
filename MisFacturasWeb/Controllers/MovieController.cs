using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.Authorization;
using MisFacturasWeb.Models;
using SerilogLogger.Interface;
namespace MisFacturasWeb.Controllers
{
    public class MovieController : BaseController
    {
        public MovieController(IEvenLog logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public ActionResult Create()
        {
            try
            {
                Convert.ToInt32("kkk");
            }
            catch (Exception ex)
            {
                string message = "MovieController : " + ex.ToString();
                ViewBag.ErrorMesage = _logger.Error(message, "Imposible conectar con los WCF", "MovieController");
            }
            return View();
        }

        // POST: error/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                var _movie = movie;
                return RedirectToAction(nameof(ListMovies));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ListMovies()
        {
            List<Movie> lsMovies = new List<Movie>
            {
                new Movie() { Id = new Guid(), Name = "Parasitos", Director = "Un asiatico", Genre = "Suspenso" },
                new Movie() { Id = new Guid(), Name = "Parasitos2", Director = "Un asiatico", Genre = "Suspenso" },
                new Movie() { Id = new Guid(), Name = "Parasitos3", Director = "Un asiatico", Genre = "Suspenso" },
                new Movie() { Id = new Guid(), Name = "Parasitos4", Director = "Un asiatico", Genre = "Suspenso" }
            };
            return View(lsMovies);
        }

    }
}