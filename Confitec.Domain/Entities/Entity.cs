using System;

namespace Confitec.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; private set; }

        public Entity() { }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}