//Sergio Garcia Balsas. Class used to display screens

class Screen
{
    protected Hardware hardware;

    public Screen(Hardware hardware)
    {
        this.hardware = hardware;
    }
    public virtual void Show()
    {
    }
}