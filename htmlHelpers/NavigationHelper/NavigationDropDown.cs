using System;
using System.Web.Mvc;
using Sushi.DropDownHelper;
using Sushi.Enums;
using Sushi.Html;
using Sushi.LinkHelper;
using Sushi.Resolvers;
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
            this.Component.Caption = value;
            return this;
        }

        //public NavigationDropDown SetIcon(Icon iconType, IconColor color)
        //{
        //    this.Component.Link.SetIcon(iconType, color);
        //    return this;
        //}

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
            //this.Component.Link = new Link("Link_" + Id);
            this.Component.NavigationItem = new NavigationItem("NI_" + Id);
            
        }

        public NavigationDropDown()
        {
            this.Component = new NavigationDropDownItemComponent();
            this.Component.HtmlProperties = new HtmlProperties();
            this.Component.DropDownMenu = new DropDown();
            //this.Component.Link = new Link();
            this.Component.NavigationItem = new NavigationItem();

        }

        #endregion

        #region StringBuilders


        private String CreateSushiNavigationDropDownItem()
        {
            TagBuilder uBuilder = new TagBuilder("ul");
            uBuilder.AddCssClass("nav");
            var liBuilder = new TagBuilder("li");
            liBuilder.AddCssClass("dropdown");
            TagBuilder aBuilder = new TagBuilder("a");
            aBuilder.AddCssClass("dropdown-toggle");
            aBuilder.InnerHtml = this.Component.Caption + "<b class=\"caret\"></b>";
            aBuilder.Attributes.Add(HtmlResolver.GenerateHtmlAttributeString(HtmlAttributes.data_toggle), "dropdown");
            liBuilder.InnerHtml = aBuilder.ToString(TagRenderMode.Normal) + this.Component.DropDownMenu.ToString();
            uBuilder.InnerHtml = liBuilder.ToString(TagRenderMode.Normal);
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
