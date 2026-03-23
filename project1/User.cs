using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace project1;

public abstract class User
{
    public string? Surname{get;set;}
    

    public int MaxBorrow
    {
        get;
        set;
    }
    
    public static int Counter { get; set; }
    
    
    public int Id
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
    
    public User(string name, string sur)
    {
        Account = new Dictionary<int, Equipment>();
        Id = Counter++;
        Name = name;
        Surname = sur;
    }

    public bool MaxBorrowed()
    {
        return Account.Count >= MaxBorrow;

    }

    public virtual int GetId()
    {
        return Id;
    }

    public virtual User? GetUser(int id)
    {
        if (id == Id)
        {
            return this;
        }
        return null;
    }
    
}