using System;
using System.IO;

namespace AI_Assignment1
{
    static class Program
    {
        static void Main(string[] args)
        {
            string fileStatus = (args.Length >= 2) ? "Loading!" : "Syntax: <AI_Assignment1> <file> <bfs|dfs>";
            Console.WriteLine(fileStatus);

            string Algo = args[1];
            _ = args[0] + ".txt";

            // case swap for Alogrithm
        }
    }
}