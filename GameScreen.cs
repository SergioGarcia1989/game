//Sergio Garcia Balsas. The game Screen will be displayed
using System.IO;

class GameScreen : Screen
{

    const int SCREEN_WIDTH = 800;
    const int SCREEN_HEIGHT = 600;

    const int MAP_WIDTH = 400;
    const int MAP_HEIGHT = 1700;

    const int CHARACTER_WIDTH = 50;
    const int CHARACTER_HEIGHT = 70;

    public GameScreen(Hardware hardware) : base(hardware)
    {
    }
   
    public override void Show()
    {
        StreamWriter sw = new StreamWriter("puntos.txt");

        Hardware hardware2 = new Hardware(SCREEN_WIDTH, SCREEN_HEIGHT, 24, false);

        GAME_OVER gameoverPicture = new GAME_OVER(hardware);
        GAMEOVER2 lackOfFuel = new GAMEOVER2(hardware);

        int key = -1;
        bool movingDown = true;

        Font myFont = new Font("resources/DAYPBL__.ttf", 18);

        Image img1 = new Image("imgs/carReal.png", 50, 70);
        img1.MoveTo(200, 450);
        
        Image img2 = new Image("imgs/truck.png", 70, 147);
        img2.MoveTo(100, -200);
        
        Image img3 = new Image("imgs/caryellow.png", 50, 70);
        img3.MoveTo(340, -300);
        
        Image img4 = new Image("imgs/carblue.png", 50, 70);
        img4.MoveTo(250, -800);

        Image img5 = new Image("imgs/powerUP.png", 50, 70);
        img5.MoveTo(160, -600);

        Image img6 = new Image("imgs/CARRETERA.png", MAP_WIDTH,
            MAP_HEIGHT);
        


        Audio audios = new Audio(44100, 2, 4096);
        audios.AddMusic("resources/SONIDO.wav");
        audios.AddMusic("resources/background.mid");

        Audio audio2 = new Audio(44100, 2, 4096);
        audio2.AddWAV("resources/crash.wav");

        Audio audio3 = new Audio(44100, 2, 4096);
        audio3.AddWAV("resources/POWERSOUND.wav");

        audios.PlayMusic(1, -1);
        bool gameOver = false;

        int points = 0;
        int fuel = 6000;
        int velocity = 0;

        short xMap = 0;

        while (key != Hardware.KEY_ESC && !gameOver)
        {
            fuel--;
            velocity++;
            if (velocity >= 400)
            {
                velocity = 400;
            }
            //1. Draw everything
            hardware.ClearScreen();

            hardware.DrawImage(img6, xMap, 0, SCREEN_WIDTH, SCREEN_HEIGHT);

            hardware.DrawImage(img1);
            hardware.DrawImage(img2);
            hardware.DrawImage(img3);
            hardware.DrawImage(img4);
            hardware.DrawImage(img5);
            hardware.WriteText("1P",
               600, 80, 255, 255, 255,
                    myFont);
            hardware.WriteText(points.ToString(),
               600, 110, 255, 255, 255,
                    myFont);
            hardware.WriteText(velocity.ToString() +"  km/h",
               600, 200, 255, 255, 255,
                    myFont);
            hardware.WriteText("FUEL",
               600, 300,255, 255, 255,
                    myFont);
            hardware.WriteText(fuel.ToString(),
               600, 340, 255, 255, 255,
                    myFont);

            hardware.UpdateScreen();

            

             //2. Move Player car
            key = hardware.KeyPressed();
            if (hardware.IsKeyPressed(Hardware.KEY_LEFT))
            {
                if ((img1.GetX() > 65))
                    img1.MoveTo((short)(img1.GetX() - 1), img1.GetY());
            }
            else if (hardware.IsKeyPressed(Hardware.KEY_RIGHT))
            {
                if (img1.GetX() < 340)
                    img1.MoveTo((short)(img1.GetX() + 1), img1.GetY());
            }
            //3. Move other cars
            //3.1 TRUCK
            if (movingDown)
            {
                if (img2.GetY() < 1000)
                    img2.MoveTo(img2.GetX(), (short)(img2.GetY() + 1));
                else
                    movingDown = false;
            }
            else
            {
                if (img2.GetY() > 3000)
                    img2.MoveTo(img2.GetX(), (short)(img2.GetY() - 1));
                else
                    movingDown = true;
                // The image appears later (simulating more traffic)
                img2.MoveTo(250, -200);
            }
           
            //3.2 YELLOW CAR
            if (movingDown)
            {
                if (img3.GetY() < 1000)
                    img3.MoveTo(img3.GetX(), (short)(img3.GetY() + 1));
                else
                    movingDown = false;
            }
            else
            {
                if (img3.GetY() > 3000)
                    img3.MoveTo(img3.GetX(), (short)(img3.GetY() - 1));
                else
                    movingDown = true;
                // The image appears later (simulating more traffic)
                img3.MoveTo(340, -300);
            }
           
            //3.3 BLUE CAR
            if (movingDown)
            {
                if (img4.GetY() < 1000)
                    img4.MoveTo(img4.GetX(), (short)(img4.GetY() + 1));
                else
                    movingDown = false;
            }
            else
            {
                if (img4.GetY() > 3000)
                    img4.MoveTo(img4.GetX(), (short)(img4.GetY() - 1));
                else
                    movingDown = true;
                // The image appears later (simulating more traffic)
                img4.MoveTo(250, -800);
            }
            //3.4 POWER UP
           if (movingDown)
            {
                if (img5.GetY() < 1000)
                    img5.MoveTo(img5.GetX(), (short)(img5.GetY() + 1));
                else
                    movingDown = false;
            }
            else
            {
                if (img5.GetY() > 3000)
                    img5.MoveTo(img5.GetX(), (short)(img5.GetY() - 1));
                else
                    movingDown = true;
                // The image appears later (simulating more traffic)
                img5.MoveTo(220, -600);
            }


            // 4. Collision detection and game state
                //4.0 Collision with power up
            if (img1.CollidesWith(img5, 50, 70, 50, 70))
            {
                audio3.PlayWAV(0, 2, 0);
                img5.MoveTo(180,-400);
                img4.MoveTo(250, -800);
                img3.MoveTo(340, -300);
                img2.MoveTo(100, -200);
                points += 10000;
                fuel += 1000;
            }
                //4.1 Collision with truck
            if (img1.CollidesWith(img2, 70, 147, 70, 147))
            {
                audio2.PlayWAV(0, 2, 0);
                audios.StopMusic();
                gameoverPicture.Show();
                sw.WriteLine(points);
                sw.Close();
                gameOver = true;
            }
                //4.2 Collision with yellow car
            if (img1.CollidesWith(img3, 50, 70, 50, 70))
            {
                audio2.PlayWAV(0, 2, 0);
                audios.StopMusic();
                gameoverPicture.Show();
                gameOver = true;
            }
                //4.3 Collision with blue car
            if (img1.CollidesWith(img4, 50, 70, 50, 70))
            {
                audio2.PlayWAV(0, 2, 0);
                audios.StopMusic();
                gameoverPicture.Show();
                gameOver = true;
            }

            //5. Time´s up
            if (fuel == 0)
            {
                audios.StopMusic();
                lackOfFuel.Show();
                gameOver = true;
            }
            // 6. Pause game
            System.Threading.Thread.Sleep(5);

        }
        audios.StopMusic();

        // Draw character.png at coordinates X = 380 Y = 520
        // Wait for the user to press any key
    }
}