using JukeBox1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JukeBox1.Controllers
{
    public class DetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MultipleModels model = new MultipleModels();
        public ActionResult SongsDetails(int id)
        {
            model.Songs = (from songs in db.SongsModels where songs.Id == id select songs).ToList();
            return View(model);
        }
    }
}