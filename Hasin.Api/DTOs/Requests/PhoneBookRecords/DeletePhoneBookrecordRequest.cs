using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.DTOs.Requests.PhoneBookRecords
{
    public class DeletePhoneBookrecordRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}