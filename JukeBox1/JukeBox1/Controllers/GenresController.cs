using JukeBox1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JukeBox1.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Genres()
        {
            var Genres = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            return View(Genres);
        }
    }
}