namespace pr10.models;

public class UnitMeasurement
{
    private int id;
    private string name;

    public UnitMeasurement(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}