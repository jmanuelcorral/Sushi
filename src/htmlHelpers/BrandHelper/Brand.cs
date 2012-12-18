using System;
using System.Web.Mvc;
using Sushi.Html;
using Sushi.LinkHelper;

namespace Sushi.BrandHelper
{
    public class Brand:ISushiComponentBuilder
    {
        
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private BrandComponent Component { get; set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Brand SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public Brand SetAction(String action)
        {
            this.Component.Action = action;
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Brand SetCaption(string value)
        {
            this.Component.HtmlProperties.Value = value;
            return this;
        }

        #endregion
  
        #region Constructor
        public Brand(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new BrandComponent();
            this.Component.Skin = new BrandSkin();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
        }
        #endregion

        #region StringBuilders


        private String CreateSushiLinkBrand()
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            tagBuilder.AddCssClass(this.Component.Skin.CssBaseclass);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            tagBuilder.Attributes.Add("href", this.Component.Action);
            tagBuilder.InnerHtml = this.Component.HtmlProperties.Value;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
           return  CreateSushiLinkBrand();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
     
    }

