using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.Gridhelper
{
    public class GridFilter:ISushiFilter
    {
        public bool Pagination { get; set; }
        public int ResultsPerPage { get; set; }
        public bool ShowTotalResults { get; set; }
        public int CurrentPage { get; set; }
     
    }
}
