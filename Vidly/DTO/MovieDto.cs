using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [MaxDateNow]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxDateNow]
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Number in Stock must be between {1} and {2}")]
        public int NumberInStock { get; set; }

        [Required]
        public int NumberAvailable { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}