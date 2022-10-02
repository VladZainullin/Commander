using Commander.Core.Commands;

namespace Commander.Core.Extensions;

public static class CommandExtensions
{
    public static void Action<TIn>(
        this TIn obj,
        ICommand<TIn> command)
    {
        command.Execute(obj);
    }
    
    public static void Action<TIn>(
        this IEnumerable<TIn> objects,
        ICommand<TIn> command)
    {
        foreach (var obj in objects)
        {
            command.Execute(obj);
        }
    }
    
    public static void Action<TIn>(
        this TIn obj,
        IEnumerable<ICommand<TIn>> commands)
    {
        foreach (var command in commands)
        {
            command.Execute(obj);
        }
    }
    
    public static void Action<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<ICommand<TIn>> commands)
    {
        var enumerable = commands as ICommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)    
        foreach (var command in enumerable)
        {
            command.Execute(obj);
        }
    }

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