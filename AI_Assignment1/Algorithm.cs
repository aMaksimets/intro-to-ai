using System;
using System.Collections.Generic;

namespace AI_Assignment1
{
    public class Algorithm
    {
        private Map _map;
        private int _nodes;
        private int _frontier;
        private int _iteration;
        private const int MAX = 1000;

        public Algorithm(Map map)
        {
            Map = map;
        }

        public Path DFS(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;

            Node sNode = new Node(start);
            Node node = new Node(start);
            Node gNole = new Node(goal);

            List<Node> oList = new List<Node>();
            HashSet<Node> cList = new HashSet<Node>();

            oList.Add(sNode);

            while (oList.Count != 0)
            {
                node = oList[0];
                oList.RemoveAt(0);
                cList.Add(node);

                if (node.Equals(gNole)){ break; }
                if (Iteration > MAX){ break; }

                foreach (Node neighbour in Map.Neighbours(node))
                {
                    if (cList.Contains(neighbour) || !Map.IsValid(neighbour.Position))
                    {
                        continue;
                    }

                    if (!oList.Contains(neighbour))
                    {
                        neighbour.Parent = node;
                        oList.Add(neighbour);
                    }
                }

                Iteration++;
            }

            if (node.Equals(gNole))
            {
                nodes = oList.Count + cList.Count;
                frontier = oList.Count;
                return path(sNode, node);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        public Path BFS(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;
            Node sNode = new Node(start);
            Node gNole = new Node(goal);
            Queue<Node> oList = new Queue<Node>();
            HashSet<Node> cList = new HashSet<Node>();
            Node node = sNode;
            oList.Enqueue(node);

            while (oList.Count != 0)
            {
                node = oList.Dequeue();
                cList.Add(node);

                if (node.Equals(gNole))
                {
                    break;
                }

                if (Iteration > MAX)
                {
                    break;
                }

                foreach (Node neighbour in Map.Neighbours(node))
                {
                    if (cList.Contains(neighbour) || !Map.IsValid(node.Position))
                    {
                        continue;
                    }

                    if (!oList.Contains(neighbour))
                    {
                        neighbour.Parent = node;
                        oList.Enqueue(neighbour);
                    }
                }
                Iteration++;
            }

            if (node.Equals(gNole))
            {
                nodes = oList.Count + cList.Count;
                frontier = oList.Count;
                return path(sNode, node);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        public Path GreedyBest(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;
            Node sNode = new Node(start);
            Node gNole = new Node(goal);
            Queue<Node> oList = new Queue<Node>();
            HashSet<Node> cList = new HashSet<Node>();
            Node node = sNode;
            oList.Enqueue(node);
            node.HCost = Manhattan(node, gNole);

            while (oList.Count != 0)
            {
                node = oList.Dequeue();
                cList.Add(node);

                if (node.Equals(gNole))
                {
                    break;
                }

                if (Iteration > MAX)
                {
                    break;
                }

                foreach (Node neighbour in Map.Neighbours(node))
                {
                    if (cList.Contains(neighbour) || !Map.IsValid(neighbour.Position))
                    {
                        continue;
                    }

                    neighbour.HCost = Manhattan(neighbour, gNole);
                    if (!oList.Contains(neighbour) || node.HCost > neighbour.HCost)
                    {
                        neighbour.Parent = node;
                        oList.Enqueue(neighbour);
                    }
                }
                Iteration++;
            }

            if (node.Equals(gNole))
            {
                nodes = oList.Count + cList.Count;
                frontier = oList.Count;
                return path(sNode, node);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        public Path AStar(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;
            Node sNode = new Node(start);
            Node gNole = new Node(goal);
            List<Node> oList = new List<Node>();
            HashSet<Node> cList = new HashSet<Node>();
            oList.Add(sNode);
            Node node = sNode;
            node.HCost = Manhattan(node, gNole);

            while (oList.Count != 0)
            {
                oList.Sort((n1, n2) => (n1.FCost).CompareTo(n2.FCost));
                node = oList[0];

                oList.Remove(node);
                cList.Add(node);

                if (node.Equals(gNole))
                {
                    break;
                }

                if (Iteration > MAX)
                {
                    break;
                }

                foreach (Node neighbour in Map.Neighbours(node))
                {
                    if (!Map.IsValid(neighbour.Position) || cList.Contains(neighbour))
                    {
                        continue;
                    }
                    neighbour.GCost = node.GCost + Manhattan(node, neighbour);
                    neighbour.HCost = Manhattan(neighbour, gNole);

                    if (node.FCost > neighbour.FCost || !oList.Contains(neighbour))
                    {
                        neighbour.Parent = node;

                        if (!oList.Contains(neighbour))
                        {
                            oList.Add(neighbour);
                        }
                    }
                }

                Iteration++;
            }

            if (node.Equals(gNole))
            {
                nodes = oList.Count + cList.Count;
                frontier = oList.Count;
                return path(sNode, node);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        //Custom algorithms

        public Path UniformCost(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;
            Node sNode = new Node(start);
            Node gNole = new Node(goal);

            Queue<Node> oList = new Queue<Node>();
            HashSet<Node> cList = new HashSet<Node>();

            Node node = sNode;
            oList.Enqueue(node);
            node.HCost = Manhattan(node, gNole);

            while (oList.Count != 0)
            {
                node = oList.Dequeue();
                cList.Add(node);

                if (node.Equals(gNole))
                {
                    break;
                }

                if (Iteration > MAX)
                {
                    break;
                }

                foreach (Node neighbour in Map.Neighbours(node))
                {
                    if (cList.Contains(neighbour) || !Map.IsValid(neighbour.Position))
                    {
                        continue;
                    }

                    neighbour.Parent = node;
                    neighbour.GCost = neighbour.Parent.GCost + 1;

                    if (node.GCost < neighbour.GCost)
                    { 
                        if (!oList.Contains(neighbour))
                        {
                            oList.Enqueue(neighbour);
                        }
                    }
                }

                Iteration++;
            }

            if (node.Equals(gNole))
            {
                nodes = oList.Count + cList.Count;
                frontier = oList.Count;
                return path(sNode, node);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        public Path Bi(Pos start, Pos goal)
        {
            nodes = 0;
            frontier = 0;
            Iteration = 0;
            Node sNode = new Node(start);
            Node gNole = new Node(goal);
            Queue<Node> oList1 = new Queue<Node>();
            Queue<Node> oList2 = new Queue<Node>();
            HashSet<Node> cList = new HashSet<Node>();

            oList1.Enqueue(sNode);
            oList2.Enqueue(gNole);

            Node node1 = sNode;
            Node node2 = gNole;

            while (oList1.Count != 0 && oList2.Count != 0)
            {
                Bi(oList1, cList, node1);
                Bi(oList2, cList, node2);

                if (BiIntersect(oList1, oList2) != null)
                {
                    break;
                }
                if (Iteration > MAX)
                {
                    break;
                }
                Iteration++;
            }

            if (BiIntersect(oList2, oList1) != null)
            {
                nodes = oList2.Count + oList1.Count + cList.Count;
                frontier = oList1.Count + oList2.Count;
                return BiPath(oList1, oList2, sNode, gNole);
            }
            else
            {
                throw new Exception("No valid path found");
            }
        }

        void Bi(Queue<Node> oList, HashSet<Node> cList, Node node)
        {
            node = oList.Dequeue();
            cList.Add(node);

            foreach (Node neighbour in Map.Neighbours(node))
            {
                if (cList.Contains(neighbour) || !Map.IsValid(neighbour.Position))
                {
                    continue;
                }

                if (!oList.Contains(neighbour))
                {
                    neighbour.Parent = node;
                    oList.Enqueue(neighbour);
                }
            }
        }

        Node BiIntersect(Queue<Node> oList1, Queue<Node> oList2)
        {
            foreach (Node n in oList1)
            {
                if (oList2.Contains(n))
                {
                    return n;
                }
            }

            return null;
        }

        Path BiPath(Queue<Node> list1, Queue<Node> list2, Node sNode, Node gNole)
        {
            Path path = new Path();
            Node current = BiIntersect(list1, list2);

            while (current != null && current != gNole)
            {
                path.Paths.Add(current);
                current = current.Parent;
            }

            path.Paths.Reverse();

            current = BiIntersect(list2, list1).Parent;
            while (current != null && current != sNode)
            {
                path.Paths.Add(current);
                current = current.Parent;
            }

            return path;
        }

        float Manhattan(Node n1, Node n2)
        {
            float distX = Math.Abs(n1.Position.X - n2.Position.X);
            float distY = Math.Abs(n1.Position.Y - n2.Position.Y);

            return distX + distY;
        }
        Path path(Node sNode, Node finalNode)
        {
            Path path = new Path();
            Node current = finalNode;

            while (current != null && current != sNode)
            {
                path.Paths.Add(current);
                current = current.Parent;
            }

            path.Paths.Add(sNode);
            path.Paths.Reverse();

            return path;
        }

        public int nodes
        { get => _nodes; private set => _nodes = value;}

        public int frontier
        { get => _frontier; private set => _frontier = value; }

        public int Iteration
        { get => _iteration; private set => _iteration = value; }
        public Map Map
        { get => _map; set => _map = value; }
    }
}
