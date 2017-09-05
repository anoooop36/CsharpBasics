using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class GenericList<T>
    {

        private class Node
        {

            private T data;
            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }


            public Node(T _data)
            {
                next = null;
                data = _data;
            }
        }

        private Node head;

        public GenericList()
        {
            head = null;
        }

        public void AddData(T _data)
        {
            Node node = new Node(_data);
            node.Next = head;
            head = node;
        }

        //public T this[int Index] { get; set; }

        public void showList()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.Write("{0} ", currentNode.Data);
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }

    }
}
