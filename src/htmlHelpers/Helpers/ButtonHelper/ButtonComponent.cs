﻿using System;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.ButtonHelper
{
    /// <summary>
    /// Button class for Sushi Framework
    /// </summary>
    public class ButtonComponent : ISushiComponent, ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        public ButtonSize Size { get; set; }
        public ButtonState State { get; set; }
        public ButtonType Type { get; set; }
        public HtmlBehaviourType Behaviour { get; set; }
        public String Action { get; set; }
        public String AddedClasses { get; set; }
        #endregion
     
    }
}
