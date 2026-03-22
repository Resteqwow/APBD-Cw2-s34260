namespace APBD_Cw2_s34260.Models;

public class Reservation(Equipment equipment, User user, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } =  _nextId++;
    public Equipment Equipment { get; set; } = equipment;
    public User User { get; set; } = user;
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;
    public DateTime? Returned { get; set; } = null;
    public bool IsCancelled { get; set; } = false;
    public double Penalty { get; set; } = 0;
    public void CancelReservation()
    {
        IsCancelled = true;
    }
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }
    public override string ToString()
    {
        return $"Reservation #{Id}: {Equipment} reserved by {User} from {From} to {To}, Returned: {Returned}, Cancelled: {IsCancelled}, Penalty: {Penalty}";
    }
}