using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace AI_Assignment1
{
    static class main
    {
        static void Main(string[] args)
        {
            Map map;
            string file = args[0] + ".txt";
            string algorithm = args[1];
            map = new Map(file);

            switch (algorithm.ToLower())
            {
                case "bfs":
                    {
                        //new timer
                        var Timer = new Stopwatch();

                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.BFS(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " Breadth first search " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) BFS: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                case "dfs":
                    {
                        var Timer = new Stopwatch();
                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.DFS(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " Depth first search " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) for DFS: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                case "as":
                    {
                        var Timer = new Stopwatch();
                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.AStar(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " A Star " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) for A&: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                case "uni":
                    {
                        var Timer = new Stopwatch();
                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.UniformCost(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " Uniformcost " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) for DFS: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                case "gbfs":
                    {
                        var Timer = new Stopwatch();
                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.GreedyBest(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " Greedy best first search " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) for DFS: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                case "bi":
                    {
                        var Timer = new Stopwatch();
                        Algorithm search = new Algorithm(map);

                        Timer.Start();
                        Path path = search.Bi(map.StartPos, map.Goal[0]);
                        Timer.Stop();

                        Console.WriteLine(file + " Bidirectional bfs search " + search.nodes);
                        path.Direction();

                        Console.WriteLine("\nTime taken (ms) for DFS: " + Timer.ElapsedMilliseconds);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}