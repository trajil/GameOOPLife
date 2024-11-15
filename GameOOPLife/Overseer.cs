namespace GameOOPLife;
public class Overseer
{
    public Generation CurrentGeneration { get; set; }
    public int Rowlength = 160;
    public int GenerationSize = 160*40;
    public int SurvivalPercantage = 12;
    public Overseer()
    {
        CurrentGeneration = InitializeGeneration();
        ReviveSomeRandomCells(SurvivalPercantage);

    }

    public void ForwardCurrentGeneration()
    {
        var nextGeneration = InitializeGeneration();

        int genSize = nextGeneration.Size;
        for (int i = 0; i < genSize; i++)
        {
            nextGeneration.Cells[i].Status = DecideCellFate(i);
        }
        CurrentGeneration = nextGeneration;
    }

    public Generation InitializeGeneration()
    {
        Generation result = new Generation();
        SpawnCells(result, GenerationSize);
        MakeCellsAcquinted(result);
        return result;
    }

    public bool DecideCellFate(int index)
    {
        Cell currentCell = GetCellByIndex(CurrentGeneration,index);

        int countLivingNeighbours = currentCell.Neighbours.Where(cell => cell.Status).Count();

        if (countLivingNeighbours == 3)
        {
            return true;
        }
        else if (countLivingNeighbours < 2 || countLivingNeighbours > 3)
        {
            return false;
        }
        return currentCell.Status;
    }
    public void SpawnCells(Generation generation, int n = 1)
    {
        for (int i = 0; i < n; i++)
        {
            generation.AppendNewCell();
        }
    }
    public void ReviveSomeRandomCells(int survivalPercentage)
    {
        Random random = new Random();

        for (int index = 0; index < GenerationSize; index++)
        {
            if (random.Next(100) <= survivalPercentage)
            {
                GetCellByIndex(index).Revive();

            }

        }

    }
    public void ReviveCell(int index)
    {
        GetCellByIndex(index).Revive();
    }
    public void KillCell(int index)
    {
        GetCellByIndex(index).Kill();
    }
    public void ChangeStatusOfCell(int index)
    {
        if (GetCellByIndex(index).Status)
        {
            KillCell(index);
        }
        else
        {
            ReviveCell(index);
        }
    }
    private Cell GetCellByIndex(Generation generation,int index)
    {
        return generation.Cells[index];
    }
    private Cell GetCellByIndex(int index)
    {
        return CurrentGeneration.Cells[index];
    }

    public void MakeCellAcquinted(Generation generation, int index)
    {
        Cell cell = GetCellByIndex(generation,index);
        GenerationWrapper wrapper = new GenerationWrapper(generation, Rowlength);
        (int, int) coordinate = wrapper.GetCoordinate(index);

        for (int y = coordinate.Item2 - 1; y <= coordinate.Item2 + 1; y++)
        {
            for (int x = coordinate.Item1 - 1; x <= coordinate.Item1 + 1; x++)
            {
                if (x == coordinate.Item1 && y == coordinate.Item2)
                {
                    continue;
                }

                Cell? newNeighbour = wrapper.GetCellAt(x, y);

                if (newNeighbour == null)
                {
                    continue;
                }
                cell.Neighbours.Add(newNeighbour);
            }
        }
    }
    public void MakeCellsAcquinted(Generation generation)
    {
        int iterations = generation.Size;
        for (int index = 0; index < iterations; index++)
        {
            MakeCellAcquinted(generation, index);
        }
    }

}