using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using sushi.Helpers.Html;

namespace htmlHelpers.Extensions
{
    public static class StackedFormExtension
    {
        #region Constants
        const string formCssClass = "form-stacked";
        #endregion

        #region Methods

        
       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper,string actionName)
       // {
       //     return BeginStackedForm(helper, actionName, new RouteValueDictionary(), new RouteValueDictionary());
       // }

        
       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, object htmlAttributes)
       // {
       //     return BeginStackedForm(helper, actionName, new RouteValueDictionary(), new RouteValueDictionary(htmlAttributes));
       // }

       //public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, IDictionary<string, object> htmlAttributes)
       //{
       //    return BeginStackedForm(helper, actionName, new RouteValueDictionary(), htmlAttributes);
       //}

       
       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, object actionNameHtmlAttributes, object htmlAttributes)
       // {
       //     return BeginStackedForm(helper, actionName, actionNameCssClass, PanelCssClass, new RouteValueDictionary(actionNameHtmlAttributes), new RouteValueDictionary(htmlAttributes));
       // }

       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, IDictionary<string, object> actionNameHtmlAttributes, IDictionary<string, object> htmlAttributes)
       // {
       //     return BeginStackedForm(helper, actionName, actionNameCssClass, PanelCssClass, actionNameHtmlAttributes, htmlAttributes);
       // }

       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, string panelCssClass)
       // {
       //     return BeginStackedForm(helper, actionName, actionNameCssClass, panelCssClass);
       // }

       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, string actionNameCssClass, string panelCssClass)
       // {
       //     return BeginStackedForm(helper, actionName, actionNameCssClass, panelCssClass, new RouteValueDictionary(), new RouteValueDictionary());
       // }

       // public static mvcStackedForm BeginStackedForm(this HtmlHelper helper, string actionName, string actionNameCssClass, string panelCssClass, object actionNameHtmlAttributes, object formHtmlAttributes)
       // {
       //     return BeginStackedForm(helper, actionName, actionNameCssClass, panelCssClass, new RouteValueDictionary(actionNameHtmlAttributes), new RouteValueDictionary(formHtmlAttributes));
       // }

        public static mvcStackedForm BeginStackedForm(this HtmlHelper helper,
                                          string actionName,
                                          string actionNameCssClass,
                                          string panelCssClass,
                                          IDictionary<string, object> actionNameHtmlAttributes,
                                          IDictionary<string, object> formHtmlAttributes)
        {
            // actionName panel
            TagBuilder actionNameTagBuilder = new TagBuilder("div");
            actionNameTagBuilder.MergeAttributes(actionNameHtmlAttributes);
            actionNameTagBuilder.AddCssClass(actionNameCssClass);
            actionNameTagBuilder.SetInnerText(actionName);

            // content panel
            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttributes(formHtmlAttributes);
            tagBuilder.AddCssClass(panelCssClass);

            HttpResponseBase httpResponse = helper.ViewContext.HttpContext.Response;
            httpResponse.Write(actionNameTagBuilder.ToString(TagRenderMode.Normal));
            httpResponse.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            return new mvcStackedForm(httpResponse);
        }
        
        public static void EndPanel(this HtmlHelper helper)
        {
            HttpResponseBase httpResponse = helper.ViewContext.HttpContext.Response;
            httpResponse.Write("</div>");
        }

        #endregion
    }
}