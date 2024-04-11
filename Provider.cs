namespace pr10.models;

public class Provider
{
    private int id;
    private string name;

    public Provider(int id,string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}
