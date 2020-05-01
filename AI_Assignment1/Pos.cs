namespace AI_Assignment1
{
    public class Pos
    {
        private int _x;
        private int _y;
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        { get => _x; private set => _x = value; }

        public int Y
        { get => _y; private set => _y = value; }
    }
}
