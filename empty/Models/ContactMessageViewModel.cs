using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class ContactMessageViewModel
    {
        private const string requiredErrorMessage = "Pole wymagane";
        [MaxLength(100, ErrorMessage="Tytuł może mieć tylko 100 znaków")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }        

        [Required(ErrorMessage = requiredErrorMessage)]
        [MaxLength(5000, ErrorMessage = "Treść może mieć tylko 5000 znaków")]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [MaxLength(100, ErrorMessage = "Twoje imię i nawisko może mieć tylko 100 znaków")]
        [Display(Name = "Twoje imię i nawisko")]
        public string SenderName { get; set; }

        [EmailAddress(ErrorMessage = "Niepoprawny Email")]
        [Required(ErrorMessage = requiredErrorMessage)]
        [Display(Name = "Twój Email")]
        public string SenderEmail { get; set; }

        [Phone]
        [Required(ErrorMessage = requiredErrorMessage)]
        [Display(Name = "Twój numer telefonu")]
        public string PhoneNumber { get; set; }
    }
}
