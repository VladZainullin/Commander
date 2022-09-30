namespace Commander.Core.Commands;

public interface IAsyncCommand<in TIn>
{
    protected internal Task ExecuteAsync(TIn obj, CancellationToken cancellationToken = default);
}