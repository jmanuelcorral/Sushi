using System;
using System.Web.Mvc;
using Sushi.Helpers.Enums;
using Sushi.Helpers.InputHelper;
using Sushi.Helpers.LabelHelper;

namespace Sushi.Helpers.FieldHelper
{
    public class Field:ISushiComponentBuilder
    {
        #region Constants
        private FieldComponent Component { get; set; }
        #endregion

        public ViewContext ViewContext { get; private set; }

        #region Fluent Common Setters

        /// <summary>
        /// Set the name Attribute in Label
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Field SetLabelName(string name)
        {
            this.Component.Label.SetName(name);
            return this;
        }

        /// <summary>
        /// Sets the Label Caption
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Field SetLabelValue(string value)
        {
            this.Component.Label.SetValue(value);
            return this;
        }

        /// <summary>
        /// Sets the id of the label
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Field SetLabelId(string id)
        {
            this.Component.Label.SetId(id);
            return this;
        }
        /// <summary>
        /// Sets the clientID in the input box
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Field SetInputId(String id)
        {
            this.Component.Input.SetId(id);
            return this;
        }

        /// <summary>
        /// Sets the Input Value in the Input box
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Field SetInputValue(String value)
        {
            this.Component.Input.SetValue(value);
            return this;
        }
        /// <summary>
        /// Sets the size in the grid that the element can fill
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Field SetInputGridSize(GridSize size)
        {
            this.Component.Input.SetSize(size);
            return this;
        }

        #endregion

        #region Fluent Setters

        public Field SetType(FieldType type)
        {
            this.Component.Type = type;
            return this;
        }

        #endregion

        #region Constructor
        public Field(ViewContext view)
        {
            this.Component.Input = new Input(view);
            this.Component.Label = new Label(view);
            this.Component.Skin = new FieldSkin();
            this.ViewContext = view;
        }

        
        #endregion

        #region StringBuilders

        private void SetCssClasses(ref TagBuilder tagBuilder)
            {
                tagBuilder.AddCssClass(this.Component.Skin.CssBaseclass);
            }

    #endregion

        #region IHtmlString
        private TagBuilder CreateFieldTag()
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            SetCssClasses(ref tagBuilder);
            return tagBuilder;
        }

        private TagBuilder CreatedivinputTag()
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass(((FieldSkin)this.Component.Skin).CssInputClass);
            return tagBuilder;
        }

     

        //private TagBuilder CreateValidationInput()
        //{
        //    TagBuilder tagBuilder = new TagBuilder("span");
        //    tagBuilder.AddCssClass("field-validation-valid");
        //    tagBuilder.Attributes.Add("data-valmsg-for", this.Component.HtmlInputProperties.Id);
        //    tagBuilder.Attributes.Add("data-valmsg-replace", "true");
        //    return tagBuilder;
        //}

        public override String ToString()
        {
            var divClearfix = CreateFieldTag();
            var divinput = CreatedivinputTag();
            var input = this.Component.Input.ToString();
            var label = this.Component.Label.ToString();
            //var validation = CreateValidationInput();
            //divinput.InnerHtml = String.Concat(input.ToString(TagRenderMode.SelfClosing), validation.ToString(TagRenderMode.Normal));
            divinput.InnerHtml = input;
            divClearfix.InnerHtml = String.Concat(label, divinput.ToString(TagRenderMode.Normal));
            return divClearfix.ToString(TagRenderMode.Normal);
        }
        

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
        

    }
}
