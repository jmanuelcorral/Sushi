using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sushi.Enums;

namespace Sushi.Resolvers
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