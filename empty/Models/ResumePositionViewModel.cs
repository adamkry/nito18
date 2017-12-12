using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class ResumePositionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Okres")]
        public string DateRange { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
