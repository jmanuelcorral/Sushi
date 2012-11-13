using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Html;

namespace Sushi.NavigationHelper
{
    public class NavigationItem:ISushiComponentBuilder, ISushiContainer
    {

        #region CSS Classes
        private const string cssActiveClass = "active";
        #endregion

        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private NavigationItemComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NavigationItem SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public NavigationItem SetActive()
        {
            this.Component.Active = true;
            return this;
        }

        public NavigationItem AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        public NavigationItem AddCssClass(string value)
        {
            this.Component.cssClasses.Add(value);
            return this;
        }

        #endregion
  
        #region Constructor
        public NavigationItem(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new NavigationItemComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.Active = false;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.cssClasses = new List<string>();
        }

        public NavigationItem(String Id)
        {
            this.Component = new NavigationItemComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.HtmlProperties.Id = Id;
            this.Component.Active = false;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.cssClasses = new List<string>();
        }


        #endregion

        #region StringBuilders


        private String CreateSushiNavigationItem()
        {
            var tagBuilder = new TagBuilder("li");
            tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            if (this.Component.Active) tagBuilder.AddCssClass(cssActiveClass);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            if (this.Component.cssClasses.Count > 0)
            {
                foreach (var cssClass in this.Component.cssClasses)
                {
                    tagBuilder.AddCssClass(cssClass);
                }
            }
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
           return  CreateSushiNavigationItem();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    

}
}
