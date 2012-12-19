using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sushi.Gridhelper;

namespace Sushi
{
    public interface ISushiFilter
    {
        bool Pagination { get; set; }
        int ResultsPerPage { get; set; }
        bool ShowTotalResults { get; set; }
        int CurrentPage { get; set; }
        //Object ExecuteFilter(ISushiComponent Component);
    }
}
