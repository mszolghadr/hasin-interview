using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.DTOs
{
    public abstract class PagedListRequest
    {
        [FromQuery] public int PageSize { get; set; }
        [FromQuery] public int PageNumber { get; set; }
    }
}