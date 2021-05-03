using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.DTOs.Requests.PhoneBookRecords
{
    public class UpdatePhoneBookrecordRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        [FromBody]
        public AddPhoneBookrecordRequest Body { get; set; }
    }
}