using Commander.Core.Commands;

namespace Commander.Core.Extensions;

public static class AsyncCommandExtensions
{
    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken)
    {
        await command.ExecuteAsync(obj, cancellationToken);
    }
    
    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken)
    {
        foreach (var obj in objects)
        {
            await command.ExecuteAsync(obj, cancellationToken);
        }
    }
    
    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken)
    {
        foreach (var command in commands)
        {
            await command.ExecuteAsync(obj, cancellationToken);
        }
    }
    
    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken)
    {
        var asyncCommands = commands as IAsyncCommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach (var command in asyncCommands)
        {
            await command.ExecuteAsync(obj, cancellationToken);
        }
    }
    
    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IAsyncCancelledCommand<TIn> query,
        CancellationToken cancellationToken)
    {
        await query.UndoAsync(obj, cancellationToken);
    }
    
    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCancelledCommand<TIn> query,
        CancellationToken cancellationToken)
    {
        foreach (var obj in objects)
        {
            await query.UndoAsync(obj, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken)
    {
        foreach (var command in commands)
        {
            await command.UndoAsync(obj, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken)
    {
        var asyncCancelledCommands = commands as IAsyncCancelledCommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach(var command in asyncCancelledCommands)
        {
            await command.UndoAsync(obj, cancellationToken);
        }
    }
}