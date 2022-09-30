namespace Commander.Core.Queries;

public interface IQuery<in TIn, out TOut>
{
    protected internal TOut Execute(TIn obj);
}