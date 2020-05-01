using System.Collections.Generic;
using System.IO;

namespace AI_Assignment1
{
    public class Map
    {
        private int[] _dimensions = new int[2] { 0, 0 };
        private byte[,] _mapValues;
        private Pos[] _goal = new Pos[2];
        private Pos _startPos;

        public enum MapCodec : byte
        {
            Empty = 0,
            Wall = 1,
            Player = 2,
            Goal = 3
        }

        public Map(string fileName)
        {
            loadFile(fileName);
        }
        public void loadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            try
            {
                string line = reader.ReadLine();
                string[] coords = line.Trim('[', ']').Split(',');
                Dimensions[0] = coords[1].toINT();
                Dimensions[1] = coords[0].toINT();

                MapValues = new byte[Dimensions[0], Dimensions[1]];

                line = reader.ReadLine();
                coords = line.Trim('(', ')').Split(',');
                MapValues[coords[0].toINT(), coords[1].toINT()] = 2;
                StartPos = new Pos(coords[0].toINT(), coords[1].toINT());

                line = reader.ReadLine();
                string[] sets = line.Replace(" ", string.Empty).Split('|');
                for (int i = 0; i < sets.Length; i++)
                {
                    coords = sets[i].Trim('(', ')').Split(',');
                    MapValues[coords[0].toINT(), coords[1].toINT()] = 3;
                    Goal[i] = new Pos(coords[0].toINT(), coords[1].toINT());
                }

                while(!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    coords = line.Trim('(', ')').Split(',');

                    for (int i = 0; i < coords[2].toINT(); i++)
                    {
                        for(int j = 0; j < coords[3].toINT(); j++)
                        {
                            MapValues[coords[0].toINT() + i, coords[1].toINT() + j] = 1;
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }
        public List<Node> Neighbours(Node node)
        {
            List<Node> neighbouringNodes = new List<Node>();

            int xCheck;
            int yCheck;

            xCheck = node.Position.X;
            yCheck = node.Position.Y - 1;
            if (xCheck >= 0 && xCheck < Dimensions[0])
            {
                if (yCheck >= 0 && yCheck < Dimensions[1])
                {
                    neighbouringNodes.Add(new Node(new Pos(xCheck, yCheck)));
                }
            }
            xCheck = node.Position.X - 1;
            yCheck = node.Position.Y;
            if (xCheck >= 0 && xCheck < Dimensions[0])
            {
                if (yCheck >= 0 && yCheck < Dimensions[1])
                {
                    neighbouringNodes.Add(new Node(new Pos(xCheck, yCheck)));
                }
            }

            xCheck = node.Position.X + 1;
            yCheck = node.Position.Y;
            if (xCheck >= 0 && xCheck < Dimensions[0])
            {
                if (yCheck >= 0 && yCheck < Dimensions[1])
                {
                    neighbouringNodes.Add(new Node(new Pos(xCheck, yCheck)));
                }
            }

            xCheck = node.Position.X;
            yCheck = node.Position.Y + 1;
            if (xCheck >= 0 && xCheck < Dimensions[0])
            {
                if (yCheck >= 0 && yCheck < Dimensions[1])
                {
                    neighbouringNodes.Add(new Node(new Pos(xCheck, yCheck)));
                }
            }

            return neighbouringNodes;
        }

        public bool IsValid(Pos p)
        {
            if(NotWall(p) && IsInBounds(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotWall(Pos p)
        {
            if(MapValues[p.X, p.Y] == (byte)MapCodec.Wall)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsInBounds(Pos p)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= Dimensions[0] || p.Y >= Dimensions[1])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int[] Dimensions
        { get => _dimensions; set => _dimensions = value; }

        public byte[,] MapValues
        { get => _mapValues; set => _mapValues = value; }

        public Pos[] Goal
        { get => _goal; set => _goal = value; }

        public Pos StartPos
        {
            get => _startPos;
            set => _startPos = value;
        }
    }

}
