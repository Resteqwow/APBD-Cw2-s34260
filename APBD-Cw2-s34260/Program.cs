using APBD_Cw2_s34260.Models;
using APBD_Cw2_s34260.Services;

Console.WriteLine("Hello, World!");



var user1 = new Student("Pongos", "Ponglerski");
var user2 = new Employee("Pongas", "Pinglerski");

var equipment1 = new Camera("camerowska", 10,200);
var equipment2 = new Laptop("super flondra 6", "pongleps systems",1);
var equipment3 = new Projector("flonderix", 10,200);

IReservationService reservationService = new ReservationService();

IEquipmentService equipmentService = new EquipmentService();

equipmentService.addEquipment(equipment1);

equipmentService.addEquipment(equipment2);

equipmentService.addEquipment(equipment3);

try
{
    //poprawne wypozyczenie sprzetu
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 4, 10, 30, 0));
    //poprawne wypozyczenie sprzetu
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 5, 10, 0, 0),
        new DateTime(2026, 1, 10, 10, 30, 0));
    //blad
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 1, 7, 10, 0, 0),
        new DateTime(2026, 1, 1, 10, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
    //przekroczenie limitu
    reservationService.CreateReservation(
        equipment1,
        user1,
        new DateTime(2026, 3, 1, 10, 0, 0),
        new DateTime(2026, 3, 4, 10, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
    // zwrot sprzetu po terminie
    reservationService.ReturnEquipment(1,new DateTime(2026, 1, 20, 10, 30, 0));
    
    // zwrot sprzetu w terminie
    reservationService.ReturnEquipment(2,new DateTime(2026, 1, 10, 10, 30, 0));
  
    
    // proba zwrotu zakonczonej rezerwacji
    reservationService.ReturnEquipment(1,new DateTime(2026, 1, 20, 10, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


  
foreach (var VARIABLE in reservationService.All())
{ 
    Console.WriteLine(VARIABLE);
}
foreach (var VARIABLE in equipmentService.GetAllEquipment())
{ 
    Console.WriteLine(VARIABLE);
}