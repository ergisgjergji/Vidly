using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255)]
        [Display(Name = "Title")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")][MaxDateNow]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Date Added is required")][MaxDateNow]
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Number in Stock is required")]
        [Range(0, 20, ErrorMessage = "Number in Stock must be between {1} and {2}")]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Required(ErrorMessage = "Number available is required")]
        [Range(0, 20, ErrorMessage = "Number in Stock must be between {1} and {2}")]
        [Display(Name = "Number available")]
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }


    }
}