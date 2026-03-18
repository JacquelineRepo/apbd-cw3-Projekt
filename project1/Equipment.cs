namespace project1;

public class Equipment
{
    public static int Id{
        get;
        set;
    }
    public static string? Name{
        get;
        set;
    }
    public bool Availability{
        get;
        set;
    }
    
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

    public void Take()
    {
        if (Availability)
        {
            ChangeStatus();
        }
        else
        {
            Console.WriteLine("You can't take something that was never there.");
        }
    }
    
    public void Return()
    {
        if (!Availability)
        {
            ChangeStatus();
        }
        else
        {
            Console.WriteLine("You can't return something that's already there.");
        }
    }
    
    
    
    
}