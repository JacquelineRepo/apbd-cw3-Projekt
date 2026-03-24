namespace project1;

public abstract class Equipment
{
    public static int Counter
    {
        get;
        set;
    }
    public int Id{
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
        Id = Counter++;
        Availability = true;
        Name = GetType().ToString().Split('.').Last();
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