namespace project1;

public class Student : User
{
    
    public Student(string name, string sur) : base(name,sur)
    {
        MaxBorrow = 2;
    }

  

    public override Student? GetUser(int id)
    {
        if (id == Id)
        {
            return this;
        }
        return null;
        
    }
}