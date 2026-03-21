namespace project1;

public class Employee : User

{
    public int empNum { get; set; }
    
    public Employee(string name) : base(name)
    {
        MaxBorrow = 5;
    }

    public override string GetId()
    {
        return empNum.ToString();
    }
}