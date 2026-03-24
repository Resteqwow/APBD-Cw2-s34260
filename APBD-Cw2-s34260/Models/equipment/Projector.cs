namespace APBD_Cw2_s34260.Models;

public class Projector(string name, int resolution, int powerConsumption) : Equipment(name)
{
    public int Resolution { get;set; } = resolution;
    public int PowerConsumption { get;set; } = powerConsumption;
}