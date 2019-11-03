using System;

namespace InnerSpace.Application.ReadModels
{
    public class UserSubcriptionReadModel : BaseReadModel
    {
        public Guid SubcriptionId { get; set; }
        public Guid UserId { get; set; }
        public string APIKey { get; set; }
    }
}
