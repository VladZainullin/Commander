using Commander.Core.Commands;

namespace Commander.Core.Managers;

public static class CommandManager
{
    private static readonly ICollection<(object obj, object command)> Commands =
        new List<(object obj, object command)>(10);

    internal static void Add<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Add((obj, command));
    }

    internal static void Add<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Add((obj, command));
    }

    internal static bool Contains<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        return Commands.Contains((obj, command));
    }

    internal static bool Contains<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        return Commands.Contains((obj, command));
    }

    internal static void Remove<TIn>(
        TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Remove((obj, command));
    }

    internal static void Remove<TIn>(
        TIn obj,
        IAsyncCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Commands.Remove((obj, command));
    }

    public static void Clear() => Commands.Clear();
}