using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260;

public class TooManyReservationsException(User user): Exception($"User {user.Name} cant have more than {user.GetMaxReservations()} reservations");