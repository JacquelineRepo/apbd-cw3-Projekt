namespace project1.equipmentVar;

public class Projector(string? model, int range) : Equipment
{
    public string? Model{ get; set; } = model;
    public int Range{ get; set; } = range;
}