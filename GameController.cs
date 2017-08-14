//Sergio Garcia Balsas. Class created to move between the 3 screens
//(welcome, game and credits).

public class GameController
{
    public void Start()
    {

        Hardware hardware = new Hardware(800, 600, 24, false);
        WelcomeScreen welcome = new WelcomeScreen(hardware);
        CreditsScreen credits = new CreditsScreen(hardware);
        GameScreen game = new GameScreen(hardware);

        do
        {
            // Show game screen
            welcome.Show();

            if (welcome.GetExit() == false)
            {
                //Cleaning screen
                hardware.ClearScreen();

                //Game screen show
                game.Show();

                //Cleaning again screen
                hardware.ClearScreen();

                // Show credits screen
                credits.Show();

                //Cleaning screen
                hardware.ClearScreen();
            }
        } while (!welcome.GetExit());

        hardware.ClearScreen();
        welcome.Show();
    }
}

// Show welcome screen
// If user does not want to exit