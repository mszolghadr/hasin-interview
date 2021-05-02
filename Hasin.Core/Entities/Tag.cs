using System.Collections.Generic;

namespace Hasin.Core.Entities
{
    public class Tag: BaseEntity
    {
        public string Label { get; set; }
        private readonly List<PhoneBookTag> _phoneBookTags = new();
        public IReadOnlyCollection<PhoneBookTag> PhoneBookTags => _phoneBookTags.AsReadOnly();
    }
}