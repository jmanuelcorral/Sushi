using System;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.BrandHelper
{
    public class BrandComponent:ISushiComponent, ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String Action { get; set; }
        public ISushiSkin Skin{ get; set; }
        #endregion



    }
}
