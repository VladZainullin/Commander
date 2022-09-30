namespace Commander.Core;

public static class CommandExtensions
{
    public static TOut Action<TIn, TOut>(
        this TIn obj,
        IQuery<TIn, TOut> query)
    {
        return query.Execute(obj);
    }

    public static async Task<TOut> ActionAsync<TIn, TOut>(
        this TIn obj,
        IAsyncQuery<TIn, TOut> query,
        CancellationToken cancellationToken)
    {
        return await query.ExecuteAsync(obj, cancellationToken);
    }

    public static void Action<TIn>(
        this TIn obj,
        ICommand<TIn> command)
    {
        command.Execute(obj);
    }

    public static void Cancel<TIn>(
        this TIn obj,
        ICancelledCommand<TIn> query)
    {
        query.Undo(obj);
    }

    public static async Task ActionAsync<TIn>(
        this TIn obj,
        IAsyncCommand<TIn> command,
        CancellationToken cancellationToken)
    {
        await command.ExecuteAsync(obj, cancellationToken);
    }

    public static async Task Cancel<TIn>(
        this TIn obj,
        IAsyncCancelledCommand<TIn> query,
        CancellationToken cancellationToken)
    {
        await query.UndoAsync(obj, cancellationToken);
    }
}