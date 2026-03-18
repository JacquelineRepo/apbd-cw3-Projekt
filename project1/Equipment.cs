namespace project1;

public class Equipment
{
    public static int Id{
        get;
        set;
    }
    public static string Name{
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
    public void changeStatus()
    {
        Availability = !Availability;
    }
    
    
    
    
}