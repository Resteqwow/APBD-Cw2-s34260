namespace APBD_Cw2_s34260.Models;

public class Laptop(string name, string operatingSystem, int ram) : Equipment(name)
{
    public string OperatingSystem { get;set; } = operatingSystem;
    public int Ram { get; set; } = ram;
    
}