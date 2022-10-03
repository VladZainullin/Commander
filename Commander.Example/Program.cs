using Commander.Core.Commands;
using Commander.Core.Extensions;
using Commander.Core.Managers;
using Commander.Example;

var coordinate = new Coordinate(0, 0);

var unit = new Unit(coordinate);

ICancelledCommand<Unit>[] commands =
{
    new JumpCommand(5)
};

unit.Action(commands);

Console.WriteLine($"{unit.Coordinate?.X} : {unit.Coordinate?.Y}");

unit.Cancel(commands);
unit.Cancel(new MoveCommand(1, 2));

Console.WriteLine($"{unit.Coordinate?.X} : {unit.Coordinate?.Y}");

CommandManager.Clear();