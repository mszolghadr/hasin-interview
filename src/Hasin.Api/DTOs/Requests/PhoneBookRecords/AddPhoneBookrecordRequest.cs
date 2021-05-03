using System.Collections.Generic;

namespace Hasin.Api.DTOs.Requests.PhoneBookRecords
{
    public class AddPhoneBookrecordRequest
    {
        public string Name { get; set; }
        public List<int> TagIds { get; set; }
        public string PhoneNumber { get; set; }
    }
}