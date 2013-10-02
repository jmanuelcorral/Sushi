using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class NavResolver
    {
        public static String ResolveNavigationType(NavType type)
        {
            switch (type)
            {
                    case NavType.menu:
                    return "nav navbar-nav";
                    case NavType.pill:
                    return "nav nav-pills";
                    case NavType.tab:
                    return "nav nav-tabs";
                    case NavType.stackedtab:
                    return "nav nav-tabs nav-stacked";
                    case NavType.stackedpill:
                    return "nav nav-pills nav-stacked";
                    case NavType.navlist:
                    return "nav nav-list";
            }
            return "nav navbar-nav";
        }
    }
}
