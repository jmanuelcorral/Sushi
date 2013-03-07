using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class LayoutManager
    {
        public static String ResolveLayout(LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Fixed:
                    return "fixed";
                case LayoutType.Fluid:
                    return "row-fluid";
            }
            return "fixed";
        }

        public static String ResolveContainerLayout(ContainerLayoutType layoutType)
        {
            switch (layoutType)
            {
                case ContainerLayoutType.Fixed:
                    return "container-fixed";
                case ContainerLayoutType.Fluid:
                    return "container-fluid";
            }
            return "container-fluid";
        }
    }
}
