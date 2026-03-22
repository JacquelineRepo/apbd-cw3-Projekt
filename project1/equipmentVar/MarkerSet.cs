namespace project1.equipmentVar;

public class MarkerSet : Equipment
{
    public int Amount{get;set;}
    public string? Colors{get;set;}
    public MarkerSet(int am, string? color)
    {
        Amount = am;
        Colors = color;
    }
    
    
}