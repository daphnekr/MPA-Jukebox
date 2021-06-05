using JukeBox1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JukeBox1.Models
{
    public class MultipleModels
    {
        public IEnumerable<SongsModels> Songs { get; set; }
        public IEnumerable<GenresModels> Genre { get; set; }
        public IEnumerable<PlaylistsModels> Playlists { get; set; }
        public double PlaylistDuration { get; set; }
    }
}