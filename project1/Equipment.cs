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

    public Equipment()
    {
        Id++;
        Availability = true;
    }
    public void ChangeStatus()
    {
        Availability = !Availability;
    }
    
    
    

    public int IdAccess()
    {
        return Id;
    }
    
    
}