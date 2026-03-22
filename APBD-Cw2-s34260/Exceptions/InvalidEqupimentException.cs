namespace APBD_Cw2_s34260;

public class InvalidEqupimentException(int equipmentId):Exception($"equipment with {equipmentId}id hasnt been reserved");