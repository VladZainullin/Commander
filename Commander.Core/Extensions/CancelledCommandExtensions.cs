using Commander.Core.Commands;

namespace Commander.Core.Extensions;

public static class CancelledCommandExtensions
{
    public static void Cancel<TIn>(
        this TIn obj,
        ICancelledCommand<TIn> command)
    {
        command.Undo(obj);
    }
    
    public static void Cancel<TIn>(
        this IEnumerable<TIn> objects,
        ICancelledCommand<TIn> command)
    {
        foreach (var obj in objects)
        {
            command.Undo(obj);
        }
    }
    
    public static void Cancel<TIn>(
        this TIn obj,
        IEnumerable<ICancelledCommand<TIn>> commands)
    {
        foreach (var command in commands)
        {
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
            command.Undo(obj);
        }
    }
}