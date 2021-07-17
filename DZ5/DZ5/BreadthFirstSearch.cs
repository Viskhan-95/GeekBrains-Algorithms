using System;
using System.Collections.Generic;
using System.Text;
using static DZ5.Program;

namespace DZ5
{
    class BreadthFirstSearch
    {
        //Метод обхода в ширину
        public void BFSTraversal(Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.Write(node.Value + " ");

                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild);

                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }
        }
    }
}
