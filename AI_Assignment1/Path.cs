using System;
using System.Collections.Generic;

namespace AI_Assignment1
{
    public class Path
    {
        private List<Node> _path = new List<Node>();
        private enum Dir
        {
            up,
            down,
            left,
            right
        }

        public Path(Node pos)
        {
            this.Paths.Add(pos);
        }

        public Path() { }

        public void Direction()
        {
            for (int i = 1; i < Paths.Count; i++){Console.Write(GetDirection(Paths[i - 1].Position, Paths[i].Position) + "; ");}
        }

        private Dir GetDirection(Pos posA, Pos posB)
        {
            if (posA.Y > posB.Y)
            {
                return Dir.up;
            }

            if (posA.X > posB.X)
            {
                return Dir.left;
            }
               
            if (posB.Y > posA.Y)
            {
                return Dir.down;
            }

            if (posB.X > posA.X)
            {
                return Dir.right;
            }

            throw new Exception("Cannot return a direction.");
        }
        internal List<Node> Paths
        {
            get => _path;
            set => _path = value;
        }
    }
}