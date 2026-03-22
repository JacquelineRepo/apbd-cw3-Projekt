namespace project1;

public class Front
{
    public Service service{get;set;}

    public Front()
    {
        service = new Service();
    }

    public void PollRequests()
    {
        int input;
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Borrow, 2. Return, 3. Add equipment to list, 4. List all Equipment, 5. List available," +
                          "6. Change status of equipment, 7. Display a users loans, -1. Exit,");
        do
        {
            input = Console.Read();
            service.Run(input);
        } while (input != -1);

    }
    
}