using JukeBox1.Models;
using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JukeBox1.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Songs()
        {
            MultipleModels model = new MultipleModels();

            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            model.Songs = (from songs in db.SongsModels select songs).ToList();

            return View("Songs", model);
        }
        public ActionResult SongsByGenre(int id)
        {
            MultipleModels model = new MultipleModels();
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            model.Songs = (from songs in db.SongsModels where songs.GenreId == id select songs).ToList();
            return View("Songs", model);
        }

        [HttpPost]
        public ActionResult SongsByGenre(string GenreId)
        {
            MultipleModels model = new MultipleModels();

            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();

            if (!string.IsNullOrEmpty(GenreId))
            {
                int genreIdToInt = Convert.ToInt32(GenreId);
                model.Songs = (from songs in db.SongsModels where songs.GenreId == genreIdToInt select songs).ToList();
                return PartialView("Songs", model);
            }
            model.Songs = (from songs in db.SongsModels select songs).ToList();
            return PartialView("Songs", model);
        }
        public ActionResult AddSongToPlaylist(int id)
        {
            PlaylistViewModel.AddSongToPlaylist(id);
            return Songs();
        }
    }
}