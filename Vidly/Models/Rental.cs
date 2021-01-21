using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CustomerId")]

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}