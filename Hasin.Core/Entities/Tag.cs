using System.Collections.Generic;

namespace Hasin.Core.Entities
{
    public class Tag: BaseEntity
    {
        public string Label { get; set; }
        private readonly List<PhoneBookTag> _phoneBookTags = new();

        public Tag()
        {
        }

        public Tag(string label)
        {
            Label = label;
        }

        public IReadOnlyCollection<PhoneBookTag> PhoneBookTags => _phoneBookTags.AsReadOnly();
    }
}