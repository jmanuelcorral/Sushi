using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.FormHelper
{
    public class Form:ISushiComponentBuilder,ISushiContainer
    {
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private FormComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; } 
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Form SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Form SetValue(string value)
        {
            this.Component.HtmlProperties.AddHtmlAttribute(HtmlAttributes.value, value);
            return this;
        }

        public Form AddCssClass(String cssClass)
        {
            this.Component.CSSClasses.Add(cssClass);
            return this;
        }
        
        public Form AddElement(ISushiComponentBuilder component)
        {
            this.ContainerElements.Add(component);
            return this;
        }
        #endregion
  
        #region Constructor
        public Form(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new FormComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.CSSClasses = new List<string>();
        }
        #endregion

        #region StringBuilders

        private String CreateSushiForm()
        {
            var tagBuilder = new TagBuilder("form");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            foreach (var externalclass in Component.CSSClasses)
            {
                tagBuilder.AddCssClass(externalclass);
            }

            foreach (var sushiComponentBuilder in ContainerElements)
            {
                tagBuilder.InnerHtml += sushiComponentBuilder.ToString();
            }
            
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateSushiForm();
        }


       public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    
    }
}
