namespace project1.equipmentVar;

public class MarkerSet(int am, string? color) : Equipment
{
    public int Amount{get;set;} = am;
    public string? Colors{get;set;} = color;
}