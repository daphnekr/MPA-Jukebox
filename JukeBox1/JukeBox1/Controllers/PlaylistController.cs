using JukeBox1.Models;
using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JukeBox1.Controllers
{
    public class PlaylistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Playlist()
        {
            MultipleModels model = new MultipleModels();

            PlaylistViewModel playlistViewModel = new PlaylistViewModel();
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
  
            model.Songs = db.SongsModels
                               .Where(s => PlaylistViewModel.Ids.Contains(s.Id));
            playlistViewModel.CalculatePlaylistDuration(model);
            model.PlaylistDuration = playlistViewModel.PlaylistMinutes;
            return View("Playlist", model);
        }

        public ActionResult DeleteSongFromPlaylist(int id)
        {
            MultipleModels model = new MultipleModels();

            PlaylistViewModel playlistViewModel = new PlaylistViewModel();
            PlaylistViewModel.Ids.RemoveAll(item => item == id);
            

            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();

            model.Songs = db.SongsModels
                               .Where(s => PlaylistViewModel.Ids.Contains(s.Id));

            playlistViewModel.CalculatePlaylistDuration(model);
            model.PlaylistDuration = playlistViewModel.PlaylistMinutes;
            return View("Playlist", model);
        }
        [HttpPost]
        public ActionResult SavePlaylist(string playlistname)
        {
            var songs = db.SongsModels
                               .Where(s => PlaylistViewModel.Ids.Contains(s.Id));
            ApplicationUser user = new ApplicationUser();
            var id = user.Id;
            string songids = "";
            foreach(var item in songs)
            {
                songids = songids + item.Id + ",";
            }
            PlaylistsModels bla = new PlaylistsModels
            {
                PlaylistName = playlistname,
                UserId = id,
                SongsIds = songids
            };
            db.PlaylistsModels.Add(bla);
            db.SaveChanges();
            return Playlist();
        }

        public ActionResult GetSavedPlaylists()
        {
            ApplicationUser user = new ApplicationUser();
            var id = user.Id;
            return View("SavedPlaylists", (from playlists in db.PlaylistsModels where playlists.UserId == id select playlists));
        }
    }
}