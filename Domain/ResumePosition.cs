using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ResumePosition : IEntity
    {
        public int Id { get; set; }

        public string DateRange { get; set; }

        public string Description { get; set; }
    }
}
