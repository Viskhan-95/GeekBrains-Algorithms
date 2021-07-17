using System;
using System.Collections.Generic;
using System.Text;
using static DZ5.Program;

namespace DZ5
{
    class DepthFirstSearch
    {
        //Метод обхода в глубину
        public void DFSTraversal(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + " ");
            DFSTraversal(node.LeftChild);
            DFSTraversal(node.RightChild);
        }
    }
}
