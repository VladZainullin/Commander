using Commander.Core;
using Commander.Example;

var coordinate = new Coordinate(0, 0);

var unit = new Unit(coordinate);

ICommand<Unit>[] commands =
{
    new JumpCommand(5),
    new MoveCommand(1, 2)
};

foreach (var command in commands) unit.Action(command);

Console.WriteLine($"{unit.Coordinate?.X} : {unit.Coordinate?.Y}");

foreach (var command in commands) unit.Cancel(command);

Console.WriteLine($"{unit.Coordinate?.X} : {unit.Coordinate?.Y}");