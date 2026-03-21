namespace project1;

public class User
{
    public static int Id
    {
        get;
        set;
    }
    public static string? Name
    {
        get;
        set;
    }
    
    public User(string name)
    {
        Id++;
        Name = name;
    }
    
}