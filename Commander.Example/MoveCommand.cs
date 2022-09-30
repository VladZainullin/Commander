using Commander.Core.Commands;

namespace Commander.Example;

internal sealed class MoveCommand :
    ICancelledCommand<Unit>
{
    private readonly int _x;
    private readonly int _y;
    private Coordinate? _coordinate;

    public MoveCommand(int x, int y)
    {
        _x = x;
        _y = y;
    }

    void ICommand<Unit>.Execute(Unit obj)
    {
        (_coordinate, obj.Coordinate) =
            (obj.Coordinate, new Coordinate(obj.Coordinate!.Value.X + _x, obj.Coordinate!.Value.Y + _y));
    }

    void ICancelledCommand<Unit>.Undo(Unit obj)
    {
        (_coordinate, obj.Coordinate) =
            (null, new Coordinate(obj.Coordinate!.Value.X - _x, obj.Coordinate!.Value.Y - _y));
    }
}