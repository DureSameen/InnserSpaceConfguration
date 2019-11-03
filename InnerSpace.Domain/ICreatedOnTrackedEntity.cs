using System;
using System.Collections.Generic;
using System.Text;

namespace InnerSpace.Domain
{
    public interface ICreatedOnTrackedEntity
    {
        DateTimeOffset CreatedOn { get; set; }
    }
}
