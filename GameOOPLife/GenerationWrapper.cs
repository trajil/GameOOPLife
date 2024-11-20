namespace GameOOPLife;

public class GenerationWrapper
{
    Generation Generation;
    public bool DoBordersExist;
    public int RowLength;
    public int ColLength;

    public GenerationWrapper(Generation generation, int rowlength)
    {
        this.Generation = generation;
        this.RowLength = rowlength;
        this.ColLength = Generation.Size / rowlength;
        this.DoBordersExist = Settings.DoBordersExist;
    }

    public Cell? GetCellAt(int x, int y)
    {
        if (DoBordersExist)
        {
            if (x < 0 || x >= RowLength || y < 0 || y >= ColLength)
            {
                return null;
            }
        }
        else
        {
            if (y < 0)
            {
                y = ColLength - 1;
            }
            else if (y >= ColLength)
            {
                y = 0;
            }
            if (x < 0)
            {
                x = RowLength - 1;
            }
            else if (x >= RowLength)
            {
                x = 0;
            }
        }

        return Generation.Cells[y * RowLength + x];
    }

    public (int, int) GetCoordinate(int index)
    {
        int x = index % RowLength;
        int y = index / RowLength;
        return (x, y);
    }

    public int GetIndex(int x, int y)
    {
        return (y * RowLength + x);
    }
}
