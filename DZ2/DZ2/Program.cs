using System;

namespace DZ2
{
    class Program
    {
        
        public class Node
        {
            public Node head;
            public Node tail;

            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }


            public interface ILinkedList
            {
                int GetCount(); //Возвращает кол-во элементов в списке
                void AddNode(int value); // добавляет новый элемент списка
                void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
                void RemoveNode(int index); // удаляет элемент по порядковому номеру
                void RemoveNode(Node node); // удаляет указанный элемент
                Node FindNode(int searchValue); // ищет элемент по его значению
            }


            public int GetCount()
            {
                int count = 0;
                var node = head;
                
                while (node != null)
                {
                    node = node.NextNode;
                    count++;
                }
                return count;
            }


            public void AddNode(int value)
            {
                var newNode = new Node { Value = value };

                if (tail == null)
                {
                    newNode.NextNode = null;
                    newNode.PrevNode = null;
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.NextNode = newNode;
                    newNode.PrevNode = tail;
                    tail = newNode;
                }
            }


            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };

                if (node == null)
                    return;

                if (node.NextNode == null)
                {
                    node.NextNode = newNode;
                    newNode.PrevNode = node;
                    newNode.NextNode = null;
                    tail = newNode;
                }
                else
                {
                    var nextNode = node.NextNode;
                    node.NextNode = newNode;
                    newNode.NextNode = nextNode;

                    node.NextNode.NextNode.PrevNode = newNode;
                    newNode.PrevNode = node;
                }
            }


            public void RemoveNode(int index)
            {
                if (index == 1) // Тут вопрос зарожlался, элементы ничанать с 0 как в массивах или с 1
                    RemoveNode(head);
                else if (GetCount() == index)
                    RemoveNode(tail);
                else
                {
                    var delNode = head.NextNode;
                    int count = 2;
                    while(delNode != null)
                    {
                        if(count == index - 1)
                        {
                            RemoveNode(delNode);
                            break;
                        }
                        delNode = delNode.NextNode;
                        count++;
                    }
                }
            }


            public void RemoveNode(Node node)
            {
                if (node == null)
                    return;

                if(node.PrevNode == null)
                {
                    head.NextNode.PrevNode = null;
                    head = head.NextNode;
                    node.NextNode = null;
                }
                
                else if(node.NextNode == null)
                {
                    tail = node.PrevNode;
                    node.PrevNode.NextNode = null;
                }

                else
                {
                var nextNode = node.NextNode;
                var prevNode = node.NextNode.PrevNode;

                    node.PrevNode.NextNode = nextNode;
                    node.NextNode.PrevNode = prevNode;
                }

            }


            public Node FindNode(int searchValue)
            {
                var findNode = head;
                while(findNode != null)
                {
                    if(findNode.Value == searchValue)
                    {
                        return findNode;
                    }
                    findNode = findNode.NextNode;
                }
                return null;
            }
        }

        static void Main(string[] args)
        {
            var node = new Node();

        }
    }
}
