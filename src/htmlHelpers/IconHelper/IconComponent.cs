using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sushi.Enums;

namespace Sushi.IconHelper
{
    class IconComponent
    {
        public IconColor Color { get; set; }
        public Enums.Icon IconType { get; set; }

        public IconComponent()
        {
            Color = IconColor.Black;
            IconType = Enums.Icon.IconAsterisk;
        }
    }
}
