using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260.Services;

public interface IReservationService
{
    public void CreateReservation(Equipment equipment, User user,  DateTime from, DateTime to);
    public void CancelReservation(int reservationId);
    public void ReturnEquipment(int reservationId, DateTime when);
    
    public List<Reservation> GetActiveUserReservations(User user);
    public List<Reservation> All();
    public List<Reservation> ExpiredReservations();

}