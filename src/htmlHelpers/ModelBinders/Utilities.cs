using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.ModelBinders
{
    public static class Utilities
    {

        internal static Dictionary<string, string> UriParametersToDictionary(Uri requestUri)
        {
            Dictionary<String,String> keyValueSolution = new Dictionary<string, string>();
            String namevalQuery = requestUri.Query.Remove(0,1);
            String[] namevalColection = namevalQuery.Split('&');
            foreach (var s in namevalColection)
            {
                string[] namevalue = s.Split('=');
                keyValueSolution.Add(namevalue[0],namevalue[1]);
            }
            return keyValueSolution;
        }
    }
}
