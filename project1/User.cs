using System.Collections;

namespace project1;

public class User
{

    public int MaxBorrow
    {
        get;
        set;
    }
    public static int Id
    {
        get;
        set;
    }

    public ArrayList Account
    {
        get;
        set;
    }
    public string? Name
    {
        get;
        set;
    }
    
    public User(string name)
    {
        Account = new ArrayList();
        Id++;
        Name = name;
    }
    
}