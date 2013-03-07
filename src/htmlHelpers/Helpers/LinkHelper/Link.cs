using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.LinkHelper
{
    public class Link : ISushiComponentBuilder
    {
        #region Builder Properties
        public ViewContext ViewContext { get; internal set; }
        internal LinkComponent Component { get; set; }
        public MenuItemType ItemType { get; private set; }
        public int Position { get; set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Link SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public Link AddCssClass(String cssclass)
        {
            this.Component.cssClasses.Add(cssclass);
            return this;
        }

        public Link SetAction(String action)
        {
            this.Component.Action = action;
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Link SetCaption(string value)
        {
            this.Component.HtmlProperties.InnerHtml = value;
            return this;
        }

        public Link SetIcon(Icon iconType, IconColor color)
        {
            if (this.Component.LinkIcon == null)
            {
                this.Component.LinkIcon = new Helpers.IconHelper.Icon();
            }
            this.Component.LinkIcon.SetIconType(iconType);
            this.Component.LinkIcon.SetIconColor(color);
            return this;
        }

        public Link SetType (MenuItemType type)
        {
            this.ItemType = type;
            return this;
        }

        #endregion
  
        #region Constructor
        public Link(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new LinkComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.Active = false;
            this.ItemType = MenuItemType.Link;
            this.Component.cssClasses = new List<string>();
            this.Component.Attributes = new Dictionary<string, string>();
        }

        public Link(String Id)
        {
            this.Component = new LinkComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.HtmlProperties.Id = Id;
            this.Component.Active = false;
            this.ItemType = MenuItemType.Link;
            this.Component.cssClasses = new List<string>();
            this.Component.Attributes = new Dictionary<string, string>();
        }

        public Link()
        {
            this.Component = new LinkComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.Active = false;
            this.ItemType = MenuItemType.Link;
            this.Component.cssClasses = new List<string>();
            this.Component.Attributes = new Dictionary<string, string>();
        }
        #endregion

        #region StringBuilders


        private String CreateSushiLink()
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
            String css = this.Component.HtmlProperties.GetCSSClassesString();
            if (!String.IsNullOrEmpty(css)) tagBuilder.AddCssClass(css);
            //TODO CAMBIAR Y CREAR PROPIEDAD HREF EN HTML SIMPLE
            tagBuilder.Attributes.Add("href", this.Component.Action);
            if (this.Component.LinkIcon != null)
            {
                tagBuilder.InnerHtml = this.Component.LinkIcon.ToString();
            }
            tagBuilder.InnerHtml += this.Component.HtmlProperties.InnerHtml;
            return tagBuilder.ToString(TagRenderMode.Normal);    
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
           return  CreateSushiLink();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
