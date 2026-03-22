using APBD_Cw2_s34260.Models;

namespace APBD_Cw2_s34260;

public class EquipmentUnavailableException(Equipment equipment) :Exception($"Equipment {equipment.Name} is currently unavailable");