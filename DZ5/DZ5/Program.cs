using DZ5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ5
{
    class Program
    {
        static void Main(string[] args)
        {
            var dfs = new DepthFirstSearch();
            var bfs = new BreadthFirstSearch();
            var tree = new Node();
            var rnd = new Random();

            Node node = null;

            for (int i = 0; i < 9; i++) //Цикл заполнения Node случайными числами
            {
                node = tree.AddItem(rnd.Next(1, 50));
            }

            Console.Write("DFS => ");
            dfs.DFSTraversal(node);

            Console.WriteLine();

            Console.Write("BFS => ");
            bfs.BFSTraversal(node);
        }
    }
}
