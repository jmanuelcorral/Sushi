using System;
using System.Web.Mvc;
using Sushi.DropDownHelper;
using Sushi.Enums;
using Sushi.Html;
using Sushi.LinkHelper;
using Sushi.SeparatorHelper;

namespace Sushi.NavigationHelper
{
    public class NavigationDropDown: ISushiComponentBuilder
    {
        
        #region CSS Classes
        #endregion

        #region Builder Properties
        public ViewContext ViewContext { get; internal set; }
        internal NavigationDropDownItemComponent Component { get; set; }
        #endregion

        #region Fluent Common Setters

       

        public NavigationDropDown SetCaption(String value)
        {
            this.Component.Link.SetCaption(value);
            return this;
        }

        public NavigationDropDown SetIcon(Icon iconType, IconColor color)
        {
            this.Component.Link.SetIcon(iconType, color);
            return this;
        }

        public NavigationDropDown AddLink(Link link)
        {
            link.ViewContext = this.ViewContext;
            this.Component.DropDownMenu.AddElement(link);
            return this;
        }

        public NavigationDropDown AddSeparator()
        {
            this.Component.DropDownMenu.AddElement(new Separator());
            return this;
        }

        public NavigationDropDown AddHeader(String headerText)
        {
            var header = new NavigationItemHeader(ViewContext);
            header.SetValue(headerText);
            this.Component.DropDownMenu.AddElement(header);
            return this;
        }


        #endregion
  
        #region Constructor
        public NavigationDropDown(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new NavigationDropDownItemComponent();
            this.Component.DropDownMenu = new DropDown(view);
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.NavigationItem = new NavigationItem(view);
            
        }

        public NavigationDropDown(String Id)
        {
            this.Component = new NavigationDropDownItemComponent();
            this.Component.HtmlProperties= new HtmlProperties();
            this.Component.HtmlProperties.Id = Id;
            this.Component.DropDownMenu = new DropDown("DD_" +Id);
            this.Component.Link = new Link("Link_" + Id);
            this.Component.NavigationItem = new NavigationItem("NI_" + Id);
            
        }

        #endregion

        #region StringBuilders


        private String CreateSushiNavigationDropDownItem()
        {
            TagBuilder uBuilder = new TagBuilder("ul");
            uBuilder.AddCssClass("nav");
            this.Component.NavigationItem.AddCssClass("dropdown");
            this.Component.Link.Component.HtmlProperties.AddCssClass("dropdown-toggle");
            this.Component.Link.Component.HtmlProperties.InnerHtml +="<b class=\"caret\"></b>";
            this.Component.Link.Component.HtmlProperties.AddHtmlAttribute(HtmlAttributes.data_toggle, "dropdown");
            this.Component.NavigationItem.ContainerElements.Add(this.Component.Link);
            if (this.Component.DropDownMenu.ContainerElements.Count>0)
            {
                this.Component.NavigationItem.ContainerElements.Add(this.Component.DropDownMenu);
            }
            uBuilder.InnerHtml = this.Component.NavigationItem.ToString();
            return uBuilder.ToString(TagRenderMode.Normal);
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateSushiNavigationDropDownItem();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    
    }
}
