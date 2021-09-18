using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JukeBox1.Models
{
    public class MultipleModels
    {
        public IEnumerable<Songs> Songs { get; set; }
        public IEnumerable<Genres> Genre { get; set; }
        public IEnumerable<Playlists> Playlists { get; set; }
        public double PlaylistDuration { get; set; }
        public int PlaylistId { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}