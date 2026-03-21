namespace project1;

public class Borrow
{
    
    public int Id{get;set;}
    public DateTime BorrowDate{get;set;}
    public double BorrowedTime{get;set;}
    public DateTime ReturnDate{get;set;}
    
    public double Costs{get;set;}

    public Borrow(int id, double bt)
    {
        Id = id;
        BorrowDate = DateTime.Now;
        BorrowedTime = bt;
    }

    public void Borrowed()
    {
        BorrowDate = DateTime.Now;
        Costs = BorrowedTime / 4.0;

    }

    public void Returned()
    {
        int daysGone = ReturnDate.Subtract(BorrowDate).Days;
        ReturnDate = DateTime.Now;
        if (daysGone > 25)
        {
            while (daysGone > 25)
            {
                Costs += ReturnDate.Subtract(BorrowDate).Days;
                daysGone -= 25;
            }
        }
    }
}