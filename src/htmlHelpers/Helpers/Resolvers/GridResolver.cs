using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class GridResolver
    {
        public static String ResolveSize(GridSize gridSize)
        {
            switch (gridSize)
            {
                case GridSize.span1:
                    return "col-md-1";
                case GridSize.span2:
                    return "col-md-2";
                case GridSize.span3:
                    return "col-md-3";
                case GridSize.span4:
                    return "col-md-4";
                case GridSize.span5:
                    return "col-md-5";
                case GridSize.span6:
                    return "col-md-6";
                case GridSize.span7:
                    return "col-md-7";
                case GridSize.span8:
                    return "col-md-8";
                case GridSize.span9:
                    return "col-md-9";
                case GridSize.span10:
                    return "col-md-10";
                case GridSize.span11:
                    return "col-md-11";
                case GridSize.span12:
                    return "col-md-12";
            }
            return "col-md-2";
        }
    }
}
