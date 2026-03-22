namespace APBD_Cw2_s34260.Models;

public class Employee(string name, string surname) : User(name,surname)
{
    
    public override int GetMaxReservations() => 5;
}