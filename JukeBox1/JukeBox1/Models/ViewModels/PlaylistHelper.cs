using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace JukeBox1.Models.ViewModels
{
    public class PlaylistHelper : Page
    {
        public List<int> Ids = new List<int>();
        public double PlaylistMinutes;
        private ApplicationDbContext db = new ApplicationDbContext();


        public void AddSongToPlaylist(int id)
        {
            Session["tempPlaylist"] = Session["tempPlaylist"] + id.ToString() + ",";
        }
        public void CalculatePlaylistDuration(MultipleModels songs)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            List<int> ids = SplitSessionList();
            foreach (var id in ids)
            {
                var songid = Convert.ToInt32(id);
                var songItem = (from song in db.SongsModels where song.Id == songid select song).FirstOrDefault();
                PlaylistMinutes += Convert.ToDouble(songItem.Duration, provider);
            }
        }

        public List<int> SplitSessionList()
        {
            List<string> songIds = Session["tempPlaylist"].ToString().Split(',').ToList();

            songIds = songIds.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            List<int> songsIdsInt = new List<int>();
            foreach (string id in songIds)
            {

                songsIdsInt.Add(Convert.ToInt32(id));
            }
            return songsIdsInt;
        }

        public void RemoveFromSession(int id)
        {
            List<int> test = SplitSessionList();
            test.Remove(id);
            Session["tempPlaylist"] = null;
            foreach(var item in test)
            {
                Session["tempPlaylist"] = Session["tempPlaylist"] + item.ToString() + ",";
            }
        }
        
    }
}