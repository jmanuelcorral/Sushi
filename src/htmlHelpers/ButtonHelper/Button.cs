using System;
using System.Web.Mvc;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.ButtonHelper
{
    public class Button: ISushiComponentBuilder
    {

        #region Properties
        public ViewContext ViewContext { get; private set; }
        private ButtonComponent Component { get; set; }
        #endregion

        #region Fluent Button Setters
        /// <summary>
        /// Sets the behaviour of the Client Html, can be a <c>Submit</c>, <c>Button</c> or <c>link</c>
        ///  </summary>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        public Button SetBehaviour(HtmlBehaviourType behaviour)
        {
            this.Component.Behaviour = behaviour;
            return this;
        }

        public Button SetSize(ButtonSize size)
        {
            this.Component.Size = size;
            return this;
        }

        public Button SetType(ButtonType type)
        {
            this.Component.Type = type;
            return this;
        }

        public Button SetAction(String action)
        {
            this.Component.Action = action;
            return this;
        }

        public Button AddCssClass(String cssClass)
        {
            this.Component.AddedClasses += " " + cssClass;
            return this;
        }


        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Button SetName(string name)
        {
            this.Component.HtmlProperties.Name = name;
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Button SetCaption(string value)
        {
            this.Component.HtmlProperties.Value = value;
            return this;
        }
        #endregion
        
        #region Constructor
        public Button(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new ButtonComponent();
            this.Component.HtmlProperties = new HtmlProperties(view, this.Component.GetType());
            this.Component.Behaviour = HtmlBehaviourType.Submit;
            this.Component.Action = "#EmptyValue";
            this.Component.HtmlProperties.Value = "#EmptyValue";
            this.Component.Size = ButtonSize.normal;
            this.Component.Type = ButtonType.Default;
            this.Component.State = ButtonState.Enabled;
            this.Component.Skin = new ButtonSkin();
        }

        public Button(ViewContext view, ButtonComponent button)
        {
            this.ViewContext = view;
            this.Component = button;
        }

        #endregion

        #region StringBuilders

        private void SetCssClasses(ref TagBuilder tagBuilder)
            {
                if(!(String.IsNullOrEmpty(this.Component.AddedClasses)))
                {tagBuilder.AddCssClass(this.Component.AddedClasses);}
                if (Component.State == ButtonState.Disabled)
                {
                    tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssDisable);
                }
                switch (Component.Type)
                {
                        case ButtonType.Primary:
                        tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssPrimaryClass);
                            break;
                        case ButtonType.Info:
                            tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssInfoClass);
                            break;
                        case ButtonType.Danger:
                            tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssDangerClass);
                            break;
                        case ButtonType.Success:
                            tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssSuccessClass);
                            break;
                        case ButtonType.Default:
                        default:
                        break;
                        //Nothing
                }
                switch (Component.Size)
                {
                    case ButtonSize.large:
                        tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssLargeClass);
                        break;
                    case ButtonSize.small:
                        tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssSmallClass);
                        break;
                    case ButtonSize.normal:
                    default:
                        tagBuilder.AddCssClass(((ButtonSkin)Component.Skin).CssNormalClass);
                        break;
                }
                tagBuilder.AddCssClass(this.Component.Skin.CssBaseclass);
            }

        private String CreateLinkStringButton()
            {
                TagBuilder tagBuilder= new TagBuilder("a");
                tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
                if (!String.IsNullOrEmpty(this.Component.Action)) tagBuilder.Attributes.Add("href", this.Component.Action);
                tagBuilder.InnerHtml = this.Component.HtmlProperties.Value;
                SetCssClasses(ref tagBuilder);
                return tagBuilder.ToString(TagRenderMode.Normal);
            }
        
        private String CreateButton()
        {
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
            tagBuilder.Attributes.Add("type","button");
            SetCssClasses(ref tagBuilder);
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }

        private String CreateSubmitButton()
        {
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(this.Component.HtmlProperties.HtmlAttributes);
            tagBuilder.Attributes.Add("type","submit");
            SetCssClasses(ref tagBuilder);
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
        #endregion

        #region IHtmlString

        public override String ToString()
        {
            switch (this.Component.Behaviour)
            {
                case HtmlBehaviourType.Link:
                    return CreateLinkStringButton();
                case HtmlBehaviourType.Button:
                    return CreateButton();
                case HtmlBehaviourType.Submit:
                default:
                    return CreateSubmitButton();
            }
        }

        

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
