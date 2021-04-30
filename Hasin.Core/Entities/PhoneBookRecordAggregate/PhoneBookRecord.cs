using System;
using System.Collections.Generic;
using Hasin.Core.Interfaces;

namespace Hasin.Core.Entities.PhoneBookRecordAggregate
{
    public class PhoneBookRecord : BaseEntity, IAggregateRoot
    {
        private readonly List<PhoneBookTag> _tags = new();
        public IReadOnlyCollection<PhoneBookTag> Tags => _tags.AsReadOnly();
    }
}
