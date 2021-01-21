using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [MinimalAgeOf18]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Subscribed to newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Membership Type is required")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}