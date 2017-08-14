//Sergio Garcia Balsas. Game over Class, only displays when the
//player colides against other car.

class GAME_OVER : Screen
{
    public GAME_OVER(Hardware hardware) : base(hardware)
    {
    }
    public override void Show()
    {
        while (hardware.KeyPressed() < 0)
        {
            hardware.ClearScreen();
            Image GAMEOVER = new Image("imgs/GAMEOVER.png", 792, 594);
            GAMEOVER.MoveTo(0, 20);
            hardware.DrawImage(GAMEOVER);
            hardware.UpdateScreen();
        }


        // Waits for the user to press any key
    }

}