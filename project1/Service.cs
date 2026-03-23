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
                Console.WriteLine(equipment.Name + "\n");
            }
        }
    }

    public void Run(int input)
    {
        try
        {
            string? inputEq;
            switch (input)
            {
                case 1:
                    Console.WriteLine("Please enter your Id\n");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (FindUser(input)!.GetId() != 0 && !FindUser(input)!.MaxBorrowed())
                    {
                        Console.WriteLine("Displaying list\n");
                        ListAvailableEquipment();
                        Console.WriteLine("Input what you would like to borrow\n");
                        inputEq = Console.ReadLine();
                        if (ValidIn(inputEq) != null)
                        {
                            Console.WriteLine("For how many days?\n");
                            var days = Convert.ToInt32(Console.ReadLine());
                            var eq = FindEquipment(inputEq!);
                            var id = eq!.IdAccess();
                            var user = FindUser(input);
                            Console.WriteLine("Date of Borrow?(YY MM DD)");
                            var date = Console.ReadLine();
                            string?[] val = date.Split();

                            var bor = new Borrow(id, days, eq,
                                new DateTime(Convert.ToInt32(val[0]), Convert.ToInt32(val[1]),
                                    Convert.ToInt32(val[2])));

                            Take(eq, user!);
                            Borrowed.Add(bor);

                            Console.Write("Successfully borrowed.\n");
                        }
                        else
                        {
                            Console.Write(
                                "Couldn't find user, register? Y/N (An account is needed to borrow equipment.)\n");
                            var input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "Y":
                                    Console.Write("Enter name and surname\n");
                                    var name1 = Console.ReadLine();
                                    var nameSurname1 = name1!.Split();

                                    Console.WriteLine("Student or employee? S/E\n");
                                    var userType1 = Console.ReadLine();
                                    switch (userType1)
                                    {
                                        case "S":
                                            var stud = new Student(nameSurname1[0], nameSurname1[1]);
                                            Users.Add(stud);
                                            Console.WriteLine("Here is your ID: " + stud.GetId() + "\n");
                                            break;
                                        case "E":
                                            var e = new Employee(nameSurname1[0], nameSurname1[1]);
                                            Users.Add(e);
                                            Console.WriteLine("Here is your ID: " + e.GetId() + "\n");

                                            break;
                                        default:
                                            Console.WriteLine("Something went wrong\n");
                                            break;
                                    }

                                    break;
                                case "N":
                                    Console.WriteLine("Cannot borrow without an account, exiting.\n");
                                    break;
                            }

                            Console.WriteLine("Couldn't find item.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Max amount has already been borrowed.");
                    }

                    break;
                case 2:
                    Console.WriteLine("Input what you would like to return\n");
                    var input3 = Console.ReadLine();
                    Console.WriteLine("Please input your Id or Snum\n");
                    var input4 = Convert.ToInt32(Console.ReadLine());
                    var validEq = ValidIn(input3);
                    var validUser = FindUser(input4);
                    if (validEq != null && validUser != null)
                    {
                        var eq = FindEquipment(input3!);
                        Return(validUser, eq!);
                        var validEqId = eq!.IdAccess();
                        FindBorrow(validEqId)!.Returned();

                        Console.WriteLine("Here are the costs: ");
                        Console.WriteLine(FindBorrow(validEqId)!.Costs + "\n");
                        Console.WriteLine("Successfully returned.\n");
                    }

                    break;
                case 3:
                    Console.WriteLine("Input what you would like to add\n");
                    inputEq = Console.ReadLine();
                    switch (inputEq)
                    {
                        case "Laptop":
                            Console.WriteLine("Input Graphics Card model\n");
                            var input2 = Console.ReadLine();

                            Console.WriteLine("Input battery life(hours in Integer)\n");
                            var input5 = Convert.ToInt32(Console.ReadLine());

                            var lap = new Laptop(input2, input5);
                            AddEquipment(lap);

                            Console.WriteLine("Successfully added\n");
                            break;
                        case "MarkerSet":
                            Console.WriteLine("Input amount of markers\n");
                            var input6 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Input color of set\n");
                            var input9 = Console.ReadLine();

                            var mark = new MarkerSet(input6, input9);
                            AddEquipment(mark);

                            Console.WriteLine("Successfully added\n");
                            break;

                        case "Projector":
                            Console.WriteLine("Input model\n");
                            var input0 = Console.ReadLine();

                            Console.WriteLine("Input brightness\n");
                            var input11 = Convert.ToInt32(Console.ReadLine());

                            var proj = new Projector(input0, input11);
                            AddEquipment(proj);

                            Console.WriteLine("Successfully added\n");
                            break;
                        default:
                            Console.WriteLine("Invalid input equipment\n");
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
                    Console.WriteLine("Enter Name of equipment to change status\n");
                    inputEq = Console.ReadLine();

                    Console.WriteLine("Enter Id of equipment\n");
                    input = Convert.ToInt32(Console.ReadLine());

                    var equipment = FindEquipment(inputEq!);
                    var equipId = equipment!.IdAccess();

                    if (equipId == input)
                    {
                        equipment.ChangeStatus();
                    }

                    break;
                case 7:
                    Console.WriteLine("Enter Id of user to check active loans\n");
                    input = Convert.ToInt32(Console.ReadLine());

                    DisplayUserBorrows(input);
                    break;
                case 8:
                    ShowExpired();
                    break;
                case 9:
                    Console.Write("Enter name and surname\n");
                    var name2 = Console.ReadLine();
                    var nameSurname2 = name2!.Split();

                    Console.WriteLine("Student or employee? S/E\n");
                    var userType = Console.ReadLine();
                    switch (userType)
                    {
                        case "S":
                            var stud = new Student(nameSurname2[0], nameSurname2[1]);
                            Users.Add(stud);
                            Console.WriteLine("Here is your ID: " + stud.GetId() + "\n");
                            break;
                        case "E":
                            var e = new Employee(nameSurname2[0], nameSurname2[1]);
                            Users.Add(e);
                            Console.WriteLine("Here is your ID: " + e.GetId() + "\n");
                            break;
                        default:
                            Console.WriteLine("Unexpected input, quitting...\n");
                            break;
                    }

                    break;
                case 10:
                    Console.WriteLine("Generating raport\n");
                    DisplayAllBorrows();
                    ListAll();

                    break;
                case -1:
                    Console.WriteLine("Quitting...\n");
                    break;
                default:
                    Console.WriteLine("Unexpected input, please try again\n");
                    break;
            }
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Deference of Null, Exiting..");
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
        Console.WriteLine("Showing expired loans\n");
        foreach (var variable in Borrowed)
        {
            if (variable.RetInTime == false)
            {
                Console.WriteLine(variable.Eq.Name + "\n");
            }
            
        }
    }
    private void DisplayAllBorrows()
    {
        var count = 0;
        foreach (var variable in Borrowed)
        {
            if (variable.ReturnDate == DateTime.UtcNow)
            {
                Console.WriteLine(variable.Eq.Name + " Borrowed " + variable.BorrowDate + "Yet to be returned\n");
                
            }
            else
            {
                count++;
                Console.WriteLine(variable.Eq.Name + " Borrowed " + variable.BorrowDate + " Returned " + variable.ReturnDate+"\n");
            }
        }
        Console.WriteLine("Amount of returned: " + count + "/"+Borrowed.Count);

    }

    private void DisplayUserBorrows(int id)
    {
        foreach (var variable in Borrowed)
        {
            if (variable.Id == id && variable.ReturnDate == DateTime.UnixEpoch )
            {
                Console.WriteLine(variable.Eq.Name + " Borrowed " + variable.BorrowDate + "\n");
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
            Console.WriteLine("You can't return something that's already there.\n");
        }
    }

    private void ListAll()
    {
        foreach (var v in Equipment)
        {
            Console.WriteLine(v.Name);
            Console.WriteLine(v.Availability + "\n");
            
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