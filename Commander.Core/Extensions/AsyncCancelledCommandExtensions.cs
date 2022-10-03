using Commander.Core.Commands;
using Commander.Core.Managers;

namespace Commander.Core.Extensions;

public static class AsyncCancelledCommandExtensions
{
    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        if (!CommandManager.Contains(obj, command))
            return;

        CommandManager.Remove(obj, command);

        await command.UndoAsync(obj, cancellationToken);
    }

    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        foreach (var obj in objects)
        {
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);

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
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);

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
        foreach (var command in asyncCancelledCommands)
        {
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);

            await command.UndoAsync(obj, cancellationToken);
        }
    }
}