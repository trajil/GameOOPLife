namespace GameOOPLife;

public class Cell
{
    public bool Status { get; set; } = false;
    public List<Cell> Neighbours { get; set; } = [];

    public Cell(bool status)
    {
        this.Status = status;
    }
    public Cell()
    {
        
    }
    public void Kill()
    {
        Status = false;
    }
    public void Revive()
    {
        Status = true;
    }
    public override string ToString()
    {
        return Status? "█" : " ";
    }
}
