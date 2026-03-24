namespace APBD_Cw2_s34260.Models;

public class Camera(string name, int cameraSize, int weight) : Equipment(name)
{
    public int CameraSize { get;set; } = cameraSize;
    public int Weight { get;set; } = weight;
}