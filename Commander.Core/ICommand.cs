namespace Commander.Core;

public interface ICommand<in TIn>
{
    protected internal void Execute(TIn obj);
    
    protected internal void Undo(TIn obj);
}