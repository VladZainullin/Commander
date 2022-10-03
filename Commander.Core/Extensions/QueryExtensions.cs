using Commander.Core.Queries;

namespace Commander.Core.Extensions;

public static class QueryExtensions
{
    public static TOut Action<TIn, TOut>(
        this TIn obj,
        IQuery<TIn, TOut> query)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (query == null) throw new ArgumentNullException(nameof(query));

        return query.Execute(obj);
    }
}