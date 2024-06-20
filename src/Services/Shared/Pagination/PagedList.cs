namespace Shared.Pagination;

public class PagedList<TEntity> : List<TEntity>
{
    public int IndexPage { get; set; }
    public int TotalPage { get; set; }
    public int PageSize { get; set; }
    public int ItemsCount { get; set; }

    public PagedList(IEnumerable<TEntity> items, int indexPage, int itemsCount, int pageSize)
    {
        IndexPage = indexPage;
        ItemsCount = itemsCount;
        PageSize = pageSize;
        TotalPage = (int)Math.Ceiling(itemsCount / (double)pageSize);
        AddRange(items);
    }
}