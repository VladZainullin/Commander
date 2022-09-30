using Commander.Core.Commands;

namespace Commander.Example;

internal sealed class JumpCommand :
    ICancelledCommand<Unit>,
    IAsyncCancelledCommand<Unit>
{
    private readonly int _height;

    public JumpCommand(int height)
    {
        _height = height;
    }

    void ICommand<Unit>.Execute(Unit obj)
    {
        obj.Coordinate = new Coordinate(obj.Coordinate!.Value.X, obj.Coordinate!.Value.Y + _height);
    }

    void ICancelledCommand<Unit>.Undo(Unit obj)
    {
        obj.Coordinate = new Coordinate(obj.Coordinate!.Value.X, obj.Coordinate!.Value.Y - _height);
    }

    async Task IAsyncCommand<Unit>.ExecuteAsync(Unit obj, CancellationToken cancellationToken)
    {
        obj.Coordinate = new Coordinate(obj.Coordinate!.Value.X, obj.Coordinate!.Value.Y + _height);
        
        await Task.FromResult(0);
    }

    async Task IAsyncCancelledCommand<Unit>.UndoAsync(Unit obj, CancellationToken cancellationToken)
    {
        obj.Coordinate = new Coordinate(obj.Coordinate!.Value.X, obj.Coordinate!.Value.Y - _height);

        await Task.FromResult(0);
    }
}