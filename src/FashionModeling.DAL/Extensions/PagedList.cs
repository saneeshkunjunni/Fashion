using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling
{ 
    public class PagedList<T> : List<T>// where T: IQueryable<T>, IEnumerable<T>, ICollection<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int RowCount { get; set; }
        public int PageSize { get; set; }
        public int FirstRowOnPage
        {

            get { return (PageIndex - 1) * PageSize + 1; }
        }
        public int FirstPage
        {

            get { return 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(PageIndex * PageSize, RowCount); }
        }
        public int LastPage
        {
            get { return (int)Math.Floor((decimal)RowCount / PageSize); }
        }

        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            RowCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
