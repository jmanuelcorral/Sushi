using System.Web;
using System.Web.Mvc;

namespace Sushi.Helpers
{
    public interface ISushiComponentBuilder : IHtmlString
    {
        ViewContext ViewContext { get; }
    }
}
