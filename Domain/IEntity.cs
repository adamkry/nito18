using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
