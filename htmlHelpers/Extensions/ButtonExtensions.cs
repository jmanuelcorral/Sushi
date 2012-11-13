using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using htmlHelpers.Html;

namespace htmlHelpers.Extensions
{
    public static class ButtonExtensions
    {

        #region Begin/End Behaviour Non Strongly Typed

        public static MvcHtmlString Button(this HtmlHelper helper, string Id, String Text)
        {
            MvcButton btn = new MvcButton(Id,Text);
            TagBuilder tagBuilder = CreateButton(btn);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string Id, String Text, MvcButton.ButtonType type)
        {
            MvcButton btn = new MvcButton(Id, Text);
            btn.Type = type;
            TagBuilder tagBuilder = CreateButton(btn);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string Id, String Text, MvcButton.ButtonType type, MvcButton.HtmlBehaviourType behaviour)
        {
            MvcButton btn = new MvcButton(Id, Text);
            btn.Type = type;
            btn.Behaviour = behaviour;
            TagBuilder tagBuilder = CreateButton(btn);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string Id, String Text, MvcButton.ButtonType type, MvcButton.HtmlBehaviourType behaviour, MvcButton.ButtonState state)
        {
            MvcButton btn = new MvcButton(Id, Text);
            btn.Type = type;
            btn.Behaviour = behaviour;
            btn.State = state;
            TagBuilder tagBuilder = CreateButton(btn);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string Id, String Text, MvcButton.ButtonType type, MvcButton.HtmlBehaviourType behaviour, MvcButton.ButtonState state, MvcButton.ButtonSize size)
        {
            MvcButton btn = new MvcButton(Id, Text);
            btn.Type = type;
            btn.Behaviour = behaviour;
            btn.State = state;
            btn.Size = size;
            TagBuilder tagBuilder = CreateButton(btn);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, MvcButton button)
        {
            TagBuilder tagBuilder = CreateButton(button);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
        #endregion

        #region Component Drawer
        private static TagBuilder CreateButton(MvcButton btn)
        {
            var tagBuilder = CreateBehaviouredButton(btn);
            switch (btn.Size)
            {
                    case MvcButton.ButtonSize.large:
                    tagBuilder.AddCssClass("large");
                    break;
                    case MvcButton.ButtonSize.small:
                    tagBuilder.AddCssClass("small");
                    break;
            }
            switch (btn.State)
            {
                    case MvcButton.ButtonState.Disabled:
                    tagBuilder.AddCssClass("disabled");
                    if (btn.Behaviour == MvcButton.HtmlBehaviourType.Button)
                    {
                        tagBuilder.Attributes.Add("disabled", "disabled");
                    }
                    break;
            }
            switch (btn.Type)
            {
                    case MvcButton.ButtonType.Info:
                    tagBuilder.AddCssClass("info");
                    break;
                    case MvcButton.ButtonType.Primary:
                    tagBuilder.AddCssClass("primary");
                    break;
                    case MvcButton.ButtonType.Danger:
                    tagBuilder.AddCssClass("danger");
                    break;
                    case MvcButton.ButtonType.Success:
                    tagBuilder.AddCssClass("success");
                    break;
            }

            return tagBuilder;
        }

        private static TagBuilder CreateBehaviouredButton(MvcButton btn)
        {
            TagBuilder tagBuilder;
            switch (btn.Behaviour)
            {
                case MvcButton.HtmlBehaviourType.Button:
                    tagBuilder = new TagBuilder("input");
                    tagBuilder.Attributes.Add("type", "button");
                    tagBuilder.Attributes.Add("value", btn.Text);
                    break;
                case MvcButton.HtmlBehaviourType.Link:
                    tagBuilder = new TagBuilder("a");
                    tagBuilder.InnerHtml = btn.Text;
                    break;
                case MvcButton.HtmlBehaviourType.Submit:
                default:
                    tagBuilder = new TagBuilder("input");
                    tagBuilder.Attributes.Add("type", "submit");
                    break;
            }
            tagBuilder.AddCssClass("btn");
            return tagBuilder;
        }
        #endregion
    }
}
