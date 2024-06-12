using MessageService.Shared;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Extensions;

public static class PagedListExtensions
{
    public static async Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> query, int page, int pageSize)
    {
        var totalCount = await query.CountAsync();
        query = query.Skip((page - 1) * pageSize).Take(pageSize);
        return new PagedList<T>(await query.ToListAsync(), page, pageSize, totalCount);
    }
}