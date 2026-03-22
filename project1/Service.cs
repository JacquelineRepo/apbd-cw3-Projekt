using project1.equipmentVar;
namespace project1;
public class Service
{ 
    private List<User> Users { get; } = new();

    private List<Equipment> Equipment { get; } = new();

    private List<Borrow> Borrowed { get; } = new();

    private void AddEquipment(Equipment equipment){
        Equipment.Add(equipment);
    }

    private void ListAvailableEquipment()
    {
        foreach (var equipment in Equipment)
        {
            if (equipment.Availability)
            {
                Console.WriteLine(equipment.Name);
            }
        }
    }

    public void Run(int input)
    {
        string? inputEq;
        switch (input)
        {
            case 1:
                Console.WriteLine("Please enter your Id");
                input = Convert.ToInt32(Console.ReadLine());
                if (FindUser(input)!.GetId() != 0 && !FindUser(input)!.MaxBorrowed())
                {
                    Console.WriteLine("Displaying list");
                    ListAvailableEquipment();
                    Console.WriteLine("Input what you would like to borrow");
                    inputEq = Console.ReadLine();
                    if (ValidIn(inputEq) != null)
                    {
                        Console.WriteLine("For how many days?");
                        var days = Console.Read();
                        var eq = FindEquipment(inputEq!);
                        var id = eq!.IdAccess();
                        var user = FindUser(input);

                        var bor = new Borrow(id, days, eq);

                        Take(eq, user!);
                        Borrowed.Add(bor);

                        Console.Write("Successfully borrowed.");
                    }
                    else
                    {
                        Console.Write("Couldn't find user, register? Y/N (An account is needed to borrow equipment.)");
                        var input2 = Console.ReadLine();
                        switch (input2)
                        {
                            case "Y":
                                Console.Write("Enter name and surname");
                                var name1 = Console.ReadLine();
                                var nameSurname1 = name1!.Split();

                                Console.WriteLine("Student or employee? S/E");
                                var userType1 = Console.ReadLine();
                                switch (userType1)
                                {
                                    case "S":
                                        var stud = new Student(nameSurname1[0], nameSurname1[1]);
                                        Users.Add(stud);
                                        Console.WriteLine("Here is your ID: " + stud.GetId());
                                        break;
                                    case "E":
                                        var e = new Employee(nameSurname1[0], nameSurname1[1]);
                                        Users.Add(e);
                                        Console.WriteLine("Here is your ID: " + e.GetId());
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
            case 2:
                Console.WriteLine("Input what you would like to return");
                var input3 = Console.ReadLine();
                Console.WriteLine("Please input your Id or Snum");
                var input4 = Convert.ToInt32(Console.ReadLine());
                var validEq = ValidIn(input3);
                var validUser = FindUser(input4);
                if (validEq != null && validUser != null)
                {
                    var eq = FindEquipment(input3!);
                    Return(validUser, eq!);
                    var validEqId = eq!.IdAccess();
                    FindBorrow(validEqId)!.Returned();

                    Console.WriteLine("Here are the costs:");
                    Console.WriteLine(FindBorrow(validEqId)!.Costs);
                    Console.WriteLine("Successfully returned.");
                }

                break;
            case 3:
                Console.WriteLine("Input what you would like to add");
                inputEq = Console.ReadLine();
                switch (inputEq)
                {
                    case "Laptop":
                        Console.WriteLine("Input Graphics Card model");
                        var input2 = Console.ReadLine();

                        Console.WriteLine("Input battery life(hours in Integer)");
                        var input5 = Convert.ToInt32(Console.ReadLine());

                        var lap = new Laptop(input2, input5);
                        AddEquipment(lap);

                        Console.WriteLine("Successfully added");
                        break;
                    case "MarkerSet":
                        Console.WriteLine("Input amount of markers");
                        var input6 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Input color of set");
                        var input9 = Console.ReadLine();

                        var mark = new MarkerSet(input6, input9);
                        AddEquipment(mark);

                        Console.WriteLine("Successfully added");
                        break;

                    case "Projector":
                        Console.WriteLine("Input model");
                        var input0 = Console.ReadLine();

                        Console.WriteLine("Input battery life(hours in Integer)");
                        var input11 = Convert.ToInt32(Console.ReadLine());

                        var proj = new Projector(input0, input11);
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
                input = Convert.ToInt32(Console.ReadLine());

                var equipment = FindEquipment(inputEq!);
                var equipId = equipment!.IdAccess();

                if (equipId == input)
                {
                    equipment.ChangeStatus();
                }

                break;
            case 7:
                Console.WriteLine("Enter Id of user to check active loans");
                input = Convert.ToInt32(Console.ReadLine());

                DisplayUserBorrows(input);
                break;
            case 8:
                ShowExpired();
                break;
            case 9:
                Console.Write("Enter name and surname");
                var name2 = Console.ReadLine();
                var nameSurname2 = name2!.Split();

                Console.WriteLine("Student or employee? S/E");
                var userType = Console.ReadLine();
                switch (userType)
                {
                    case "S":
                        var stud = new Student(nameSurname2[0], nameSurname2[1]);
                        Users.Add(stud);
                        Console.WriteLine("Here is your ID: " + stud.GetId());
                        break;
                    case "E":
                        var e = new Employee(nameSurname2[0], nameSurname2[1]);
                        Users.Add(e);
                        Console.WriteLine("Here is your ID: " + e.GetId());
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

                break;
            case -1:
                Console.WriteLine("Quitting...");
                break;
            default:
                Console.WriteLine("Something went wrong");
                break;
        }
    }

    private User? FindUser(int id1)
    {
        foreach (var person in Users)
        {
            var id2 = person.GetId();
            if (id1 == id2)
            {
                return person.GetUser(id1);
            }
        }
        return null;
    }

    private void ShowExpired()
    {
        Console.WriteLine("Showing expired loans");
        foreach (var variable in Borrowed)
        {
            if (variable.RetInTime == false)
            {
                Console.WriteLine(variable.Eq.Name);
            }
            
        }
    }

    private void DisplayUserBorrows(int id)
    {
        foreach (var variable in Borrowed)
        {
            if (variable.Id == id && variable.ReturnDate == DateTime.UnixEpoch )
            {
                Console.WriteLine(variable.Eq.Name + " Borrowed " + variable.BorrowDate );
            }
        }
    }
    
    private void Return(User user, Equipment eq)
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

    private void ListAll()
    {
        foreach (var v in Equipment)
        {
            Console.WriteLine(v.Name + " " + v.Availability);
        }
    }

    private Borrow? FindBorrow(int id)
    {
        foreach (var variable in Borrowed)
        {
            if (variable.Id == id)
            {
                return variable;
            }
            
        }
        return null;
    }
    private void Take(Equipment equipment, User user)
    {
        if (equipment.Availability && !user.MaxBorrowed())
        {
            equipment.ChangeStatus();
            user.Account.Add(equipment.IdAccess(), equipment);
        }
    }

    private Equipment? ValidIn(string? name)
    {
        foreach (var variable in Equipment)
        {
            if (variable.Name == name && variable.Availability)
            {
                return variable;
            }
            
        }
        return null;
    }
    private Equipment? FindEquipment(string id)
    {
        foreach (var variable in Equipment)
        {
            if (variable.Name == id)
            {
                return variable;
            }
            
        }
        return null;
    }
}