namespace project1;

public class Employee : User

{
    
    public Employee(string name, string sur) : base(name,sur)
    {
        MaxBorrow = 5;
    }

    public override int GetId()
    {
        return Id;
    }

    public override Employee GetUser(int id)
    {
        if (id == Id)
        {
            return this;
        }
        return null;
    }
}