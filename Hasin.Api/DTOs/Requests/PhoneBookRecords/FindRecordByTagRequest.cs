using Hasin.Api.DTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.DTOs.Requests.PhoneBookRecords
{
    public class FindRecordByTagRequest : PagedListRequest
    {
        [FromRoute(Name = "tagId")]
        public int TagId { get; set; }
    }
}