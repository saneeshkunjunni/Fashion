using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling
{
    public static class ListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> list, int page, int pageSize)
        {
            int count = list.Count();
            var items = list.Skip((page - 1) * pageSize).Take(pageSize).ToList() ;
            return new PagedList<T>(items, count, page, pageSize);
        }
        public static async Task<PagedList<T>> ToAsycPagedList<T>(this IQueryable<T> list, int page, int pageSize)
        {
            return await PagedList<T>.CreateAsync(list, page, pageSize);
        }
    }
}
