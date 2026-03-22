namespace project1.equipmentVar;

public class Projector : Equipment
{
    public string? Model{ get; set; }
    public int Range{ get; set; }
    
    public Projector(string? model, int range)
    {
        Model = model;
        Range = range;
    }
}