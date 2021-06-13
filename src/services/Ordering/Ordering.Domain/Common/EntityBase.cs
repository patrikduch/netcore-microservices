using System;

namespace Ordering.Domain.Common
{
    /// <summary>
    /// Common fields for all SqlServer entities.
    /// </summary>
    public abstract class EntityBase
    {
        public int Id { get; protected set; }

        public string CreatedBy { get; set; }
            
        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
