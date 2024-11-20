namespace GameOOPLife;

public static class Settings
{
    public static int SurvivalPercantage = 12;

    public static int RowLength = 160;
    public static int ColLength = 40;
    public static bool DoBordersExist = false;

    public static int GetSleepTimerFromFpsInput(double fps = 15)
    {
        double SleepTimer = 1000 / fps;

        return (int)SleepTimer;
    }
}