using Commander.Core.Commands;
using Commander.Core.Managers;

namespace Commander.Core.Extensions;

public static class CommandExtensions
{
    public static void Action<TIn>(
        this TIn obj,
        ICommand<TIn> command)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (command == null) throw new ArgumentNullException(nameof(command));
        
        CommandManager.Add(obj, command);
        command.Execute(obj);
    }

    public static void Action<TIn>(
        this IEnumerable<TIn> objects,
        ICommand<TIn> command)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (command == null) throw new ArgumentNullException(nameof(command));

        foreach (var obj in objects)
        {
            CommandManager.Add(obj, command);
            command.Execute(obj);
        }
    }

    public static void Action<TIn>(
        this TIn obj,
        IEnumerable<ICommand<TIn>> commands)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands)
        {
            CommandManager.Add(obj, command);
            command.Execute(obj);
        }
    }

    public static void Action<TIn>(
        this IEnumerable<TIn> objects,
        IEnumerable<ICommand<TIn>> commands)
    {
        if (objects == null) throw new ArgumentNullException(nameof(objects));
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        var enumerable = commands as ICommand<TIn>[] ?? commands.ToArray();
        foreach (var obj in objects)
        foreach (var command in enumerable)
        {
            CommandManager.Add(obj, command);
            command.Execute(obj);
        }
    }
}