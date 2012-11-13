using System;
using System.Web.Mvc;
using Sushi.Enums;

namespace Sushi.Resolvers
{
    public static class HtmlResolver
    {
        public static String GenerateHtmlValidId(this ViewContext view, Type Component)
        {
             string prefix= Component.Name;
                string key = "Sushi_" +prefix;
                int seq = 1;
                if (view.HttpContext.Items.Contains(key))
                {
                    seq = (int)view.HttpContext.Items[key] + 1;
                    view.HttpContext.Items[key] = seq;
                }
                else
                    view.HttpContext.Items.Add(key, seq);
                return prefix + seq.ToString();
            
        }

        public static String GenerateHtmlAttributeString(Enums.HtmlAttributes attributeId)
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
