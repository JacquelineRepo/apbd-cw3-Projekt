namespace project1;
public class Service
{

    public List<User> Users
    {
        get;
        private set;
    }

    public List<Equipment> Equipment
    {
        get;
        private set;
    }
    
    
    public Service()
    {}
    
    public void AddUser(User user){
        Users.Add(user);
    }
    
    public void AddEquipment(Equipment equipment){
        Equipment.Add(equipment);
    }

    public void ListAvailableEquipment()
    {
        foreach (Equipment equipment in Equipment)
        {
            if (equipment.Availability)
            {
                Console.WriteLine(equipment.Name);
            }
        }
    }

    public void Run()
    {
        string? input;
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Borrow or return, 2. Add equipment to list, ");
        do
        {
            input =  Console.ReadLine();

        } while (input != "quit");
    }
    
    public bool findUser(string id)
    {
        foreach (var person in Users)
        {
            string Id = person.GetId();
            if (Id == id)
            {
                return true;
            }
        }
        return false;
    }
}