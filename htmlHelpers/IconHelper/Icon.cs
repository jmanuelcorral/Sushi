using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Sushi.Enums;

namespace Sushi.IconHelper
{
    public class Icon:IHtmlString
    {
        private IconComponent component;
        
        public Icon()
        {
            component = new IconComponent();
            
        }

        public Icon SetIconType(Enums.Icon iconType)
        {
            this.component.IconType = iconType;
            return this;
        }

        public Icon SetIconColor(Enums.IconColor color)
        {
            this.component.Color = color;
            return this;
        }

        public String ToString()
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
