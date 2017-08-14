//Sergio Garcia Balsas. Credit Screen will be shown
using System;
using System.IO;

class CreditsScreen : Screen
{
    
    struct CompleteDate
    {
        public int day;
        public int month;
        public int year;
    }
    string[] greets = { "Have a good morning Mr./Ms. ",
        "Have a good evening Mr./Ms.",
        "Have a good night Mr./Ms." };
    Font myFont = new Font("resources/DAYPBL__.ttf", 22);
    public CreditsScreen(Hardware hardware) : base(hardware)
    {
    }
    public override void Show()
    {
        StreamReader sr = new StreamReader("puntos.txt");

        while (hardware.KeyPressed() < 0)
        {
            Image img2 = new Image("imgs/CREDI.png", 800, 100);
            img2.MoveTo(0, 10);
            hardware.DrawImage(img2);
            hardware.WriteText("THANKS FOR PLAYING",
            250, 150, 255, 0, 0, myFont);
            hardware.WriteText("CREATED BY: SERGIO GARCIA BALSAS",
            150, 200, 255, 0, 0, myFont);
            if ((DateTime.Now.Hour >= 8) && (DateTime.Now.Hour <= 12))
            {
                hardware.WriteText(greets[0] + Environment.UserName,
                    150, 300, 0, 255, 0, myFont);
            }
            else if ((DateTime.Now.Hour >= 12) && 
                (DateTime.Now.Hour <= 20))
            {
                hardware.WriteText(greets[1] + Environment.UserName,
                    150, 300, 0, 255, 0, myFont);
            }
            else
            {
                hardware.WriteText(greets[2] + Environment.UserName,
                   150, 300, 0, 255, 0, myFont);
            }

            //Date TO DO points???
            DateTime now = DateTime.Now;
            CompleteDate d;
            d.day = now.Day;
            d.month = now.Month;
            d.year = now.Year;
            hardware.WriteText(Convert.ToString(d.day) + "/" +
                Convert.ToString(d.month) + "/" +
                Convert.ToString(d.year) + "      " + "POINTS REACHED:"
                
                +sr.ReadLine()
               
                , 200, 400, 0, 0, 255, myFont
                );
          
            hardware.UpdateScreen();
        }

        sr.Close();
        // Waits for the user to press any key
    }
}