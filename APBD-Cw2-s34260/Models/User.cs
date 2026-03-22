namespace APBD_Cw2_s34260.Models;

public abstract class User(string name, string surname)
{
    
    private static int _nextId = 1;
    
    public int Id { get; set; } =  _nextId++;
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    
    
    
    public abstract int GetMaxReservations();
    public override string ToString()
    {
        return $"{GetType().Name}: {Name} {surname}"; // albo np. $"Camera: {Name}"
    }
    
}