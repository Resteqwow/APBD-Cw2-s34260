namespace APBD_Cw2_s34260.Models;

public class Reservation(Equipment equipment, User user, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } =  _nextId++;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException
        ("Reservation return date cant be before initial reservation date") : from;
    public DateTime To { get; set; } = to;
    
    public bool IsCancelled { get; set; } = false;


    public void CancelReservation()
    {
        IsCancelled = true;
    }
    
    
}