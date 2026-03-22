namespace APBD_Cw2_s34260;

public class ReservationIncorrectDateException(DateTime from, DateTime to): Exception($"Invalid reservation time {from} to {to} isnt possible");