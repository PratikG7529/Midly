using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, 20)]
        public int Stock { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime AddDate { get; set; }
        
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}