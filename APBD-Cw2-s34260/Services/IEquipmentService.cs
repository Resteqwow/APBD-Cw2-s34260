using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260.Services;

public interface IEquipmentService
{
    public List<Equipment> GetReservableEquipment();
    public List<Equipment> GetAllEquipment();
    public List<Equipment> GetUnavailableEquipment();
    public void setUnavailableEquipment(int equipmentId);
    
    public void addEquipment(Equipment equipment);
    public void setAvailableEquipment(int equipmentId);
    
}