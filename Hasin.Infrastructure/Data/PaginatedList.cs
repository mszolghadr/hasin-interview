using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                return CurrentPage > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPage < TotalPages;
            }
        }

        public List<T> Items { get; private set; }

        public PaginatedList(List<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            PageSize = pageSize;
            From = ((currentPage - 1) * pageSize) + 1;
            To = From + pageSize - 1;
            Items = items;
        }

        public static async Task<PaginatedList<T>> CreateAsync(
        IQueryable<T> source, int currentPage, int pageSize)
        {
            var count = source.CountAsync();
            var list = source.Skip(
               (currentPage - 1) * pageSize)
               .Take(pageSize).ToListAsync();
            await Task.WhenAll(new Task[] { count, list });
            return new PaginatedList<T>(list.Result, count.Result, currentPage, pageSize);
        }
    }
}