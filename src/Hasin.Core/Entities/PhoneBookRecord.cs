using System.Collections.Generic;
using System.Linq;
using Hasin.Core.Interfaces;

namespace Hasin.Core.Entities
{
    public class PhoneBookRecord : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        private List<PhoneBookTag> _phoneBookTags = new();

        public PhoneBookRecord()
        {
        }

        public PhoneBookRecord(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public void UpdateTags(List<int> tags){
            _phoneBookTags = _phoneBookTags.Except(_phoneBookTags.Where(t => !tags.Contains(t.TagId))).ToList();
            var tagsToAdd = tags.Except(_phoneBookTags.Select(t =>t.TagId));
            foreach (var item in tagsToAdd)
            {
                _phoneBookTags.Add(new PhoneBookTag
                {
                    PhoneBookRecordId = Id,
                    TagId = item
                });
            }
        }

        public IReadOnlyCollection<PhoneBookTag> PhoneBookTags => _phoneBookTags.AsReadOnly();
    }
}
