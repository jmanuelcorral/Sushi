using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class MenuResolver
    {

        public static String ResolvePosition(MenuPosition menuPosition)
        {
            switch (menuPosition)
            {
                    case MenuPosition.FixedTop:
                        return "navbar-fixed-top";
                    case MenuPosition.FixedBottom:
                        return "navbar-fixed-bottom";
                    case MenuPosition.UnFixed:
                        return String.Empty;
            }
            return "navbar-fixed-top";
        }

    }
}
