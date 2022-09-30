namespace Commander.Core.Commands;

public interface ICommand<in TIn>
{
    protected internal void Execute(TIn obj);
}