using System;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.FormHelper;
using Sushi.InputHelper;


namespace Sushi.FieldHelper
{
    public class SearchBox:ISushiComponentBuilder
    {
        #region Builder Properties
        public ViewContext ViewContext { get; private set; }
        private SearchBoxComponent Component { get; set; }
        public MenuItemType ItemType { get; private set; }
        private MenuSearchPosition SearchPosition { get; set; }
        public int Position { get; set; }
        #endregion

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SearchBox SetFormName(string name)
        {
            this.Component.Form.SetName(name);
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SearchBox SetInputValue(string value)
        {
            this.Component.Input.SetValue(value);
            return this;
        }

        public SearchBox SetInputSize(GridSize size)
        {
            this.Component.Input.SetSize(size);
            return this;
        }

        public SearchBox SetType (MenuItemType type)
        {
            this.ItemType = type;
            return this;
        }

        public SearchBox SetPositionSearch(MenuSearchPosition position)
        {
            this.SearchPosition = position;
            return this;
        }

        #endregion
  
        #region Constructor
        public SearchBox(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new SearchBoxComponent();
            this.Component.Form = new Form(view);
            this.Component.Input = new Input(view);
        }
        #endregion

        #region StringBuilders

      
        private String CreateSushiSearchBox()
        {
            //var tagBuilder = new TagBuilder("form");
            //tagBuilder.Attributes.Add("id", this.Component.HtmlProperties.Id);
            switch (this.SearchPosition)
            {
                case MenuSearchPosition.left:
                    this.Component.Form.AddCssClass(((SearchBoxSkin)this.Component.Skin).PullLeftclass);
                    break;
                case MenuSearchPosition.right:
                    this.Component.Form.AddCssClass(((SearchBoxSkin)this.Component.Skin).PullRightclass);
                    break;
            }
            
            this.Component.Form.AddCssClass(this.Component.Skin.CssBaseclass);
            
            //var textBuilder = new TagBuilder("input") {InnerHtml = Component.HtmlProperties.Value};
            this.Component.Input.AddCssClass(((SearchBoxSkin)this.Component.Skin).SearchBoxQueryclass);
            this.Component.Input.AddAttribute("placeholder", "Search");
            this.Component.Form.AddElement(this.Component.Input);
            return this.Component.Form.ToString();
        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateSushiSearchBox();
        }


       public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    
    }
}
