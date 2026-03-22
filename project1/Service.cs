using System.Text.RegularExpressions;
using project1.equipmentVar;

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
        int input;
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Borrow, 2. Return, 3. Add equipment to list, 4. List all Equipment, 5. List available," +
                          "6. Change status of equipment, 7. Display a users loans, -1. Exit,");
        do
        {
            input = Console.Read();
            string? inputEq;
            switch (input)
            {
                case 1:
                    Console.WriteLine("Please enter your Id");
                    input = Console.Read();
                    if (findUser(input).GetId() != 0 && !findUser(input).MaxBorrowed())
                    {
                        Console.WriteLine("Displaying list");
                        ListAvailableEquipment();
                        Console.WriteLine("Input what you would like to borrow");
                        inputEq = Console.ReadLine();
                        if (ValidIn(inputEq) != null)
                        {
                            Console.WriteLine("For how many days?");
                            int days = Console.Read();
                            Borrow bor = new Borrow(FindEquipment(inputEq).IdAccess(),days, FindEquipment(inputEq));
                            Take(FindEquipment(inputEq), findUser(input));
                            Borrowed.Add(bor);
                            Console.Write("Successfully borrowed.");
                            
                        }
                        else
                        {
                            Console.Write("Couldn't find user, register? Y/N (An account is needed to borrow equipment.)" );
                            string? input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "Y":
                                    Console.Write("Enter name and surname");
                                    string? name = Console.ReadLine();
                                    string[] word = name.Split();
                                    Console.WriteLine("Student or employee? S/E");
                                    string? ohgod = Console.ReadLine();
                                    switch (ohgod)
                                    {
                                        case "S":
                                            Student stud = new Student(word[0], word[1]);
                                            Users.Add(stud);
                                            Console.WriteLine("Here is your ID: "+ stud.GetId());
                                            break;
                                        case "E":
                                            Employee e = new Employee(word[0], word[1]);
                                            Users.Add(e);
                                            Console.WriteLine("Here is your ID: "+ e.GetId());
                                            break;
                                        default:
                                            Console.WriteLine("Something went wrong");
                                            break;
                                    }
                                    break;
                                case "N":
                                    Console.WriteLine("Cannot borrow without an account, exiting.");
                                    break;
                            }
                            
                            Console.WriteLine("Couldn't find item.");
                        }
                        
                    }
                    break;
                case 2 :
                    Console.WriteLine("Input what you would like to return");
                    string? input3 = Console.ReadLine();
                    Console.WriteLine("Please input your Id or Snum");
                    int input4 = Console.Read();
                    if (ValidIn(input3) != null && findUser(input4) != null)
                    {
                        Return(findUser(input4), FindEquipment(input3));
                        findBorrow(ValidIn(input3).IdAccess()).Returned();
                        Console.WriteLine("Here are the costs:");
                        Console.WriteLine(findBorrow(ValidIn(input3).IdAccess()).Costs);
                        Console.WriteLine("Successfully returned.");
                    }
                    
                    break;
                case  3:
                    Console.WriteLine("Input what you would like to add");
                    inputEq = Console.ReadLine();
                    switch (inputEq)
                    {
                        case "Laptop":
                            Console.WriteLine("Input Graphics Card model");
                            string? input2 = Console.ReadLine();
                            Console.WriteLine("Input battery life(hours in Integer)");
                            int input5 = Console.Read();
                            Laptop lap = new Laptop(input2, input5);
                            AddEquipment(lap);
                            Console.WriteLine("Successfully added");
                            break;
                        case "MarkerSet":
                            Console.WriteLine("Input amount of markers");
                            int input6 = Console.Read();
                            Console.WriteLine("Input color of set");
                            string? input9 = Console.ReadLine();
                            MarkerSet mark = new MarkerSet(input6, input9);
                            AddEquipment(mark);
                            Console.WriteLine("Successfully added");
                            break;
                        
                        case "Projector":
                            Console.WriteLine("Input model");
                            string? input0 = Console.ReadLine();
                            Console.WriteLine("Input battery life(hours in Integer)");
                            int input11 = Console.Read();
                            Projector proj = new Projector(input0, input11);
                            AddEquipment(proj);
                            Console.WriteLine("Successfully added");
                            break;
                        default:
                            Console.WriteLine("Invalid input equipment");
                            break;
                    }
                    break;
                case 4:
                    ListAll();
                    break;
                case 5:
                    ListAvailableEquipment();
                    break;
                case 6:
                    Console.WriteLine("Enter Name of equipment to change status");
                    inputEq = Console.ReadLine();
                    Console.WriteLine("Enter Id of equipment");
                    input = Console.Read();
                    if (FindEquipment(inputEq).IdAccess() == input)
                    {
                        FindEquipment(inputEq).ChangeStatus();
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter Id of user to check active loans");
                    input = Console.Read();
                    DisplayUserBorrows(input);
                    break;
                case -1:
                    Console.WriteLine("Quitting...");
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }

        } while (input != -1);
    }
    
    public User? findUser(int id)
    {
        foreach (var person in Users)
        {
            int Id = person.GetId();
            if (Id == id)
            {
                return person.GetUser(id);
            }
        }
        return null;
    }

    public void ShowExpired()
    {
        Console.WriteLine("Showing expired loans");
        foreach (var VARIABLE in Borrowed)
        {
            if (VARIABLE.RetInTime == false)
            {
                Console.WriteLine(VARIABLE.Eq.Name);
            }
            
        }
    }

    public void DisplayUserBorrows(int id)
    {
        foreach (var VARIABLE in Borrowed)
        {
            if (VARIABLE.Id == id && VARIABLE.ReturnDate == DateTime.UnixEpoch )
            {
                Console.WriteLine(VARIABLE.Eq.Name + " Borrowed " + VARIABLE.BorrowDate );
            }
            
        }
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

    public void ListAll()
    {
        foreach (var v in Equipment)
        {
            Console.WriteLine(v.Name + " " + v.Availability);
        }
    }

    public Borrow? findBorrow(int id)
    {
        foreach (var VARIABLE in Borrowed)
        {
            if (VARIABLE.Id == id)
            {
                return VARIABLE;
            }
            
        }
        return null;
    }
    public void Take(Equipment equipment, User user)
    {
        if (equipment.Availability && !user.MaxBorrowed())
        {
            equipment.ChangeStatus();
            user.Account.Add(equipment.IdAccess(), equipment);
        }
    }

    public Equipment? ValidIn(string? name)
    {
        foreach (var VARIABLE in Equipment)
        {
            if (VARIABLE.Name == name && VARIABLE.Availability)
            {
                return VARIABLE;
            }
            
        }
        return null;
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