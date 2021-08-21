using System;

namespace ELearning.Common.Entities
{
    public abstract class Entity<TKey> : IEntity, IKey<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public Entity()
        {
            this.IsDeleted = false;
            this.IsActive = true;
        }
    }
}
