namespace Sushi.Helpers
{
    public interface ISushiFilter
    {
        bool Pagination { get; set; }
        int ResultsPerPage { get; set; }
        bool ShowTotalResults { get; set; }
        int CurrentPage { get; set; }
        //Object ExecuteFilter(ISushiComponent Component);
    }
}
