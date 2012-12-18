using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.Gridhelper
{
    public class GridComponent:ISushiComponent, ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        public List<GridStyle> Style { get; set; }
        public GridSize Size { get; set; }
        public GridPagination PaginationOptions { get; set; }
        public List<GridColumn> Columns { get; set; } 
        public IList Items { get; set; }
        public String Action { get; set; }
        public GridFilter Filter { get; set; }
        #endregion
    }
}
