using System;
using Sushi.Enums;

namespace Sushi.Resolvers
{
    public static class GridResolver
    {
        public static String ResolveSize(GridSize gridSize)
        {
            switch (gridSize)
            {
                case GridSize.span1:
                    return "span1";
                case GridSize.span2:
                    return "span2";
                case GridSize.span3:
                    return "span3";
                case GridSize.span4:
                    return "span4";
                case GridSize.span5:
                    return "span5";
                case GridSize.span6:
                    return "span6";
                case GridSize.span7:
                    return "span7";
                case GridSize.span8:
                    return "span8";
                case GridSize.span9:
                    return "span9";
            }
            return "span2";
        }
    }
}
