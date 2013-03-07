using System;
using System.Web.Mvc;

namespace htmlHelpers.Extensions
{
    public enum ButtonColor
    {
        BlueButton,
        GrayButton
    }
    public static class ActionsExtensions
    {

        public static MvcHtmlString Actions(this HtmlHelper helper, String SubmitTextButton, ButtonColor SubmitColor,String CancelTextButton, ButtonColor CancelColor )
        {
            var panelBuilder = CreatePanel("actions");
            var OkButton = CreateButton(SubmitTextButton, SubmitColor);
            var CancelButton = CreateButton(CancelTextButton, CancelColor);
            panelBuilder.InnerHtml = OkButton.ToString(TagRenderMode.SelfClosing) +
                                     CancelButton.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(panelBuilder.ToString());
        }

        private static TagBuilder CreateButton(String Text, ButtonColor color)
        {
            String cssClass = "btn ";
            switch (color)
            {
                case ButtonColor.BlueButton:
                    cssClass = cssClass + "primary";
                    break;
                case ButtonColor.GrayButton:
                    break;
            }
            return CreateButton(Text, cssClass);
        }

        private static TagBuilder CreateButton(String Text, String cssClass)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", Text);
            input.AddCssClass(cssClass);
            return input;
        }

        private static TagBuilder CreatePanel(String cssClass)
        {
            TagBuilder panelBuilder = new TagBuilder("div");
            panelBuilder.AddCssClass(cssClass);
            return panelBuilder;
        }
    }
}