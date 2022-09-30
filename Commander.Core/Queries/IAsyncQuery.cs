namespace Commander.Core.Queries;

public interface IAsyncQuery<in TIn, TOut>
{
    protected internal Task<TOut> ExecuteAsync(TIn obj, CancellationToken cancellationToken);
}