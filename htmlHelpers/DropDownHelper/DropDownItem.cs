using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Html;

namespace Sushi.DropDownHelper
{
    public class DropDownItem:ISushiComponentBuilder, ISushiContainer
    {
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private DropDownItemComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DropDownItem SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public DropDownItem AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        #endregion
  
        #region Constructor
        public DropDownItem(ViewContext view)
        {
            if (view != null)
            {
                this.ViewContext = view;
                this.Component = new DropDownItemComponent();
                this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
                this.ContainerElements = new Collection<ISushiComponentBuilder>();
            }
        }

        public DropDownItem()
        {
            this.Component = new DropDownItemComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
        }

        #endregion

        #region StringBuilders


        private String CreateSushiDropDownItem()
        {
            var tagBuilder = new TagBuilder("li");
            tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
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
           return  CreateSushiDropDownItem();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
