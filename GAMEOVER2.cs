//Sergio Garcia Balsas. Game over Class, only displays when the
//player colides against other car.

class GAMEOVER2 : Screen
{
    public GAMEOVER2(Hardware hardware) : base(hardware)
    {
    }
    public override void Show()
    {
        while (hardware.KeyPressed() < 0)
        {
            hardware.ClearScreen();
            Image GAMEOVER2 = new Image("imgs/GAMEOVER2.png", 792, 594);
            GAMEOVER2.MoveTo(0, 20);
            hardware.DrawImage(GAMEOVER2);
            hardware.UpdateScreen();
        }


        // Waits for the user to press any key
    }

}