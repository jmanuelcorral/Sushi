using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Sushi.ButtonHelper;
using Sushi.Html;
using System.Collections.ObjectModel;

namespace Sushi.ButtonGroupHelper
{
    public class ButtonGroup:ISushiComponentBuilder,ISushiContainer
    {
        public ViewContext ViewContext { get; private set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        private ButtonGroupComponent Component { get; set; }


        #region Fluent SideBar Setters
        public ButtonGroup AddButton(Button Element)
        {
            this.ContainerElements.Add(Element);
            return this;
        }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ButtonGroup SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

       #endregion

        #region Constructor
        public ButtonGroup(ViewContext view)
        {
            this.Component = new ButtonGroupComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.ViewContext = view;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
            this.Component.Skin = new ButtonGroupSkin();
        }

       
        #endregion

        #region StringBuilders

        private void SetCssClasses(ref TagBuilder tagBuilder)
        {
            tagBuilder.AddCssClass(this.Component.Skin.CssBaseclass);
        }

         #endregion

        #region IHtmlString

        public override String ToString()
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Id)) tagBuilder.Attributes.Add("id", Component.HtmlProperties.Id);
            if (!String.IsNullOrEmpty(Component.HtmlProperties.Name)) tagBuilder.Attributes.Add("name", this.Component.HtmlProperties.Name); 
            SetCssClasses(ref tagBuilder);
            if (ContainerElements.Count >0)
            {
                foreach (var sushiHelper in ContainerElements)
                {
                    tagBuilder.InnerHtml += sushiHelper.ToHtmlString();
                }
            }
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
