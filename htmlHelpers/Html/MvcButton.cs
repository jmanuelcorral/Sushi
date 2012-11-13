using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace htmlHelpers.Html
{
    public class MvcButton
    {
        #region Enums

        public enum HtmlBehaviourType
        {
            Link,
            Button,
            Submit
        }

        public enum ButtonType
        {
            Primary,
            Default,
            Info,
            Success,
            Danger
        }

        public enum ButtonState
        {
            Enabled,
            Disabled
        }

        public enum ButtonSize
        {
            normal,
            large,
            small
        }

        #endregion

        #region Properties
        public String Id { get; set; }
        public String Name { get; set; }
        public String Text { get; set; }
        public ButtonSize Size { get; set; }
        public ButtonState State { get; set; }
        public ButtonType Type { get; set; }
        public HtmlBehaviourType Behaviour { get; set; }
        public String HtmlAttributes { get; set; }
        public String CssAttributes { get; set; }
        #endregion

        #region Constructor
        public MvcButton(String Id, String Text)
        {
            this.CssAttributes = "";
            this.Text = Text;
            this.HtmlAttributes = "";
            this.Size=ButtonSize.normal;
            this.Type=ButtonType.Default;
            this.Name = Id;
            this.Id = Id;
            this.State = ButtonState.Enabled;
            this.Behaviour = HtmlBehaviourType.Button;
        }

        #endregion
    }
}
