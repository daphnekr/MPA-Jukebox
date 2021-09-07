using JukeBox1.Models;
using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.SessionState;

namespace JukeBox1.Controllers
{
    public class PlaylistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MultipleModels model = new MultipleModels();
        private PlaylistHelper playlistHelper = new PlaylistHelper();

        public ActionResult Playlist()
        {
            if (Session["tempPlaylist"] != null) 
            { 
                model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
                playlistHelper.CalculatePlaylistDuration(model);
                List<int> songsIdsInt = playlistHelper.SplitSessionList();

                model.Songs = (from s in db.SongsModels where songsIdsInt.Contains(s.Id) select s);

                model.PlaylistDuration = playlistHelper.PlaylistMinutes;
            }
            return View("Playlist", model);
        }

        public ActionResult DeleteSongFromPlaylist(int id)
        {
            playlistHelper.Ids.RemoveAll(item => item == id);
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            playlistHelper.RemoveFromSession(id);
            model.isSucces = true;
            return Playlist();
        }
        [HttpPost]
        public ActionResult SavePlaylist(string playlistname)
        {
            var id = User.Identity.GetUserId();
            PlaylistsModels playlist = new PlaylistsModels
            {
                PlaylistName = playlistname,
                UserId = id,
                SongsIds = Session["tempPlaylist"].ToString()
            };
            db.PlaylistsModels.Add(playlist);
            db.SaveChanges();
            Session["tempPlaylist"] = null;
            return Playlist();
        }

        public ActionResult GetSavedPlaylists()
        {
            var id = User.Identity.GetUserId();
            return View("SavedPlaylists", (from playlists in db.PlaylistsModels where playlists.UserId == id select playlists));
        }

        public ActionResult GetUserPlaylistSongs(string ids, int playlistId = 0)
        {
            model.Genre = (from genres in db.GenresModels orderby genres.Genre ascending select genres).ToList();
            model.PlaylistId = (from playlist in db.PlaylistsModels where playlist.Id == playlistId select playlist.Id).FirstOrDefault();
            model.Playlists = (from playlist in db.PlaylistsModels where playlist.Id == playlistId select playlist);
            string[] split = ids.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> idsList = Array.ConvertAll(split, s => int.Parse(s)).ToList();

            model.Songs = db.SongsModels
                   .Where(s => idsList.Contains(s.Id));

            return View("UserPlaylistSongs", model);
        }

        public ActionResult DeleteFromPlaylist(int songId, int playlistId = 0)
        {
            var songIds = (from playlist in db.PlaylistsModels where playlist.Id == playlistId select playlist.SongsIds).ToList();
            string newSongsIds = songIds[0].Replace(Convert.ToString(songId), "");
            db.PlaylistsModels.Find(playlistId).SongsIds = newSongsIds;
            db.SaveChanges();
            return GetUserPlaylistSongs(newSongsIds, playlistId);
        }

        public ActionResult DeletePlaylist(int playlistId)
        {
            db.PlaylistsModels.Remove(db.PlaylistsModels.Find(playlistId));
            db.SaveChanges();
            return GetSavedPlaylists();
        }
    }
}