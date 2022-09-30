using Commander.Core.Queries;

namespace Commander.Core.Extensions;

public static class AsyncQueryExtensions
{
    public static async Task<TOut> ActionAsync<TIn, TOut>(
        this TIn obj,
        IAsyncQuery<TIn, TOut> query,
        CancellationToken cancellationToken)
    {
        return await query.ExecuteAsync(obj, cancellationToken);
    }
}