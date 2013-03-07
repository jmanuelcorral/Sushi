using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.FormHelper;
using Sushi.Helpers.Html;
using Sushi.Helpers.NavigationHelper;

namespace Sushi.Helpers.MenuHelper
{
    public class Menu:ISushiComponentBuilder, ISushiContainer
    {
        #region Constants
        private const string CssBaseclass = "navbar";
        private const string CssBaseInnerNav = "navbar-inner";
        #endregion

        public ViewContext ViewContext { get; private set; }
        public ICollection<ISushiComponentBuilder> ContainerElements { get; private set; }
        private MenuComponent Component { get; set; }

        #region Fluent Menu Setters

        public Menu SetPosition(MenuPosition position)
        {
            this.Component.Position = position;
            return this;
        }

        public Menu AddNavigation(Navigation navigationBuilder)
        {
            navigationBuilder.ViewContext = this.ViewContext;
            navigationBuilder.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext, navigationBuilder.GetType());
            this.ContainerElements.Add(navigationBuilder);
            return this;
        }

        //public Menu AddNavigation(Navigation navigationBuilder, PullLeft )
        //{
        //    navigationBuilder.ViewContext = this.ViewContext;
        //    navigationBuilder.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext, navigationBuilder.GetType());
        //    this.ContainerElements.Add(navigationBuilder);
        //    return this;
        //}

        public Menu AddNavigationDropDown(NavigationDropDown NavDropDown)
        {
            NavDropDown.ViewContext = this.ViewContext;
            NavDropDown.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext, NavDropDown.GetType());
            this.ContainerElements.Add(NavDropDown);
            return this;
        }

        private Menu AddForm(Form form)
        {
            form.ViewContext = this.ViewContext;
            form.Component.HtmlProperties.Id = Resolvers.HtmlResolver.GenerateHtmlValidId(this.ViewContext, form.GetType());
            this.ContainerElements.Add(form);
            return this;
        }

        public Menu AddSearchForm(Form searchForm)
        {
            searchForm.SetNavFormType(MenuFormType.Search);
            return AddForm(searchForm);

        }

        public Menu AddNavForm(Form form)
        {
            form.SetNavFormType(MenuFormType.None);
            return AddForm(form);
        }



       #endregion

        #region Fluent Common Setters

       #endregion

        #region Constructor
        public Menu(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new MenuComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.InnerHtml = String.Empty;
            this.ContainerElements = new Collection<ISushiComponentBuilder>();
        }

        #endregion

        #region StringBuilders

     
        //private void SetCSSBaseMenuContainerClass(ref TagBuilder tag)
        //{
        //    tag.AddCssClass(LayoutManager.ResolveContainerLayout(this.Component.ContainerType));
        //}

       
        
        //private TagBuilder CreateCollapsableProperties()
        //{
        //    TagBuilder tagBuilder = new TagBuilder("a");
        //    tagBuilder.Attributes.Add("data-toggle", "collapse");
        //    tagBuilder.Attributes.Add("data-target", ".nav-collapse");
        //    tagBuilder.AddCssClass("btn");
        //    tagBuilder.AddCssClass("btn-navbar");
        //    var spanTag = new TagBuilder("span");
        //    spanTag.AddCssClass("icon-bar");
        //    tagBuilder.InnerHtml = spanTag.ToString(TagRenderMode.Normal);
        //    tagBuilder.InnerHtml += spanTag.ToString(TagRenderMode.Normal);
        //    tagBuilder.InnerHtml += spanTag.ToString(TagRenderMode.Normal);
        //    return tagBuilder;
        //}

        

        //private TagBuilder CreateCollapsableMenu()
        //{
        //    TagBuilder tagBuilder = new TagBuilder("div");
        //    tagBuilder.AddCssClass("nav-collapse");
        //    tagBuilder.AddCssClass("collapse");
        //    return tagBuilder;
        //}
        
        #endregion

        #region IHtmlString


        public override String ToString()
        {
            TagBuilder navbar = new TagBuilder("div");
            TagBuilder navbarinner = new TagBuilder("div");
            if (this.Component.Position != MenuPosition.UnFixed) navbar.AddCssClass(Resolvers.MenuResolver.ResolvePosition(this.Component.Position));
            navbar.AddCssClass(CssBaseclass);
            navbarinner.AddCssClass(CssBaseInnerNav);
            foreach (var sushiComponentBuilder in ContainerElements)
            {
                navbarinner.InnerHtml += sushiComponentBuilder.ToString();
            }
            navbar.InnerHtml = navbarinner.ToString(TagRenderMode.Normal);
            return navbar.ToString();
        }



        public String ToHtmlString()
        {
            return this.ToString();
        }
        
        #endregion
    }
}
