using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.Models;
using MisFacturasWeb.TokenProvider;

namespace MisFacturasWeb.Controllers
{
    [JwtAuthentication]
    public class MovieController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public ActionResult Create(string jwToken, string CompanyId)
        {
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
            List<Movie> lsMovies = new List<Movie>();
            lsMovies.Add(new Movie() { Id = new Guid(), Name = "Parasitos", Director = "Un asiatico", Genre = "Suspenso" });
            lsMovies.Add(new Movie() { Id = new Guid(), Name = "Parasitos2", Director = "Un asiatico", Genre = "Suspenso" });
            lsMovies.Add(new Movie() { Id = new Guid(), Name = "Parasitos3", Director = "Un asiatico", Genre = "Suspenso" });
            lsMovies.Add(new Movie() { Id = new Guid(), Name = "Parasitos4", Director = "Un asiatico", Genre = "Suspenso" });
            return View(lsMovies);
        }

    }
}