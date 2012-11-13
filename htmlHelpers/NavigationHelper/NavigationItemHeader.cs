using System;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.NavigationHelper
{
    public class NavigationItemHeader:ISushiComponentBuilder
    {
        
        #region CSS Classes
        #endregion

        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private NavigationItemHeaderComponent Component { get; set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NavigationItemHeader SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public NavigationItemHeader SetId(String id)
        {
            this.Component.HtmlProperties.Id = id;
            return this;
        }

        public NavigationItemHeader SetValue(String value)
        {
            this.Component.HtmlProperties.InnerHtml = value;
            return this;
        }

        #endregion
  
        #region Constructor
        public NavigationItemHeader(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new NavigationItemHeaderComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
        }

        public NavigationItemHeader()
        {
            this.Component = new NavigationItemHeaderComponent();
            this.Component.HtmlProperties = new HtmlProperties();
        }

        #endregion

        #region StringBuilders


        private String CreateSushiNavigationItemHeader()
        {
            var tagBuilder = new TagBuilder("li");
            tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
            tagBuilder.AddCssClass("nav-header");
            tagBuilder.InnerHtml = this.Component.HtmlProperties.InnerHtml;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateSushiNavigationItemHeader();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    

    }
}
