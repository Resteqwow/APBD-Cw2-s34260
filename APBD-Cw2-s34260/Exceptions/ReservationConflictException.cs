using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260;

public class ReservationConflictException(Equipment equ, DateTime to, DateTime from): Exception($"{equ.GetType().Name} {equ.Id} is already reserved {from} to {to}");