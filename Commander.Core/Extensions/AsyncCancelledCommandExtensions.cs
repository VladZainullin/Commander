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
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        await UndoAsync(obj, command, cancellationToken);
    }

    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (command == null) throw new ArgumentNullException(nameof(command));

        foreach (var obj in objects)
        {
            await UndoAsync(obj, command, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands)
        {
            await UndoAsync(obj, command, cancellationToken);
        }
    }

    public static async Task CancelAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCancelledCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        var asyncCancelledCommands = commands as IAsyncCancelledCommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach (var command in asyncCancelledCommands)
        {
            await UndoAsync(obj, command, cancellationToken);
        }
    }

    private static async Task UndoAsync<TIn>(
        TIn obj,
        IAsyncCancelledCommand<TIn> command,
        CancellationToken cancellationToken)
    {
        if (!CommandManager.Contains(obj, command))
            return;

        CommandManager.Remove(obj, command);

        await command.UndoAsync(obj, cancellationToken);
    }
}