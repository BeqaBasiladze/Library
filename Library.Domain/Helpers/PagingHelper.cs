using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Helpers
{
    public class PagingHelper<T> 
        where T : class
    {
        public IEnumerable<T> Data { get; set;} // all data
        public int TotalPages { get; set;} // pages count
        public int CurrentPage { get; set;} // current page
    }

    public static class Pagination
    {
        public static PagingHelper<T> PagedResult<T>(this List<T> list, int pageNumber, int pageSize) 
            where T : class
        {
            var result = new PagingHelper<T>();
            result.Data = list.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            result.TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count() / pageSize));
            result.CurrentPage = pageNumber;
            return result;
        }
    }
}
