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
        await command.ExecuteAsync(obj, cancellationToken);
    }

    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken = default)
    {
        foreach (var obj in objects) await command.ExecuteAsync(obj, cancellationToken);
    }

    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        foreach (var command in commands)
        {
            CommandManager.Add(obj, command);
            await command.ExecuteAsync(obj, cancellationToken);
        }
    }

    public static async Task ActionAsync<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<IAsyncCommand<TIn>> commands,
        CancellationToken cancellationToken = default)
    {
        var asyncCommands = commands as IAsyncCommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach (var command in asyncCommands)
        {
            CommandManager.Add(obj, command);
            await command.ExecuteAsync(obj, cancellationToken);
        }
    }
}