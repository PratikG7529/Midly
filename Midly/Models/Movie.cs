using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1,20)]
        public int  Stock { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddDate { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

    }
}