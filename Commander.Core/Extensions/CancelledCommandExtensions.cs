using Commander.Core.Commands;
using Commander.Core.Managers;

namespace Commander.Core.Extensions;

public static class CancelledCommandExtensions
{
    public static void Cancel<TIn>(
        this TIn obj,
        ICancelledCommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));

        Undo(obj, command);
    }

    public static void Cancel<TIn>(
        this IEnumerable<TIn> objects,
        ICancelledCommand<TIn> command)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (command == null) throw new ArgumentNullException(nameof(command));

        foreach (var obj in objects) Undo(obj, command);
    }

    public static void Cancel<TIn>(
        this TIn obj,
        IEnumerable<ICancelledCommand<TIn>> commands)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands) Undo(obj, command);
    }

    public static void Cancel<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<ICancelledCommand<TIn>> commands)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        var cancelledCommands = commands as ICancelledCommand<TIn>[] ?? commands.ToArray();

        foreach (var obj in objects)
        foreach (var command in cancelledCommands)
            Undo(obj, command);
    }

    private static void Undo<TIn>(
        TIn obj,
        ICancelledCommand<TIn> command)
    {
        if (!CommandManager.Contains(obj, command))
            return;

        CommandManager.Remove(obj, command);

        command.Undo(obj);
    }
}