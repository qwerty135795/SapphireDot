namespace MessageService.Shared;

public class PagedList<T> : List<T>
{
    public int TotalPages { get; set; }
    public int IndexPage { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }

    public PagedList(IEnumerable<T> items, int page, int pageSize, int count )
    {
        IndexPage = page;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)(Math.Ceiling(count / (double)pageSize));
        AddRange(items);
    }
}