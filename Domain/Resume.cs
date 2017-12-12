using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Resume : IEntity
    {
        public int Id { get; set; }

        public string Biography { get; set; }

        public IList<ResumePosition> Positions { get; set; }
    }
}
