using APBD_Cw2_s34260.Enums;
using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260.Services;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservations = [];
    
    
    public void CreateReservation( Equipment equipment, User user, DateTime from, DateTime to)
    {
        if (equipment.Availability == AvailabilityStatus.Unavailable)
        {
            throw new EquipmentUnavailableException(equipment);
        }

        if (from >= to)
        {
            throw new ReservationIncorrectDateException(from, to);
        }

        
        var userReservationCount = _reservations.Count(reservation => reservation.User == user && !reservation.IsCancelled );


        if (userReservationCount >= user.GetMaxReservations())
        {
            throw new TooManyReservationsException(user);
        }
        
        
        bool reservationConflict = _reservations.Any(reservation =>
            !reservation.IsCancelled
            && reservation.Equipment == equipment
            && reservation.Overlaps(from, to));
        if (reservationConflict)
        {
            throw new ReservationConflictException(equipment,from, to);
        }
        
        Reservation newReservation = new Reservation(equipment, user, from, to);
        _reservations.Add(newReservation);
        
        
        
    }

    public void CancelReservation(int  reservationId)
    {
        if (!_reservations.Any(reservation => reservation.Id == reservationId))
        {
            throw new ReservationNotFoundException(reservationId);
        }
        var reservation = _reservations.Find(reservation => reservation.Id == reservationId);
        reservation.CancelReservation();
        
    }

    public List<Reservation> GetActiveUserReservations(User user)
    {
        return _reservations.Where(reservation => reservation.User == user && !reservation.IsCancelled).ToList();
    }

    public List<Reservation> All()
    {
        return _reservations;
    }

    public List<Reservation> ExpiredReservations()
    {
        return _reservations.Where(reservation => reservation.IsCancelled).ToList();
    }

    public void ReturnEquipment(int reservationId, DateTime when)
    {
        if (!_reservations.Any(reservation => reservation.Id == reservationId))
        {
            throw new ReservationNotFoundException(reservationId);
        }
        var reservation = _reservations.Find(reservation => reservation.Id == reservationId);
        reservation.Returned = when;
        CalculatePenalty(reservation);
        reservation.CancelReservation();
    }

    private void CalculatePenalty(Reservation reservation)
    {
        var timeLate = (reservation.Returned - reservation.To).Value.TotalDays;
        reservation.Penalty = timeLate switch
        {
            > 30 => timeLate * 10,
            > 7 => timeLate * 4,
            > 0 => timeLate * 2,
            _ => 0
        };
    }

}