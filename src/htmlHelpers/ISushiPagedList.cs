using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi
{
    public interface ISushiPagedList
    {
        int TotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }     
    }
}
