using Sushi.DropDownHelper;
using Sushi.Html;
using Sushi.LinkHelper;

namespace Sushi.NavigationHelper
{
    public class NavigationDropDownItemComponent:ISushiComponent
    {
          public HtmlProperties HtmlProperties { get; set; }
          public string Caption { get; set; }
          //public Link Link { get; set; }
          public NavigationItem NavigationItem { get; set; }
          public DropDown DropDownMenu { get; set; }
        
    }
}
