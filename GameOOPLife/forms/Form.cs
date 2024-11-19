namespace GameOOPLife
{
    public class Form
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Node> Nodes { get; set; } = [];

        public Form(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }


        public (int, int) GetNodeCoordinate(Node node)
        {
            return (X + node.X, X + node.Y);
        }
    }
}
