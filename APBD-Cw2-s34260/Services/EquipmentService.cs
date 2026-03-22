using APBD_Cw2_s34260.Enums;
using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipment = [];
 
    
    public void addEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetReservableEquipment()
    {
        return _equipment.Where(equipment => equipment.Availability == AvailabilityStatus.Available).ToList();
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment.ToList();
    }

    public List<Equipment> GetUnavailableEquipment()
    {
        return _equipment.Where(equipment => equipment.Availability == AvailabilityStatus.Unavailable).ToList();
    }
    
    public void setUnavailableEquipment(int equipmentId)
    {
        if (!_equipment.Any(equipment => equipment.Id == equipmentId))
        {
            throw new Exception("equipment not found");
        }

        _equipment.Find(equipment => equipment.Id == equipmentId).Availability = AvailabilityStatus.Unavailable;
    }

    public void setAvailableEquipment(int equipmentId)
    {
        if (!_equipment.Any(equipment => equipment.Id == equipmentId))
        {
            throw new Exception("equipment not found");
        } 
        
        _equipment.Find(equipment => equipment.Id == equipmentId).Availability = AvailabilityStatus.Available;
        
    }
}