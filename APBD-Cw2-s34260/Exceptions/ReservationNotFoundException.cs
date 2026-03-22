namespace APBD_Cw2_s34260;

public class ReservationNotFoundException(int reservationId): Exception($"reservation with ID {reservationId} hasnt been found");
