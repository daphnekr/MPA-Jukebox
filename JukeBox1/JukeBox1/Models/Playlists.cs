using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JukeBox1.Models
{
    public class Playlists
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("playlistName")]
        public string PlaylistName { get; set; }
        [Column("userId")]
        public string UserId { get; set; }
        [Column("songsIds")]
        public string SongsIds { get; set; }

    }
}