namespace GameOOPLife;

public class GenerationWrapper
{
    Generation Generation;
    public int RowLength;
    public int ColLength;

    public GenerationWrapper(Generation generation, int rowlength)
    {
        this.Generation = generation;
        this.RowLength = rowlength;
        this.ColLength = Generation.Size / rowlength;
    }
    public Cell? GetCellAt(int x, int y)
    {
        if (x < 0 || x >= RowLength || y < 0 || y >= ColLength)
        {
            return null;
        }
        int index = y * RowLength + x;
        
        return Generation.Cells[index];
    }
    public (int, int) GetCoordinate(int index)
    {
        int x = index % RowLength;
        int y = index / RowLength;
        return (x, y);
    }
}
