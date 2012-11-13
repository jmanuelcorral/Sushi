using System;
using System.Web.Mvc;
using Sushi.Html;

namespace Sushi.LabelHelper
{
    public class Label:ISushiComponentBuilder
    {
        #region Constants
        private LabelComponent Component { get; set; }
        #endregion

        public ViewContext ViewContext { get; private set; }

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in Label
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Label SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        /// <summary>
        /// Sets the Label Caption
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Label SetValue(string value)
        {
            this.Component.HtmlProperties.AddHtmlAttribute(Enums.HtmlAttributes.value, value);
            return this;
        }

        /// <summary>
        /// Sets the id of the label
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Label SetId(string id)
        {
            this.Component.HtmlProperties.Id = id;
            return this;
        }

        public Label SetFor(String For)
        {
            this.Component.For = For;
            return this;
        }
        #endregion

    
        #region Constructor
        public Label(ViewContext view)
        {
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ViewContext = view;
        }

        
        #endregion

   
        #region IHtmlString
    
        private String CreateLabelFor()
        {
            TagBuilder tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            tagBuilder.Attributes.Add("for", this.Component.For);
            tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            tagBuilder.InnerHtml = this.Component.HtmlProperties.Value;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public override String ToString()
        {
            return CreateLabelFor();
        }
        

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
