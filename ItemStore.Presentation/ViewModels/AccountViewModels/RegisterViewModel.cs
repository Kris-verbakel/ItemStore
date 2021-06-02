using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemStore.Presentation.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [StringLength(50, ErrorMessage = "The email adress can not be longer than 50 characters")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Username")]
        [StringLength(15, ErrorMessage = "The username can not be longer than 15 characters")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

    }
}
