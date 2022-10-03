using Commander.Core.Commands;
using Commander.Core.Managers;

namespace Commander.Core.Extensions;

public static class CancelledCommandExtensions
{
    public static void Cancel<TIn>(
        this TIn obj,
        ICancelledCommand<TIn> command)
    {
        if (!CommandManager.Contains(obj, command))
            return;

        CommandManager.Remove(obj, command);
        command.Undo(obj);
    }

    public static void Cancel<TIn>(
        this IEnumerable<TIn> objects,
        ICancelledCommand<TIn> command)
    {
        foreach (var obj in objects)
        {
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);
            command.Undo(obj);
        }
    }

    public static void Cancel<TIn>(
        this TIn obj,
        IEnumerable<ICancelledCommand<TIn>> commands)
    {
        foreach (var command in commands)
        {
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);
            command.Undo(obj);
        }
    }

    public static void Cancel<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<ICancelledCommand<TIn>> commands)
    {
        var cancelledCommands = commands as ICancelledCommand<TIn>[] ?? commands.ToArray();

        foreach (var obj in objects)
        foreach (var command in cancelledCommands)
        {
            if (!CommandManager.Contains(obj, command))
                continue;

            CommandManager.Remove(obj, command);
            command.Undo(obj);
        }
    }
}