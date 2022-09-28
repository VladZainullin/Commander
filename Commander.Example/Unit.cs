namespace Commander.Example;

internal sealed class Unit
{
    public Unit(Coordinate coordinate)
    {
        Coordinate = coordinate;
    }

    public Coordinate? Coordinate { get; set; }
}