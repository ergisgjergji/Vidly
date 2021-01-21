using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [MinimalAgeOf18]
        public DateTime Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}