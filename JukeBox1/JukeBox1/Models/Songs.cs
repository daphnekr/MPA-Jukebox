using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JukeBox1.Models
{
    public class Songs
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("songName")]
        public string SongName { get; set; }
        [Column("artist")]
        public string Artist { get; set; }
        [Column("duration")]
        public string Duration { get; set; }
        [Column("genreId")]
        [ForeignKey("Genres")]
        public int GenreId { get; set; }
        public virtual Genres Genres { get; set; }
    }
}