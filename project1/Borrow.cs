namespace project1;

public class Borrow(int id, double bt, Equipment eq, DateTime borr)
{
    
    public int Id{get;set;} = id;
    public bool RetInTime{get; private set; } = true;

    public Equipment Eq{ get; set; } = eq;
    public DateTime BorrowDate{get;set;} = borr;
    private double BorrowedTime{get;set;} = bt;
    public DateTime ReturnDate{get; private set;} = DateTime.UnixEpoch;

    public double Costs{get; private set;} = bt / 2;


    public void Returned()
    {
        ReturnDate = DateTime.Now;
        var daysGone = ReturnDate.Subtract(BorrowDate).Days;
        if (daysGone > BorrowedTime)
        {
            RetInTime = false;
            while (daysGone > 0)
            {
                Costs += 0.2;
                daysGone -=1;
            }
        }
    }
}