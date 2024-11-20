namespace GameOOPLife;

public static class GameMode
{
    public static void RunMode(Overseer overseer, string mode = "random")
    {
        switch (mode)
        {
            case "random":
                {
                    overseer.ReviveSomeRandomCells();
                }
                break;

            case "custom":
                {

                }
                break;
        }
    }
}
