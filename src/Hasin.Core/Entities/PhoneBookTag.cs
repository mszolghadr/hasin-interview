using System.Text.Json.Serialization;

namespace Hasin.Core.Entities
{
    public class PhoneBookTag
    {
        public int TagId { get; set; }

        [JsonIgnore]
        public Tag Tag { get; set; }

        public int PhoneBookRecordId { get; set; }
        
        [JsonIgnore]
        public PhoneBookRecord PhoneBookRecord { get; set; }
    }
}