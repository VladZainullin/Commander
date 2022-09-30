namespace Commander.Core.Commands;

public interface IAsyncCancelledCommand<in TIn> : IAsyncCommand<TIn>
{
    protected internal Task UndoAsync(TIn obj, CancellationToken cancellationToken);
}