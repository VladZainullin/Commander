namespace Commander.Core;

public interface ICommand<in TIn>
{
    protected internal void Execute(TIn obj);
}

public interface ICancelledCommand<in TIn> : ICommand<TIn>
{
    protected internal void Undo(TIn obj);
}