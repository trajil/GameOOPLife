namespace GameOOPLife;
public class Overseer
{
    public Generation CurrentGeneration { get; set; }
    public int Rowlength = 161;
    public int GenerationSize = 161 * 49;
    public int SurvivalPercantage = 20;


    public Overseer(int rowLength, int colLength)
    {
        this.Rowlength = rowLength;
        this.GenerationSize = rowLength * colLength;
        CurrentGeneration = InitializeGeneration();

    }

    public void SpawnFormsOnSpecificPlace(Generation generation)
    {
        List<(string, int)> forms = new List<(string, int)>();
        GenerationWrapper wrapper = new GenerationWrapper(generation, Rowlength);

        //forms.Add(("simpleCell", wrapper.GetIndex(0,0)));
        //forms.Add(("glider", wrapper.GetIndex(90, 3)));
        //forms.Add(("octagon", wrapper.GetIndex(70, 5)));
        forms.Add(("pulsator", wrapper.GetIndex(70, 5)));
        //forms.Add(("tuemmler", wrapper.GetIndex(70, 25)));
        forms.Add(("gosper_glider_gun", wrapper.GetIndex(0, 0)));
        //forms.Add(("glider", wrapper.GetIndex(0, 0)));

        foreach (var item in forms)
        {
            SpawnFormOnSpecificPlace( item.Item1, generation, item.Item2);
        }
    }

    public void SpawnFormOnSpecificPlace(string name, Generation generation, int upperLeftCornerSpawnIndex = 0)
    {

        ExternalForm form = new ExternalForm(name);
        List<char> input = form.Form;
        int formWidth = form.FormWidth;
        int formSize = input.Count;
        int formHeight = formSize / formWidth;

        GenerationWrapper wrapper = new GenerationWrapper(generation, Rowlength);
        (int, int) upperLeftCoordinate = wrapper.GetCoordinate(upperLeftCornerSpawnIndex);

        int indexInForm = 0;
        for (int y = upperLeftCoordinate.Item2; y < formHeight + upperLeftCoordinate.Item2; y++)
        {
            for (int x = upperLeftCoordinate.Item1; x < formWidth + upperLeftCoordinate.Item1; x++)
            {
                if (input[indexInForm] == 'X')
                {
                    generation.Cells[wrapper.GetIndex(x, y)].Revive();
                }
                else if (input[indexInForm] == 'O')
                {
                    generation.Cells[wrapper.GetIndex(x, y)].Kill();
                }
                indexInForm++;
            }

        }
    }

    //public void tmp() {

    //    Glider g = new Glider(0,0);

    //    GenerationWrapper wrapper = new GenerationWrapper(generation, Rowlength);

    //    foreach(var node in g.Nodes)
    //    {
    //        var t = g.GetNodeCoordinate(node);
    //        wrapper.GetCellAt(t.Item1, t.Item2).Revive();

    //    }
    //}

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
        Cell currentCell = GetCellByIndex(index, CurrentGeneration);

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
    private Cell GetCellByIndex(int index, Generation generation)
    {
        return generation.Cells[index];
    }
    private Cell GetCellByIndex(int index)
    {
        return CurrentGeneration.Cells[index];
    }

    public void MakeCellAcquinted(Generation generation, int index)
    {
        Cell cell = GetCellByIndex(index, generation);
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