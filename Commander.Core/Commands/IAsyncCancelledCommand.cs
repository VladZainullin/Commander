namespace Commander.Core.Commands;

/// <summary>
/// Асинхронная отменяемая команда
/// </summary>
/// <typeparam name="TIn">Тип параметра команды</typeparam>
public interface IAsyncCancelledCommand<in TIn> : IAsyncCommand<TIn>
{
    /// <summary>
    /// Метод отмены асинхронной команды
    /// </summary>
    /// <param name="obj">Объект выполнения команды</param>
    /// <param name="cancellationToken">Токен отмены команды</param>
    /// <returns>Task</returns>
    protected internal Task UndoAsync(TIn obj, CancellationToken cancellationToken = default);
}