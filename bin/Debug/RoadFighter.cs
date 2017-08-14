//Sergio Garcia Balsas. Main Class
public class RoadFighter
{
    public static void Main()
    {
        Hardware hardware = new Hardware(800, 600, 24, false);
        GameController controller = new GameController();
        controller.Start();
        while (hardware.KeyPressed() != Hardware.KEY_ESC) ;
    }
}
