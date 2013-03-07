namespace Sushi.Helpers
{
    public interface ISushiPagedList
    {
        int TotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }     
    }
}
