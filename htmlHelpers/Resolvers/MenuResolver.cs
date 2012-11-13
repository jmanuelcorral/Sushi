using System;
using Sushi.Enums;

namespace Sushi.Resolvers
{
    public static class MenuResolver
    {

        public static String ResolvePosition(MenuPosition menuPosition)
        {
            switch (menuPosition)
            {
                    case MenuPosition.FixedTop:
                        return "navbar-fixed-top";
                    case MenuPosition.UnFixed:
                        return String.Empty;
            }
            return "navbar-fixed-top";
        }

    }
}
