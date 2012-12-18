using System;
using System.Linq;
using Sushi.Extensions;

namespace Sushi.Gridhelper
{
    public static class SushiPagination
    {
        /*Extension Methods for Paging*/
        public static SushiPagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new SushiPagedList<T>(source, index, pageSize);
        }

        public static SushiPagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new SushiPagedList<T>(source, index, 10);
        }
    }

    public class GridPagination
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
        public Boolean isFirstpage { get; set; }
        public Boolean isLastPage { get; set; }
        public Boolean canMoveNext { get; set; }
        public Boolean canMovePrevious { get; set; }
    }
}
