using System;

namespace InnerSpace.Application.ReadModels
{
    public class SubcriptionConfigurationReadModel : BaseReadModel
    { 
        public Guid SubcriptionId { get;   set; }
        public Guid ConfigurationId { get;   set; }
        public bool Enabled { get; set; }
    }
}
