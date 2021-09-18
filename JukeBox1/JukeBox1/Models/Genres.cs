using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JukeBox1.Models
{
    public class Genres
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("genre")]
        public string Genre { get; set; }
    }
}