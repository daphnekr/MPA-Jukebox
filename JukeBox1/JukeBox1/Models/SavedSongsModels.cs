using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JukeBox1.Models
{
    public class SavedSongsModels
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("playlistId")]
        [ForeignKey("Playlists")]
        public int PlaylistId { get; set; }
        public virtual PlaylistsModels Playlists { get; set; }
        [Column("songIds")]
        public string SongIds { get; set; }
    }
}