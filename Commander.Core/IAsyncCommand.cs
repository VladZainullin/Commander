namespace Commander.Core;

public interface IAsyncCommand<in TIn>
{
    protected internal Task ExecuteAsync(TIn obj, CancellationToken cancellationToken);
}