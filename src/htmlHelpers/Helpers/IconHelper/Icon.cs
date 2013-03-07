using System;
using System.Web;
using System.Web.Mvc;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.IconHelper
{
    public class Icon:IHtmlString
    {
        private IconComponent component;
        
        public Icon()
        {
            component = new IconComponent();
            
        }

        public Icon SetIconType(Helpers.Enums.Icon iconType)
        {
            this.component.IconType = iconType;
            return this;
        }

        public Icon SetIconColor(IconColor color)
        {
            this.component.Color = color;
            return this;
        }

        public override String ToString()
        {
            TagBuilder icontag = new TagBuilder("i");
            icontag.AddCssClass(Resolvers.IconManager.ResolveIcon(component.IconType));
            string color = Resolvers.IconManager.ResolveColor(component.Color);
            if (!String.IsNullOrEmpty(color)) icontag.AddCssClass(color);
            return icontag.ToString(TagRenderMode.Normal);
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
