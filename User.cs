namespace pr10.models;


public class User
{
    private int id;
    private string name;
    private string login;
    private string password;
    private Role? role;

    public User(int id, string name, string login, string password, Role? role)
    {
        this.id = id;
        this.name = name;
        this.login = login;
        this.password = password;
        this.role = role;
    }
    public User(string name, string login, string password, Role? role)
    {
        this.name = name;
        this.login = login;
        this.password = password;
        this.role = role;
    }

    public int Id => id;

    public string Name => name;

    public string Login => login;

    public string Password => password;

    public Role? Role => role;
}