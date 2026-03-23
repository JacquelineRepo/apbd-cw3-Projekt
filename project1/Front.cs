namespace project1;

public class Front
{
    private Service Service{get;} = new();

    public void PollRequests()
    {
        try
        {
            int input;
            do
            {
                Console.WriteLine("What would you like to do?\n");

                Console.WriteLine(
                    "1. Borrow, 2. Return, 3. Add equipment to list, 4. List all Equipment, 5. List available," +
                    "6. Change status of equipment, 7. Display a users loans," +
                    " 8. Display past due loans, 9. Register, 10. Generate report, -1. Exit,\n");
                input = Convert.ToInt32(Console.ReadLine());
                Service.Run(input);
            } while (input != -1);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input string, incorrect format");
        }

    }
    
}