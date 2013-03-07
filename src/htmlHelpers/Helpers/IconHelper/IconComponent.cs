using Sushi.Helpers.Enums;

namespace Sushi.Helpers.IconHelper
{
    class IconComponent
    {
        public IconColor Color { get; set; }
        public Helpers.Enums.Icon IconType { get; set; }

        public IconComponent()
        {
            Color = IconColor.Black;
            IconType = Helpers.Enums.Icon.IconAsterisk;
        }
    }
}
