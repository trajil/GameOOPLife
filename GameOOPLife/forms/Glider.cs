namespace GameOOPLife
{
    /*
        * 0 0 1
        * 1 0 1
        * 0 1 1
        */
    public class Glider : Form
    {
        public Glider(int x, int y) : base(x,y)
        {
            Nodes.Add(new Node { X = 2, Y = 0 });
            Nodes.Add(new Node { X = 2, Y = 1 });
            Nodes.Add(new Node { X = 2, Y = 2 });
            Nodes.Add(new Node { X = 0, Y = 1 });
            Nodes.Add(new Node { X = 1, Y = 2 });
        }
    }
}
