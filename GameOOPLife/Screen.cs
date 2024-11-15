namespace GameOOPLife;

public static class Screen
{
    public static void Show(GenerationWrapper generationWrapper, int? generationCounter)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Generation: {generationCounter}");

        string result = "";

        for (int y = 0; y < generationWrapper.ColLength; y++)
        {
            for (int x = 0; x < generationWrapper.RowLength; x++)
            {
                result += generationWrapper.GetCellAt(x, y).ToString();



            }
            result += "\n";

        }


        Console.WriteLine(result);
    }
}
