using Microsoft.EntityFrameworkCore;
using Shared.Pagination;

namespace RelationshipService.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedList<TEntity>> ToPagedList<TEntity>(this IQueryable<TEntity> query,
    int page, int pageSize)
    {
        var itemsCount = await query.CountAsync();
        query = query.Skip((page - 1) * pageSize).Take(pageSize);
        return new PagedList<TEntity>(await query.ToListAsync(), page, itemsCount, pageSize);
    }
}