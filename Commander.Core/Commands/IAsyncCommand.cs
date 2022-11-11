namespace Commander.Core.Commands;

/// <summary>
/// Асинхронная команда
/// </summary>
/// <typeparam name="TIn">Тип объекта выполнения команды</typeparam>
public interface IAsyncCommand<in TIn>
{
    /// <summary>
    /// Метод выполнения асинхронной команды
    /// </summary>
    /// <param name="obj">Объект выполнения команды</param>
    /// <param name="cancellationToken">Токен отмены команды</param>
    /// <returns>Task</returns>
    protected internal Task ExecuteAsync(TIn obj, CancellationToken cancellationToken = default);
}