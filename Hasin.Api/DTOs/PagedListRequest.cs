namespace Hasin.Api.DTOs
{
    public abstract class PagedListRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}