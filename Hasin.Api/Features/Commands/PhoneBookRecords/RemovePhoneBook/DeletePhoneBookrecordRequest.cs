using System.Collections.Generic;
using System.Text.Json.Serialization;
using Hasin.Api.Features.Commands.PhoneBookRecords.AddPhoneBook;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.Features.Commands.PhoneBookRecords.RemovePhoneBook
{
    public class DeletePhoneBookrecordRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}