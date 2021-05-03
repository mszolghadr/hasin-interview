using System;

namespace Hasin.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}