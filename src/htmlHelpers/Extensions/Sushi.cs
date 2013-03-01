using System.Web.Mvc;

namespace Sushi.Extensions
{
    public static class SushiExtension
    {
        /// <summary>
        /// Loads Sushi Helpers Framework
        /// </summary>
        /// <param name="helper">Implicit <c>HtmlHelper</c> from view</param>
        /// <returns></returns>
        public static SushiFactory Sushi(this HtmlHelper helper)
        {
            return new SushiFactory(helper.ViewContext);
        }


        /// <summary>
        /// Loads Sushi Helpers Framework
        /// </summary>
        /// <param name="helper">Implicit <c>HtmlHelper</c> from view</param>
        /// <returns></returns>
        public static SushiFactory<TModel> Sushi<TModel>(this HtmlHelper<TModel> helper)
        {
            return new SushiFactory<TModel>(helper.ViewContext);
        }
    }
}
