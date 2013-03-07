using System;
using System.Web.Mvc;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class HtmlResolver
    {
        public static String GenerateHtmlValidId(this ViewContext view, Type Component)
        {
             string prefix= Component.Name;
             string key = prefix.Replace("´1", "").Replace("`1", "");
                int seq = 1;
                if (view.HttpContext.Items.Contains(key))
                {
                    seq = (int)view.HttpContext.Items[key] + 1;
                    view.HttpContext.Items[key] = seq;
                }
                else
                    view.HttpContext.Items.Add(key, seq);
                return key + seq.ToString();
            
        }

        public static String GenerateHtmlAttributeString(HtmlAttributes attributeId)
        {
            switch (attributeId)
            {
                case HtmlAttributes.data_toggle:
                    return "data-toggle";
                default:
                    return attributeId.ToString();
            }
            
        }
    }
}
