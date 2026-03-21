namespace project1;

public class Equipment
{
    public static int Id{
        get;
        set;
    }
    public string? Name{
        get;
        set;
    }

    public bool Availability { get; set; }

    public Equipment(string name)
    {
        Id++;
        Name = name;
        Availability = true;
    }
    public void ChangeStatus()
    {
        Availability = !Availability;
    }

    public int Take(bool maxBorrow)
    {
        if (Availability && !maxBorrow)
        {
            ChangeStatus();
            return Id;
        }else
        {
            Console.WriteLine("You can't take something that was never there.");
            return -111;
        }
    }
    
    public void Return(User user, Equipment eq)
    {
        if (!Availability)
        {
            ChangeStatus();
            user.Account.Remove(eq.IdAccess());

        }
        else
        {
            Console.WriteLine("You can't return something that's already there.");
        }
    }

    public int IdAccess()
    {
        return Id;
    }
    
    
}