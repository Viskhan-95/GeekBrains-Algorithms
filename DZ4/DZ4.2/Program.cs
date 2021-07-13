using System;
using System.Collections.Generic;

namespace DZ4._2
{
    class Program
    {
        /*
         * Не успел реализовать метод удаления и попробовать на роботоспособноть, доработаю.
         * Единственное не понял, зачем в задании были даны методы TreeHelper и NodeInfo
         * Нужно было работать с возврашаемым массивом из TreeHelper?
         * Нужно ли переопределить метод GetHashCode()?
         */
        public TreeNode rootNode;
        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }
            public TreeNode Parent { get; set; }

            public override bool Equals(object obj)
            {
                var node = obj as TreeNode;

                if (node == null)
                    return false;

                return node.Value == Value;
            }
        }


        public interface ITree
        {
            TreeNode GetRoot();
            void AddItem(int value); // добавить узел
            void RemoveItem(int value); // удалить узел по значению
            TreeNode GetNodeByValue(int value); //получить узел дерева по значению
            void PrintTree(); //вывести дерево в консоль
        }


        public static class TreeHelper
        {
            public static NodeInfo[] GetTreeInLine(ITree tree)
            {
                var bufer = new Queue<NodeInfo>();
                var returnArray = new List<NodeInfo>();
                var root = new NodeInfo() { Node = tree.GetRoot() };
                bufer.Enqueue(root);

                while (bufer.Count != 0)
                {
                    var element = bufer.Dequeue();
                    returnArray.Add(element);

                    var depth = element.Depth + 1;

                    if (element.Node.LeftChild != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.LeftChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(left);
                    }
                    if (element.Node.RightChild != null)
                    {
                        var right = new NodeInfo()
                        {
                            Node = element.Node.RightChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(right);
                    }
                }

                return returnArray.ToArray();
            }
        }


        public class NodeInfo
        {
            public int Depth { get; set; }
            public TreeNode Node { get; set; }
        }


        TreeNode GetRoot()
        {
            return rootNode;
        }


        void AddItem(int value)
        {
            var newTreeNode = new TreeNode { Value = value };

            if (rootNode == null)
            {
                rootNode = newTreeNode;
                rootNode.Parent = null;
                rootNode.LeftChild = null;
                rootNode.RightChild = null;
            }
            else
            {
                TreeNode current = rootNode;
                TreeNode parent;

                while(true)
                {
                    parent = current;
                    if(value < current.Value)
                    {
                        current = current.LeftChild;

                        if(current == null)
                        {
                            parent.LeftChild = newTreeNode;
                            break;
                        }
                        else
                        {
                            current = current.RightChild;
                            if(current == null)
                            {
                                parent.RightChild = newTreeNode;
                                break;
                            }
                        }
                    }
                }
            }
        }


        TreeNode GetNodeByValue(int value)
        {
            if (rootNode.Value == value)
                return rootNode;
            
            TreeNode current = rootNode;
            while(true)
            {
                if(current.Value > value)
                {
                    current = current.LeftChild;
                    if (current.Value == value)
                        return current;
                }
                else
                {
                    current = current.RightChild;
                    if (current.Value == value)
                        return current;
                }
            }
        }


        void PrintTree(TreeNode treeNode, string str = "")
        {
            if(treeNode != null)
            {
                Console.WriteLine("{1}{0}", treeNode.Value, str);
                PrintTree(treeNode.LeftChild, $"{str}{new string(' ', 2)}");
                PrintTree(treeNode.RightChild, $"{str}{new string(' ', 2)}");
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
