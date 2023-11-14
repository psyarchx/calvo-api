using System;

namespace Calvo.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
