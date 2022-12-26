using Microsoft.EntityFrameworkCore;

namespace VOB.Repositories
{
    public class PagedRepo<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Data { get; set; } = new();

        public PagedRepo(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalRecords = count;

            Data.AddRange(items);
        }

        public static async Task<PagedRepo<T>> PagingAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedRepo<T>(items, count, pageIndex, pageSize);
        }
    }
}
