namespace pr10.models;

public class Point
{
    private int id;
    private string city;
    private string street;
    private int home;

    public Point(int id,string city, string street, int home)
    {
        this.id = id;
        this.city = city;
        this.street = street;
        this.home = home;
    }

    public int Id => id;

    public string City => city;

    public string Street => street;

    public int Home => home;
}