using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.DTOs.Shared
{
    public abstract class PagedListRequest
    {
        [FromQuery] public int PageSize { get; set; }
        [FromQuery] public int PageNumber { get; set; }
    }
}