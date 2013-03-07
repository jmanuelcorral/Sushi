namespace Sushi.Helpers.FieldHelper
{
    public class SearchBoxSkin:ISushiSkin
    {
        public string CssBaseclass { get { return "navbar-search"; } }
        public string PullLeftclass { get { return "pull-left"; } }
        public string PullRightclass { get { return "pull-right"; } }
        public string SearchBoxQueryclass { get { return "search-query"; } }
    }
}
