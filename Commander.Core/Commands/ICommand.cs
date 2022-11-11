namespace Commander.Core.Commands;

/// <summary>
/// Асинхронная команда
/// </summary>
/// <typeparam name="TIn">Тип параметра команды</typeparam>
public interface ICommand<in TIn>
{
    /// <summary>
    /// Метод отмены команды
    /// </summary>
    /// <param name="obj">Объект выполнения команды</param>
    protected internal void Execute(TIn obj);
}