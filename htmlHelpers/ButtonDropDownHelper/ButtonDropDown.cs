using System;
using System.Web.Mvc;
using Sushi.ButtonGroupHelper;
using Sushi.ButtonHelper;
using Sushi.Enums;

namespace Sushi.ButtonDropDownHelper
{
    public class ButtonDropDown:ISushiComponentBuilder
    {

        #region Properties
        public ViewContext ViewContext { get; private set; }
        private ButtonDropDownComponent Component { get; set; }
        #endregion

        #region Fluent Button Setters
        /// <summary>
        /// Sets the behaviour of the Client Html, can be a <c>Submit</c>, <c>Button</c> or <c>link</c>
        ///  </summary>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        public ButtonDropDown SetBehaviour(HtmlBehaviourType behaviour)
        {
            this.Component.Button.Behaviour = behaviour;
            return this;
        }

        public ButtonDropDown SetSize(ButtonSize size)
        {
            this.Component.Button.Size = size;
            return this;
        }

        public ButtonDropDown SetType(ButtonType type)
        {
            this.Component.Button.Type = type;
            return this;
        }

        public ButtonDropDown SetAction(String action)
        {
            this.Component.Button.Action = action;
            return this;
        }

        /// <summary>
        /// Set the name Attribute in client Html
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ButtonDropDown SetName(string name)
        {
            this.Component.Button.HtmlProperties.Name = name;
            return this;
        }

        /// <summary>
        /// Set Caption of the Button
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ButtonDropDown SetCaption(string value)
        {
            this.Component.Button.HtmlProperties.Value = value;
            return this;
        }
        #endregion
        
        #region Constructor
        public ButtonDropDown(ViewContext view)
        {
            this.ViewContext = view;
            this.Component = new ButtonDropDownComponent();
            
        }
        #endregion

        #region StringBuilders

        private String CreateDropDownSimpleButton()
        {
            var group = new ButtonGroup(this.ViewContext);
            this.Component.Button.Behaviour = HtmlBehaviourType.Link;
            this.Component.Button.HtmlProperties.AddHtmlAttribute(HtmlAttributes.data_toggle, "dropdown"); 
            this.Component.Button.Action = "#";
            this.Component.Button.HtmlProperties.Value += this.Component.Button.HtmlProperties.Value +
                                                          "<span class=\"caret\"></span>";
            var button = new Button(this.ViewContext,this.Component.Button);
            group.AddButton(button);
            return group.ToString();

        }

        #endregion

        #region IHtmlString

        public override String ToString()
        {
            return CreateDropDownSimpleButton();
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion
    }
}
