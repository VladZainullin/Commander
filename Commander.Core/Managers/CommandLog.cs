namespace Commander.Core.Managers;

public class CommandLog
{
    public CommandLog(
        object obj,
        object command)
    {
        Obj = obj;
        Command = command;
    }

    public object? Obj { get; set; }

    public object? Command { get; set; }

    public DateTimeOffset DateTime { get; } = DateTimeOffset.Now;
}