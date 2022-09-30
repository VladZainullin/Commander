namespace Commander.Core.Commands;

public interface ICancelledCommand<in TIn> : ICommand<TIn>
{
    protected internal void Undo(TIn obj);
}