using Microsoft.Extensions.Primitives;

namespace Shared.Pagination;

public static class PagedListExtensions
{
    public static StringValues GetPaginationHeaders<TEntity>(this PagedList<TEntity> pagedList)
    {
        return new StringValues($"page: {pagedList.IndexPage}; totalPage: {pagedList.TotalPage}," +
                                $"pageSize: {pagedList.PageSize}, itemsCount: {pagedList.ItemsCount}");
    }
}