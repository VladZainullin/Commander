namespace Commander.Core.Commands;

/// <summary>
/// Отменяемая команда
/// </summary>
/// <typeparam name="TIn">Тип объекта выполнения команды</typeparam>
public interface ICancelledCommand<in TIn> : ICommand<TIn>
{
    /// <summary>
    /// Метод отмены команды
    /// </summary>
    /// <param name="obj">Объект выполнения команды</param>
    protected internal void Undo(TIn obj);
}