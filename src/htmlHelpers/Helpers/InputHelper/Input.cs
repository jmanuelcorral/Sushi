using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;
using Sushi.Helpers.Resolvers;

namespace Sushi.Helpers.InputHelper
{
    public class Input:ISushiComponentBuilder
    {

        #region Properties
        public ViewContext ViewContext { get; private set; }
        private InputComponent Component { get; set; }
        #endregion

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Input SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public Input SetId(string id)
        {
            this.Component.HtmlProperties.Id = id;
            return this;
        }

        public Input AddCssClass(String cssClass)
        {
            this.Component.CSSClasses.Add(cssClass);
            return this;
        }

        public Input AddAttribute(String attributeName, String attributeValue)
        {
            this.Component.Attributes.Add(attributeName, attributeValue);
            return this;
        }

        public Input SetSize(GridSize size)
        {
            this.Component.Size = size;
            return this;
        }
        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Input SetValue(string value)
        {
            this.Component.HtmlProperties.Value = value;
            return this;
        }
        
        
        #region Constructor
        public Input(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new InputComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.CSSClasses = new List<string>();
            this.Component.Attributes = new Dictionary<string, string>();
        }
        #endregion

        #region StringBuilders

        private void ApplyCss(ref TagBuilder tagBuilder)
        {
            foreach (var externalclass in Component.CSSClasses)
            {
                tagBuilder.AddCssClass(externalclass);
            }
            tagBuilder.AddCssClass(GridResolver.ResolveSize(this.Component.Size));
        }

        private void ApplyAttributes(ref TagBuilder tagBuilder)
        {
            foreach (var externalattribute in Component.Attributes.Keys)
            {
                tagBuilder.Attributes.Add(externalattribute, Component.Attributes[externalattribute]);
            }
            tagBuilder.AddCssClass(GridResolver.ResolveSize(this.Component.Size));
        }

        private String CreateInput()
        {
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            tagBuilder.Attributes.Add("value", this.Component.HtmlProperties.Value);
            tagBuilder.Attributes.Add("type", "text");
            this.ApplyCss(ref tagBuilder);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateInput();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
