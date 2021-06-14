using System;

namespace NetMicroservices.SqlWrapper
{
    /// <summary>
    /// Common fields for all SqlServer entities.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets numeric identifier of particular entity.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets creator of particular entity item.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets date of entity item creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets author of last update.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets last update date.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
