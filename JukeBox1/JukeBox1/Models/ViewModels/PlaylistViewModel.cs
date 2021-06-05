using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace JukeBox1.Models.ViewModels
{
    public class PlaylistViewModel
    {
        public static List<int> Ids = new List<int>();
        public double PlaylistMinutes;

        public static void AddSongToPlaylist(int id)
        {
            Ids.Add(id);
        }
        public void CalculatePlaylistDuration(MultipleModels songs)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            foreach (var item in songs.Songs)
            {
                PlaylistMinutes += Convert.ToDouble(item.Duration, provider);
            }
        }
    }
}