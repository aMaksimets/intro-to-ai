using System;
using System.Collections.Generic;

namespace AI_Assignment1
{
    public class Node : IEquatable<Node>
    {
        private float _gCost;
        private float _hCost;
        private Pos _position;

        public double FCost
        {
            get
            {
                return (float)(GCost + HCost);
            }
        }

        public Node(Pos pos, Node parent = null)
        {
            Position = pos;
            Parent = parent;
            GCost = 0;
        }

        public bool Equals(Node other)
        {
            return null != other && (Position.X == other.Position.X && Position.Y == other.Position.Y);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        public override int GetHashCode()
        {
            return -425505606 + EqualityComparer<Pos>.Default.GetHashCode(Position);
        }

        public Node Parent
        { get; set; }

        public float GCost
        { get => _gCost; set => _gCost = value; }

        public float HCost
        { get => _hCost; set => _hCost = value; }

        public Pos Position
        { get => _position; private set => _position = value; }
    }
}
