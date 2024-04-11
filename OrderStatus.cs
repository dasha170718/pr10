namespace pr10.models;

public class OrderStatus
{
    private int id;
    private string name;

    public OrderStatus(int id,string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}