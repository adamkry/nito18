using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class ResumeViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "O mnie")]
        public string Biography { get; set; }

        [Display(Name = "Kalendarium")]
        public IList<ResumePositionViewModel> Positions { get; set; }
    }
}
