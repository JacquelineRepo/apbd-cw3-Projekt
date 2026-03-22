namespace project1.equipmentVar;

public class Laptop(string? gcard, int batlife) : Equipment
{
    public string? GraphicsCard { get; set; } = gcard;
    public int BatterLife { get;  set; } = batlife;
}