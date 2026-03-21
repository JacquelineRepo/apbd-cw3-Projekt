namespace project1;

public class Employee : User

{
    public string empNum { get; set; }
    
    public Employee(string name) : base(name)
    {
        MaxBorrow = 5;
    }

    public override string GetId()
    {
        return empNum.ToString();
    }

    public override Employee GetUser(string? id)
    {
        if (id == empNum)
        {
            return this;
        }
        else
        {
            return null;
        }
    }
}