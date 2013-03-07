using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.SideBarHelper
{
    public class SideBar : ISushiComponentBuilder, ISushiContainer
    {
        #region Constants
        private const string CssBaseclass = "well sidebar-nav";
        #endregion

        public ViewContext ViewContext { get; private set; }
        private SideBarComponent Component { get; set; }
        #region Extended Properties
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        
        #region Fluent SideBar Setters
        public SideBar AddElement(ISushiComponentBuilder Element)
        {
            this.ContainerElements.Add(Element);
            return this;
        }

        public SideBar AddInnerHTML(String Html)
        {
            this.Component.InnerHtml += Html;
            return this;
        }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SideBar SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

       #endregion

        #region Constructor
        public SideBar(ViewContext view)
        {
            this.Component = new SideBarComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.InnerHtml = String.Empty;
            this.ViewContext = view;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
        }
        
        #endregion

        #region StringBuilders

        private void SetCssClasses(ref TagBuilder tagBuilder)
        {
            tagBuilder.AddCssClass(CssBaseclass);
        }

         #endregion

        #region IHtmlString

        public override String ToString()
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            if (!String.IsNullOrEmpty(this.Component.HtmlProperties.Id)) tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            if (!String.IsNullOrEmpty(this.Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name); 
            SetCssClasses(ref tagBuilder);
            if (ContainerElements.Count >0)
            {
                foreach (var sushiHelper in ContainerElements)
                {
                    tagBuilder.InnerHtml += sushiHelper.ToHtmlString();
                }
            }
            if (!String.IsNullOrEmpty(this.Component.InnerHtml)) tagBuilder.InnerHtml += this.Component.InnerHtml;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
