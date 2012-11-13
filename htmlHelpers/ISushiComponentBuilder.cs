using System.Web;
using System.Web.Mvc;

namespace Sushi
{
    public interface ISushiComponentBuilder : IHtmlString
    {
        ViewContext ViewContext { get; }
    }
}
