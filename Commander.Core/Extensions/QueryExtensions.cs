using Commander.Core.Queries;

namespace Commander.Core.Extensions;

public static class QueryExtensions
{
    public static TOut Action<TIn, TOut>(
        this TIn obj,
        IQuery<TIn, TOut> query)
    {
        return query.Execute(obj);
    }
}