using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;
using Sushi.LinkHelper;
using Sushi.Resolvers;

namespace Sushi.NavigationHelper
{
    public class Navigation:ISushiComponentBuilder, ISushiContainer
    {
        
        #region Builder Properties
        public ViewContext ViewContext { get; internal set; }
        internal NavigationComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Navigation SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public Navigation SetId(String id)
        {
            this.Component.HtmlProperties.Id = id;
            return this;
        }

        public Navigation SetType(NavType type)
        {
            this.Component.NavigationType = type;
            return this;
        }

       
        public Navigation AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        public Navigation AddLink(Link Link)
        {
            Link.ViewContext = this.ViewContext;
            this.ContainerElements.Add(Link);
            return this;
        }

        #endregion
  
        #region Constructor
        public Navigation(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new NavigationComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.NavigationType = NavType.menu;
        }

        public Navigation(String Id)
        {
            this.Component = new NavigationComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.HtmlProperties.Id = Id;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.NavigationType = NavType.menu;
        }

        public Navigation(ViewContext view, NavigationComponent Navigation)
        {
            this.ViewContext = view;
            this.Component = Navigation;
        }
        #endregion

        #region StringBuilders


        private String CreateSushiNavigationItem()
        {
            var tagBuilder = new TagBuilder("ul");
            if (this.Component.HtmlProperties != null)
            {
                tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
                if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            }
            tagBuilder.AddCssClass(NavResolver.ResolveNavigationType(this.Component.NavigationType));
            
            //Bucle para añadir Hijos
            foreach (var sushiComponentBuilder in ContainerElements)
            {
                if (sushiComponentBuilder.GetType() != typeof(NavigationItem) && sushiComponentBuilder.GetType() != typeof(NavigationItemHeader))
                {
                    NavigationItem builder = new NavigationItem(ViewContext);
                    builder.AddElement(sushiComponentBuilder);
                    tagBuilder.InnerHtml += builder.ToString();
                }
                else
                {
                    tagBuilder.InnerHtml += sushiComponentBuilder.ToString();
                }
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
