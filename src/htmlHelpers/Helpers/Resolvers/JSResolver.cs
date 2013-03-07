using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sushi.Helpers.Resolvers
{
    public static class JSResolver
    {
        public static String JSKey()
        {
            return "_sushi_scripts_";
        }

        public static Stack<String> JSStack(ViewContext context)
        {
            var stack = context.HttpContext.Items[JSKey()] as Stack<String>;
            if (stack == null)
            {
                stack = new Stack<string>();
                context.HttpContext.Items.Add(JSKey(), stack);
            }
            else
            {
                context.HttpContext.Items[JSKey()] = stack;
            }
            return stack;
        }
    }
}
