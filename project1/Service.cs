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

    public List<Borrow> Borrowed
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
        Console.WriteLine("1. Borrow, 2. Return, 3. Add equipment to list, 4. Exit");
        do
        {
            input =  Console.ReadLine();
            switch (input)
            {
                case "1" :
                    
                    Console.WriteLine("Displaying list");
                    ListAvailableEquipment();
                    Console.WriteLine("Input what you would like to borrow");
                    input = Console.ReadLine();
                    if (ValidIn(input))
                    {
                        Console.WriteLine("For how many days?");
                        int days = Console.Read();
                        Borrow bor = new Borrow(FindEquipment(input).IdAccess(),days);
                        Borrowed.Add(bor);
                        
                        Console.WriteLine("Please enter your Id or Snum");
                        input = Console.ReadLine();
                        if (findUser(input))
                        {
                            foreach (var VARIABLE in Users)
                            {
                                if (VARIABLE.GetUser(input) != null)
                                {
                                    VARIABLE.Account
                                }
                                
                                
                            }
                            
                            
                        }
                        
                        
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find item.");
                    }
                    
                    break;
                case "2" :
                    Console.WriteLine("Input what you would like to return");
                    
                    break;
                case "3" :
                    Console.WriteLine("Input what you would like to add");
                    
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }

        } while (input != "quit");
    }
    
    public bool findUser(string? id)
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
    public void Return(User user, Equipment eq)
    {
        if (!eq.Availability)
        {
            eq.ChangeStatus();
            user.Account.Remove(eq.IdAccess());
        }
        else
        {
            Console.WriteLine("You can't return something that's already there.");
        }
    }
    public int Take(Equipment equipment, User user)
    {
        if (equipment.Availability && !user.MaxBorrowed())
        {
            equipment.ChangeStatus();
            return equipment.IdAccess();
        }else
        {
            Console.WriteLine("You can't take something that was never there.");
            return -111;
        }
    }

    public bool ValidIn(string? name)
    {
        foreach (var VARIABLE in Equipment)
        {
            if (VARIABLE.Name == name && VARIABLE.Availability)
            {
                return true;
            }
            
        }
        return false;
    }

    public Equipment? FindEquipment(string id)
    {
        foreach (var VARIABLE in Equipment)
        {
            if (VARIABLE.Name == id)
            {
                return VARIABLE;
            }
            
        }
        return null;
    }
    
    
}