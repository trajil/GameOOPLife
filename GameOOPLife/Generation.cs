namespace GameOOPLife;

public class Generation
{
    public List<Cell> Cells { get; set; } = [];

    public int Size
    {
        get { return Cells.Count; }
    }
    public void AppendNewCell()
    {
        Cells.Add(new Cell());
    }
}
