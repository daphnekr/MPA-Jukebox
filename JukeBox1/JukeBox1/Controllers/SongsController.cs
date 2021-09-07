using JukeBox1.Models;
using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace JukeBox1.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private PlaylistHelper playlistHelper = new PlaylistHelper();
        MultipleModels model = new MultipleModels();
        public ActionResult Songs()
        {
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            model.Songs = (from songs in db.SongsModels select songs).ToList();

            if (Request.IsAuthenticated)
            {
                string id = User.Identity.GetUserId();
                model.Playlists = (from playlists in db.PlaylistsModels where playlists.UserId == id select playlists);
            }
            
            return View("Songs", model);
        }
        public ActionResult SongsByGenre(int id)
        {
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            model.Songs = (from songs in db.SongsModels where songs.GenreId == id select songs).ToList();
            return View("Songs", model);
        }

        [HttpPost]
        public ActionResult SongsByGenre(string GenreId)
        {
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();

            if (!string.IsNullOrEmpty(GenreId))
            {
                int genreIdToInt = Convert.ToInt32(GenreId);
                model.Songs = (from songs in db.SongsModels where songs.GenreId == genreIdToInt select songs).ToList();
                if (Request.IsAuthenticated)
                {
                    string id = User.Identity.GetUserId();
                    model.Playlists = (from playlists in db.PlaylistsModels where playlists.UserId == id select playlists);
                }
                return PartialView("Songs", model);
            }
            model.Songs = (from songs in db.SongsModels select songs).ToList();
            return PartialView("Songs", model);
        }
        public ActionResult AddSongToPlaylist(int id = 0)
        {
            playlistHelper.AddSongToPlaylist(id);
            Session["Added"] = true;
            return Songs();
        }
        public ActionResult AddSongToExistingPlaylist(int songId, int playlistId)
        {
            var playlist = db.PlaylistsModels.Find(playlistId);
            playlist.SongsIds = playlist.SongsIds + songId + ",";
            db.SaveChanges();
            return Songs();
        }
    }
}