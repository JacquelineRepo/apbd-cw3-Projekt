namespace project1;
public class Service
{

    public List<User> Users
    {
        get;
        private set;
    }
    
    public Service()
    {}
    
    public void AddUser(User user){
        Users.Add(user);}
}