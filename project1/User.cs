using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

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

    public Dictionary<int, Equipment> Account
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
        Account = new Dictionary<int, Equipment>();
        Id++;
        Name = name;
    }

    public bool MaxBorrowed()
    {
        return Account.Count > MaxBorrow;

    }
    
}