using Sushi.Helpers.DropDownHelper;
using Sushi.Helpers.Html;
using Sushi.Helpers.IconHelper;

namespace Sushi.Helpers.NavigationHelper
{
    public class NavigationDropDownItemComponent:ISushiComponent
    {
          public HtmlProperties HtmlProperties { get; set; }
          public string Caption { get; set; }
          //public Link Link { get; set; }
          public NavigationItem NavigationItem { get; set; }
          public DropDown DropDownMenu { get; set; }
          public Icon LinkIcon { get; set; }
    }
}
