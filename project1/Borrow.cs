namespace project1;

public class Borrow(int id, double bt, Equipment eq)
{
    
    public int Id{get;set;} = id;
    public bool RetInTime{get; private set; } = true;

    public Equipment Eq{ get; set; } = eq;
    public DateTime BorrowDate{get;set;} = DateTime.Now;
    private double BorrowedTime{get;set;} = bt;
    public DateTime ReturnDate{get; private set;} = DateTime.UnixEpoch;

    public double Costs{get; private set;}


    public void Returned()
    {
        var daysGone = ReturnDate.Subtract(BorrowDate).Days;
        ReturnDate = DateTime.Now;
        Costs = BorrowedTime / 4.0;
        if (daysGone > 25)
        {
            RetInTime = false;
            daysGone -= 25;
            while (daysGone > 0)
            {
                Costs += 5;
                daysGone -= 7;
            }
        }
    }
}