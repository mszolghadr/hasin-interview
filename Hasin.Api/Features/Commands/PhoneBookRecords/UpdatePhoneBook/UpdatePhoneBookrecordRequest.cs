using System.Collections.Generic;
using System.Text.Json.Serialization;
using Hasin.Api.Features.Commands.PhoneBookRecords.AddPhoneBook;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.Features.Commands.PhoneBookRecords.UpdatePhoneBook
{
    public class UpdatePhoneBookrecordRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        [FromBody]
        public AddPhoneBookrecordRequest Body { get; set; }
    }
}