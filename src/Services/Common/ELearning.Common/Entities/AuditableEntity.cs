using System;

namespace ELearning.Common.Entities
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public AuditableEntity()
        {
            this.CreatedBy = string.Empty;
            this.LastModifiedBy = string.Empty;
        }
    }
}
