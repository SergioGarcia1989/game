//Sergio Garcia Balsas. WelcomeScreen will be displayed
class WelcomeScreen : Screen
{
    
    bool exit = false;

    Font myFont = new Font("resources/DAYPBL__.ttf", 22);
    public WelcomeScreen(Hardware hardware) : base(hardware)
    {


    }
    public override void Show()
    {
        bool escPressed = false, spacePressed = false;

        Audio audios = new Audio(44100, 2, 4096);
        audios.AddWAV("resources/SONIDO.wav");


        audios.PlayMusic(1, -1);

        Image img1 = new Image("imgs/INTRO.png", 800, 600);
        img1.MoveTo(0, 50);
        hardware.DrawImage(img1);
        hardware.WriteText("PRESS ESCAPE TO EXIT OR SPACEBAR TO CONTINUE",
            80, 300, 255, 0, 0, myFont);
        hardware.UpdateScreen();
        
        do
        {
            int keyPressed = hardware.KeyPressed();
            if (keyPressed == Hardware.KEY_ESC)
            {
                escPressed = true;
                exit = true;
            }
            else if (keyPressed == Hardware.KEY_SPACE)
            {
                spacePressed = true;
                audios.PlayWAV(0, 2, 0);
                exit = false;
            }
        }
        while (!escPressed && !spacePressed);

    }
    public bool GetExit()
    {
        return exit;
    }
}


