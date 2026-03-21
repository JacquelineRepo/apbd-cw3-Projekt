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
        Console.WriteLine("Please state user type (S - Student, E- Employee");
        do
        {
            input =  Console.ReadLine();
            switch (input)
            {
                case "S":
                    Console.WriteLine("Please enter your sNumber");
                    
                    
                
            }
            

        } while (input != "quit");
    }
}