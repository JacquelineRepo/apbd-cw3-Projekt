namespace project1;

public class Student : User
{
    
    public string Snum  { get; set; }
    
    public Student(string name) : base(name)
    {
        MaxBorrow = 2;
    }

    public override string GetId()
    {
        return Snum;
    }
}