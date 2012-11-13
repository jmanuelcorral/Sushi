using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;
using Sushi.Resolvers;

namespace Sushi.LayoutHelper
{
    public class Layout: ISushiComponentBuilder, ISushiContainer
    {
        public ViewContext ViewContext { get; private set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        private LayoutComponent Component { get; set; }
        private bool disposed;


        #region Fluent SideBar Setters
        public Layout AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        public Layout AddInnerHTML(String html)
        {
            this.Component.InnerHtml += html;
            return this;
        }

        public Layout SetLayoutType(LayoutType type)
        {
            this.Component.Layout = type;
            return this;
        }

        public Layout SetLayoutSize(GridSize size)
        {
            this.Component.LayoutSize = size;
            return this;
        }

        #endregion

        #region Fluent Common Setters

       #endregion

        #region Constructor

        public Layout(ViewContext view, LayoutType layoutType, GridSize layoutSize)
        {
            this.ViewContext = view;
            this.Component = new LayoutComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.InnerHtml = String.Empty;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.Layout = layoutType;
            this.Component.LayoutSize = layoutSize;
            
        }



        public Layout(ViewContext view, GridSize layoutSize)
        {
            this.ViewContext = view;
            this.Component = new LayoutComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.InnerHtml = String.Empty;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.LayoutSize = layoutSize;
           
        }

        public Layout(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new LayoutComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.InnerHtml = String.Empty;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            
        }

        #endregion

        #region StringBuilders

        private void setLayoutValues(ref TagBuilder tag)
        {
            if (this.Component.Layout.HasValue) tag.AddCssClass(LayoutManager.ResolveLayout(this.Component.Layout.Value));
            if (this.Component.LayoutSize.HasValue) tag.AddCssClass(GridResolver.ResolveSize(this.Component.LayoutSize.Value));
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            setLayoutValues(ref tagBuilder);
            if (ContainerElements.Count >0)
            {
                foreach (var sushiHelper in ContainerElements)
                {
                    tagBuilder.InnerHtml += sushiHelper.ToHtmlString();
                }
            }
            if (!String.IsNullOrEmpty(Component.InnerHtml)) tagBuilder.InnerHtml += Component.InnerHtml;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion

    }
}
