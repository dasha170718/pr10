namespace pr10.models;

public class Category
{
    private int id;
    private string name;

    public Category(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}