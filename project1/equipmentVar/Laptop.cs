namespace project1.equipmentVar;

public class Laptop : Equipment
{
    public string? GraphicsCard { get; set; }
    public int BatterLife { get;  set; }
    public Laptop(string? gcard, int batlife)
    {
        GraphicsCard = gcard;
        BatterLife = batlife;
    }
}