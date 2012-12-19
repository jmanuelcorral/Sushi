using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;
using System.Linq;

namespace Sushi.Gridhelper
{
    public class Grid<T> : ISushiComponentBuilder where T : IList 
    {
        public ViewContext ViewContext { get; private set; }
        private GridComponent<T> Component { get; set; }
        
        public Grid<T> Bind()
        {
            this.Component.Items = (T)ViewContext.ViewData.Model;
            return this;
        }

        public Grid<T> Columns(List<GridColumn> columns)
        {
            this.Component.Columns = columns;
            return this;
        }

        public Grid<T> AddColumn(GridColumn gridColumn)
        {
            this.Component.Columns.Add(gridColumn);
            return this;
        }

        public Grid<T> Styles(List<GridStyle> styles)
        {
            this.Component.Style = styles;
            return this;
        }

        public Grid<T> AddStyle(GridStyle style)
        {
            this.Component.Style.Add(style);
            return this;
        }


        public Grid<T> Size(GridSize size)
        {
            this.Component.Size = size;
            return this;
        }

        public Grid<T> Filter<TElement>(GridFilter filter)
        {
            this.Component.Filter = filter;
            var elements = ExecuteFilter<TElement>();
            this.Component.Items = (T)elements;
            return this;
        }

        public Grid(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            this.Component = new GridComponent<T>();
            this.Component.HtmlProperties = new HtmlProperties(viewContext, this.Component.GetType());
            this.Component.Columns = new List<GridColumn>();
            this.Component.Style = new List<GridStyle>();
            this.Component.Action = "";
            this.Component.Skin = new GridSkin();
        }

        internal String BuildHeader()
        {
            TagBuilder thead = new TagBuilder("thead");
            TagBuilder tr = new TagBuilder("tr");
            if (this.Component.Columns.Count > 0)
            {
                foreach (var column in this.Component.Columns)
                {
                    var th = new TagBuilder("th");
                    th.InnerHtml = column.Title;
                    tr.InnerHtml += th.ToString(TagRenderMode.Normal);
                }
            }
            else
            {
                if (this.Component.Items !=null &&  this.Component.Items.Count > 0)
                {
                    Type objtype = this.Component.Items[0].GetType();
                    foreach (var column in objtype.GetProperties())
                    {
                        var th = new TagBuilder("th");
                        th.InnerHtml = column.Name;
                        tr.InnerHtml += th.ToString(TagRenderMode.Normal);
                    }
                }
            }
            thead.InnerHtml = tr.ToString(TagRenderMode.Normal);
            return thead.ToString(TagRenderMode.Normal);
        }

        internal String BuildBody()
        {
            TagBuilder tbody = new TagBuilder("tbody");
            if (this.Component.Items != null)
            {
                foreach (var element in this.Component.Items)
                {
                    Type objType = element.GetType();
                    TagBuilder tr = new TagBuilder("tr");
                    foreach (var property in objType.GetProperties())
                    {
                        TagBuilder td = new TagBuilder("td");
                        td.InnerHtml = property.GetValue(element, null).ToString();
                        tr.InnerHtml += td.ToString(TagRenderMode.Normal);
                    }
                    tbody.InnerHtml += tr.ToString(TagRenderMode.Normal);
                }
            }
            return tbody.ToString(TagRenderMode.Normal);
        }

        internal String BuildTable()
        {
            TagBuilder table = new TagBuilder("table");
            String cssClass = setCSSClasses();
            if (!String.IsNullOrEmpty(cssClass)) table.AddCssClass(cssClass);
            table.InnerHtml = BuildHeader() + BuildBody(); //+ BuildFooter();
            return table.ToString(TagRenderMode.Normal);
        }

        public  IList ExecuteFilter<TElement>()
        {
            this.Component.PaginationOptions = new GridPagination();
            this.Component.PaginationOptions.TotalPages = 0;
            this.Component.PaginationOptions.TotalRegisters = this.Component.Items.Count;
            this.Component.PaginationOptions.CurrentPage = (this.Component.Filter.CurrentPage == null)? 0 : this.Component.Filter.CurrentPage;
            this.Component.PaginationOptions.isFirstpage = true;
            var elements = new List<TElement>((IEnumerable<TElement>)this.Component.Items);
            var filtered = elements.Skip(this.Component.PaginationOptions.CurrentPage * this.Component.Filter.ResultsPerPage).Take(this.Component.Filter.ResultsPerPage);
            return filtered.ToList();
        }

        private String setCSSClasses()
        {
            String ResultStyle = "";
            foreach (var _style in this.Component.Style)
            {
                switch (_style)
                {
                    case GridStyle.Default:
                        ResultStyle += String.Format("{0} ", ((GridSkin)this.Component.Skin).CssBaseclass);
                        break;
                    case GridStyle.Condensed:
                        ResultStyle += String.Format("{0} ", ((GridSkin) this.Component.Skin).CssCondensed);
                        break;
                    case GridStyle.ZebraStripped:
                        ResultStyle += String.Format("{0} ", ((GridSkin)this.Component.Skin).CssZebraStripe);
                        break;
                    case GridStyle.Bordered:
                        ResultStyle += String.Format("{0} ", ((GridSkin)this.Component.Skin).CssBordered);
                        break;
                }
            }
            ResultStyle += String.Format("{0}", Resolvers.GridResolver.ResolveSize(this.Component.Size));
            return ResultStyle;
        }

        public string ToHtmlString()
        {
            return BuildTable();
        }

        public override String ToString()
        {
            return ToHtmlString();
        }
    }
}
