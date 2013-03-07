using System;
using System.Collections.Generic;
using System.Text;

namespace Sushi.Helpers.Gridhelper
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
            foreach (var script in scriptCollection)
            {
                result.Append(script);
            }
            return result.ToString();
        }

        public GridScripts()
        {
            scriptCollection = new Stack<string>();
        }
    }
}