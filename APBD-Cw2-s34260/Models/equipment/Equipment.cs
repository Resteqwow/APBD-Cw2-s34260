using APBD_Cw2_s34260.Enums;

namespace APBD_Cw2_s34260.Models;

public abstract class Equipment(string name)
{
    
    private static int _nextId = 1;
    
    public int Id { get; set; } =  _nextId++;
    public string Name { get; set; } = name;
            
    public AvailabilityStatus Availability { get; set; } = AvailabilityStatus.Available;
    public override string ToString()
    {
        return $"{GetType().Name}: {Name} status: {Availability}";
    }
}