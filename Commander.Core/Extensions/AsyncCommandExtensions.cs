using Commander.Core.Commands;
using Commander.Core.Managers;

namespace Commander.Core.Extensions;

public static class AsyncCommandExtensions
{
    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        await ExecuteAsync(obj, command, cancellationToken);
    }

    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (command == null) throw new ArgumentNullException(nameof(command));

        foreach (var obj in objects) await ExecuteAsync(obj, command, cancellationToken);
    }

    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands) await ExecuteAsync(obj, command, cancellationToken);
    }

    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        var asyncCommands = commands as IAsyncCommand<TIn>[] ?? commands.ToArray();

        foreach (var obj in objects)
        foreach (var command in asyncCommands)
            await ExecuteAsync(obj, command, cancellationToken);
    }

    private static async Task ExecuteAsync<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken)
    {
        CommandManager.Add(obj, command);
        await command.ExecuteAsync(obj, cancellationToken);
    }
}