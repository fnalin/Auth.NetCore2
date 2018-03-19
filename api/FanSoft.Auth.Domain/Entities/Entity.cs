using System;

namespace FanSoft.Auth.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {}

        public int Id { get; private set; }
        public DateTime DataCricacao { get; private set; } = DateTime.UtcNow;
    }
}
