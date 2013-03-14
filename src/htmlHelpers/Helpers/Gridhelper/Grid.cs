using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;
using Sushi.Helpers.Javascript;
using Sushi.Helpers.Resolvers;

namespace Sushi.Helpers.Gridhelper
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

        public Grid<T> Pagination(Func<GridPagination, GridPagination> pagination)
        {
            this.Component.Pagination = pagination(this.Component.Pagination);
            return this;
        }

        public Grid<T> Search(Func<GridSearch, GridSearch> searchparams)
        {
            this.Component.Search = searchparams(this.Component.Search);
            return this;
        }

        public Grid<T> Options (Func<GridOptions,GridOptions> options)
        {
            this.Component.Options = options(this.Component.Options);
            return this;
        }

        public Grid<T> Binding (Func<GridBinding, GridBinding> binding)
        {
            this.Component.Binding = binding(this.Component.Binding);
            return this;
        }

        private void setOptions(GridOptions opt)
        {
            this.Component.Options = opt;
        }

        public Grid<T> Size(GridSize size)
        {
            this.Component.Size = size;
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
            this.Component.Scripts = new GridScripts();
            this.Component.Options = new GridOptions();
            this.Component.Pagination = new GridPagination();
            this.Component.Search = new GridSearch();
            this.Component.Binding = new GridBinding();
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

        private void BuildScripts()
        {
          //Empezamos por el Base Script
            if (String.IsNullOrEmpty(this.Component.HtmlProperties.Id))
            {
                this.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext,
              typeof (Grid<T>));
            }
            JSBuilder JS = new JSBuilder();
            this.Component.Pagination.ToJS(JS);
            this.Component.Search.ToJS(JS);
            this.Component.Binding.ToJS(JS);
            String basescript = "$('#" + this.Component.HtmlProperties.Id + "').dataTable(" +  JS.ToLiteralJSObject(true) +");";
            ((GridScripts)this.Component.Scripts).AddScript(basescript);
            var scripts = JSResolver.JSStack(ViewContext);
            scripts.Push(((GridScripts)this.Component.Scripts).GetGeneratedScript());
        }

       

        internal String BuildTable()
        {
            TagBuilder table = new TagBuilder("table");
            String cssClass = setCSSClasses();
            
            if (!String.IsNullOrEmpty(cssClass)) table.AddCssClass(cssClass);
            table.InnerHtml = BuildHeader() + BuildBody(); //+ BuildFooter();
            //Construir la parte de Scripts que realizan los filtrados, etc
            BuildScripts();
            if (!String.IsNullOrEmpty(this.Component.HtmlProperties.Id)) table.Attributes.Add("id", this.Component.HtmlProperties.Id);
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
