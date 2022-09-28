using Commander.Core;

namespace Commander.Example;

internal sealed class JumpCommand :
    ICommand<Unit>
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

    void ICommand<Unit>.Undo(Unit obj)
    {
        obj.Coordinate = new Coordinate(obj.Coordinate!.Value.X, obj.Coordinate!.Value.Y - _height);
    }
}