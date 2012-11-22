using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.ButtonGroupHelper;
using Sushi.Html;
using Sushi.NavigationHelper;

namespace Sushi.DropDownHelper
{
    public class DropDown:ISushiComponentBuilder, ISushiContainer
    {
           
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private DropDownComponent Component { get; set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DropDown SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        public DropDown SetId(String id)
        {
            this.Component.HtmlProperties.Id = id;
            return this;
        }

        
        public DropDown AddElement(ISushiComponentBuilder element)
        {
            this.ContainerElements.Add(element);
            return this;
        }

        public DropDown AddNavigationDropDown(NavigationDropDown navDropDown)
        {
            navDropDown.ViewContext = this.ViewContext;
            navDropDown.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext, navDropDown.GetType());
            return this;
        }
        #endregion
  
        #region Constructor
        public DropDown(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new DropDownComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.Skin = new DropDownSkin();
        }

        public DropDown(String Id)
        {
            this.Component = new DropDownComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.HtmlProperties.Id = Id;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.Skin = new DropDownSkin();
        }

        public DropDown()
        {
            this.Component = new DropDownComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.Skin = new DropDownSkin();
        }
        #endregion

        #region StringBuilders


        private String CreateSushiDropDown()
        {
            var tagBuilder = new TagBuilder("ul");
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Id)) tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            tagBuilder.AddCssClass(this.Component.Skin.CssBaseclass);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name);
            //Bucle para añadir Hijos
            foreach (var sushiComponentBuilder in ContainerElements)
            {
                if (sushiComponentBuilder.GetType() == typeof(DropDownHeaderItem))
                {
                    DropDownHeaderItem builder = new DropDownHeaderItem(this.ViewContext);
                    builder.AddElement(sushiComponentBuilder);
                    tagBuilder.InnerHtml += builder.ToString();
                }
                else
                {
                    DropDownItem builderC = new DropDownItem();
                    builderC.AddElement(sushiComponentBuilder);
                    tagBuilder.InnerHtml += builderC.ToString();
                }
            }
            //Fin Bucle
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateSushiDropDown();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    
    }
}
