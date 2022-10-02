using Commander.Core.Commands;

namespace Commander.Core.Extensions;

public static class AsyncCancelledCommandExtensions
{
    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        await command.UndoAsync(obj, cancellationToken);
    }
    
    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        foreach (var obj in objects)
        {
            await command.UndoAsync(obj, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        foreach (var command in commands)
        {
            await command.UndoAsync(obj, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        var asyncCancelledCommands = commands as IAsyncCancelledCommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach(var command in asyncCancelledCommands)
        {
            await command.UndoAsync(obj, cancellationToken);
        }
    }
}