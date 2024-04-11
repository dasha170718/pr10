namespace pr10.models;

public class Manufacture
{
    private int id;
    private string name;

    public Manufacture(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}