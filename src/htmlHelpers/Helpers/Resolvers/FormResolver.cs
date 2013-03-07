using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class FormResolver
    {
        public static String ResolveMenuType(MenuFormType menuFormType)
        {
            switch (menuFormType)
            {
                case MenuFormType.None:
                    return "navbar-form";
                case MenuFormType.Search:
                    return "navbar-search";
            }
            return "navbar-form";
        }
    }
}