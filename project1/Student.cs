namespace project1;

public class Student : User
{
    
    public int Snum  { get; set; }
    
    public Student(string name) : base(name)
    {
        MaxBorrow = 2;

    }
}