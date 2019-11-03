using System;
using System.Collections.Generic;
using System.Text;

namespace InnerSpace.Domain
{
    public interface IModifiedOnTrackedEntity
    {
        DateTimeOffset ModifiedOn { get; set; }
    }
}
