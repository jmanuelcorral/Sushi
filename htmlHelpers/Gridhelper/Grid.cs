using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.Gridhelper
{
    public class Grid : ISushiComponentBuilder
    {
        public ViewContext ViewContext { get; private set; }
        private GridComponent Component { get; set; }
        
        public Grid Bind(IList elements)
        {
            this.Component.Items = elements;
            return this;
        }

        public Grid AddColumn(GridColumn gridColumn)
        {
            this.Component.Columns.Add(gridColumn);
            return this;
        }

        public Grid SetStyles(List<GridStyle> styles)
        {
            this.Component.Style = styles;
            return this;
        }

        public Grid AddStyle(GridStyle style)
        {
            this.Component.Style.Add(style);
            return this;
        }

        public Grid SetSize(GridSize size)
        {
            this.Component.Size = size;
            return this;
        }

        public Grid(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            this.Component = new GridComponent();
            this.Component.HtmlProperties = new HtmlProperties(viewContext, this.Component.GetType());
            this.Component.Columns = new List<GridColumn>();
            this.Component.Style = new List<GridStyle>();
            this.Component.Action = "#EmptyValue";
            this.Component.Skin = new GridSkin();
        }

        public String BuildHeader()
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
                if (this.Component.Items.Count > 0)
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

        public String BuildBody()
        {
            TagBuilder tbody = new TagBuilder("tbody");
            
            foreach (var element in this.Component.Items)
            {
                Type objType = element.GetType();
                TagBuilder tr = new TagBuilder("tr");
                foreach (var property in objType.GetProperties())
                {
                 TagBuilder td = new TagBuilder("td");
                    td.InnerHtml = property.GetValue(element,null).ToString();
                    tr.InnerHtml += td.ToString(TagRenderMode.Normal);
                }
                tbody.InnerHtml += tr.ToString(TagRenderMode.Normal);
            }
            return tbody.ToString(TagRenderMode.Normal);
        }

        public String BuildTable()
        {
            TagBuilder table = new TagBuilder("table");
            String cssClass = setCSSClasses();
            if (!String.IsNullOrEmpty(cssClass)) table.AddCssClass(cssClass);
            table.InnerHtml = BuildHeader() + BuildBody(); //+ BuildFooter();
            return table.ToString(TagRenderMode.Normal);
        }

        private String setCSSClasses()
        {
            String ResultStyle = "";
            foreach (var _style in this.Component.Style)
            {
                switch (_style)
                {
                    case GridStyle.Default:
                        ResultStyle += String.Format("{0} ",  this.Component.Skin.CssBaseclass);
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
            ResultStyle += String.Format("{0} ",Resolvers.GridResolver.ResolveSize(this.Component.Size));
            return ResultStyle;
        }

        public string ToHtmlString()
        {
            return BuildTable();
        }

        public String ToString()
        {
            return ToHtmlString();
        }
    }
}
