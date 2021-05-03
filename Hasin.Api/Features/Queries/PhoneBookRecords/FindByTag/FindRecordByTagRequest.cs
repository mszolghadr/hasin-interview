using Hasin.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.Features.Queries.PhoneBookRecords.FindByTag
{
    public class FindRecordByTagRequest : PagedListRequest
    {
        [FromRoute(Name = "tagId")]
        public int TagId { get; set; }
    }
}