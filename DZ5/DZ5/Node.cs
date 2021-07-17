using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5
{
    class Node
    {
        public Node rootNode;

        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }


        //Метод заполнения Node
        public Node AddItem(int value)
        {
            var newNode = new Node { Value = value };

            if (rootNode == null)
            {
                rootNode = newNode;
                rootNode.LeftChild = null;
                rootNode.RightChild = null;
            }
            else
            {
                Node current = rootNode;
                Node parent;

                while (true)
                {
                    parent = current;
                    if (value < current.Value)
                    {
                        current = current.LeftChild;

                        if (current == null)
                        {
                            parent.LeftChild = newNode;
                            break;
                        }
                    }

                    else
                    {
                        current = current.RightChild;
                        if (current == null)
                        {
                            parent.RightChild = newNode;
                            break;
                        }
                    }
                }
            }
            return rootNode;
        }
    }
}
