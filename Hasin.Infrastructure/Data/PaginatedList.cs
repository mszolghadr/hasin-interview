using System.Collections.Generic;
using System.Linq;

namespace Hasin.Infrastructure.Data
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; protected set; }

        public int PageSize { get; protected set; }

        public int TotalCount { get; protected set; }

        public int TotalPages { get; protected set; }

        public int From { get; protected set; }

        public int To { get; protected set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public List<T> Items { get; protected set; }

        public PaginatedList(IQueryable<T> source, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;

            TotalCount = source.Count();
            Items = source.Skip(
               (currentPage - 1) * pageSize)
               .Take(pageSize).ToList();
        }
    }
}