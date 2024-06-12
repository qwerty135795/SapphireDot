using MessageService.Entities;

namespace MessageService.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> GetUserDialog<T>(this IQueryable<T> query, int userId, int senderId)
    where T : MessageBase
    {
        return query.Where(u => (u.SenderId == userId || u.SenderId == senderId)
                               && (u.ReceiverId == senderId || u.ReceiverId == userId));
    }
}