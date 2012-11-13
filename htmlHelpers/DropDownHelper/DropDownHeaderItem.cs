using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Html;

namespace Sushi.DropDownHelper
{
    public class DropDownHeaderItem: ISushiComponentBuilder, ISushiContainer
    {
        
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private DropDownHeaderItemComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DropDownHeaderItem SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public DropDownHeaderItem AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        #endregion
  
        #region Constructor
        public DropDownHeaderItem(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new DropDownHeaderItemComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
        }
        #endregion

        #region StringBuilders


        private String CreateSushiDropDownHeaderItem()
        {
            var tagBuilder = new TagBuilder("li");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            //Bucle para añadir Hijos
            foreach (var sushiComponentBuilder in ContainerElements)
            {
                tagBuilder.InnerHtml += sushiComponentBuilder.ToString();
            }
            //Fin Bucle
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
           return  CreateSushiDropDownHeaderItem();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    
    }
}
