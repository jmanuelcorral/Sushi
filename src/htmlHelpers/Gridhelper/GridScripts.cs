using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Sushi.Gridhelper
{
    public class GridScripts:ISushiScript
    {
        private Stack<String> scriptCollection;

        public void AddScript(String Script)
        {
            scriptCollection.Push(Script);
        }

        public String GetGeneratedScript()
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tag = new TagBuilder("script");
            foreach (var script in scriptCollection)
            {
                result.Append(script);
            }
            tag.Attributes.Add("type","text/javascript");
            tag.InnerHtml = result.ToString();
            return tag.ToString(TagRenderMode.Normal);
        }

        public GridScripts()
        {
            scriptCollection = new Stack<string>();
        }
    }
}