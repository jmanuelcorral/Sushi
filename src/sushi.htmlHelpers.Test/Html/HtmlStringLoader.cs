using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sushi.htmlHelpers.Test.Html
{

    public enum TextLoad
    {
        TestDefaultGrid10,
        TestDefaultGrid20
    }

    public static class HtmlStringLoader
    {

        private static String Resolve(TextLoad loader)
        {
            switch (loader)
            {
                    case TextLoad.TestDefaultGrid10:
                        return "TestDefaultGrid10.txt";
                    case TextLoad.TestDefaultGrid20:
                        return "TestDefaultGrid20.txt";
                    default:
                    return "";
            }
        }

        public static String GetHtmlStringResource(TextLoad loader)
        {
            return System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\HtmlStrings\\" + Resolve(loader)).Replace("\t","").Replace("\n","").Replace("\r", "");
        }
    }
}
