using APBD_Cw2_s34260.Models;
using APBD_Cw2_s34260.Services;

Console.WriteLine("Hello, World!");



var user1 = new Student("Pongos", "Ponglerski");
var user2 = new Employee("Pongas", "Pinglerski");

var equipment1 = new Camera("camerowska", 10,200);
var equipment2 = new Laptop("super flondra 6", "pongleps systems",1);
var equipment3 = new Projector("flonderix", 10,200);

IReservationService reservationService = new ReservationService();

try
{
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 4, 10, 30, 0));
    
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 4, 10, 30, 0));
    
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 4, 10, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    foreach (var VARIABLE in reservationService.All())
    {
        Console.WriteLine(VARIABLE);
    }
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
