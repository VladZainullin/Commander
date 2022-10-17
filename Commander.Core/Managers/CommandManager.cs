using Commander.Core.Commands;

namespace Commander.Core.Managers;

public static class CommandManager
{
    private static readonly ICollection<CommandLog> Commands =
        new List<CommandLog>(10);

    internal static void Add<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Add(new CommandLog(obj, command));
    }

    internal static void Add<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Add(new CommandLog(obj, command));
    }

    internal static bool Contains<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        return Commands.Contains(new CommandLog(obj, command));
    }

    internal static bool Contains<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        return Commands.Contains(new CommandLog(obj, command));
    }

    internal static void Remove<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Remove(new CommandLog(obj, command));
    }

    internal static void Remove<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Remove(new CommandLog(obj, command));
    }

    public static void Clear()
    {
        Commands.Clear();
    }
}