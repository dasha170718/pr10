using System;

namespace pr10.models;

public class Role
{
    private int id;
    private string name;

    public Role(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
    public Role(string name)
    {
        this.name = name;
    }

    public int Id => id;

    public string Name => name;
}