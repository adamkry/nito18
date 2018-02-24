using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class ContactMessageViewModel
    {
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }        

        [Required]
        [MaxLength(5000)]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        
        [EmailAddress]
        [Required]
        [Display(Name = "Twój Email")]
        public string SenderEmail { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Twój numer telefonu")]
        public string PhoneNumber { get; set; }
    }
}
