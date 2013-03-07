using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.Helpers.Javascript
{
    public class JSBuilder
    {
        private Dictionary<String, String> jsLiteralObjectParams;

        public JSBuilder Add(String name, String value)
        {
            if (jsLiteralObjectParams.ContainsKey(name))
            {
                this.jsLiteralObjectParams[name] = value;
            }
            else { this.jsLiteralObjectParams.Add(name, value);}
            return this;
        }

        public String ToLiteralJSObject()
        {
            return ToLiteralJSObject(false);
        }

        public String ToLiteralJSObject(Boolean quotekeys)
        {
            StringBuilder returnBuilder = new StringBuilder();
            returnBuilder.Append("{");
            foreach (var jsLiteralObjectParam in jsLiteralObjectParams)
            {
                if (quotekeys)
                {
                    returnBuilder.AppendFormat(" \"{0}\" : {1},", jsLiteralObjectParam.Key, jsLiteralObjectParam.Value);
                }
                else
                {
                    returnBuilder.AppendFormat(" {0} : {1},", jsLiteralObjectParam.Key, jsLiteralObjectParam.Value);
                }
            }
            returnBuilder.Remove(returnBuilder.Length - 1, 1);
            returnBuilder.Append("}");
            return returnBuilder.ToString();
        }

        public JSBuilder()
        {
            jsLiteralObjectParams = new Dictionary<string, string>();
        }
    }
}
 