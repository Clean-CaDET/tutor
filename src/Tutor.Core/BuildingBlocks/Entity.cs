using System;

namespace Tutor.Core.BuildingBlocks
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
