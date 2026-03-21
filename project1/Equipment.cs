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

    public DateTime BorrowDate
    {
        get;
        set;
    }

    public DateTime ReturnDate
    {
        get;
        set;
    }
    
    public Equipment(string name)
    {
        Id++;
        Name = name;
        Availability = true;
        BorrowDate = new DateTime(1970, 1, 1);
        ReturnDate = new DateTime(1970, 1, 1);

    }
    public void ChangeStatus()
    {
        Availability = !Availability;
    }

    public void Take(bool maxBorrow)
    {
        if (Availability && !maxBorrow)
        {
            ChangeStatus();
            BorrowDate = DateTime.Today;
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
            ReturnDate = DateTime.Today;
            
        }
        else
        {
            Console.WriteLine("You can't return something that's already there.");
        }
    }
    
    
    
    
}