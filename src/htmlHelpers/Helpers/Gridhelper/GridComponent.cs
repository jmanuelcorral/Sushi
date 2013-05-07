using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.Gridhelper
{
    public class GridComponent<T> : ISushiComponent, ISushiSkinnable, ISushiScriptable where T : IList
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        public List<GridStyle> Style { get; set; }
        public GridSize Size { get; set; }
        public T Items { get; set; }
        public String Action { get; set; }
        public GridOptions Options { get; set; }
        public ISushiScript Scripts { get; set; }
        public GridPagination Pagination { get; set; }
        public GridSearch Search { get; set; }
        public GridBinding Binding { get; set; }
        public GridColumnOptions Columns { get; set; }
        public GridResources Resources { get; set; }
        public ModelMetadata Metadata { get; set; }
        #endregion
       
    }
}
