namespace project1;

public class Student : User
{
    
    public string Snum  { get; set; }
    
    public Student(string name, string? snum) : base(name)
    {
        MaxBorrow = 2;
        Snum = snum;
    }

    public override string GetId()
    {
        return Snum;
    }

    public override Student? GetUser(string? id)
    {
        if (id == Snum)
        {
            return this;
        }
        else
        {
            return null;
        }
    }
}