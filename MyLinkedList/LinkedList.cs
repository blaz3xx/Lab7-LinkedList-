using System;
using System.Collections;
using System.Collections.Generic;


namespace ConsoleApp5
{

    public class Node
    {
        public Node(long value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
        public long Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

    }



    public class MyLinkedList : IEnumerable<long>
    {
        private Node head;
        private Node tail;
        private uint count;

        public void Add(long value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public uint Size => count;
        public bool isEmpty => count == 0;

        public void Clear()
        {
            if (isEmpty)
                throw new InvalidOperationException("Список уже очищений");

            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(long value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public long? firstElementDivisible(long number)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value % number == 0)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        public long sumOnEvenPositions()
        {
            long sum = 0;
            int i = 0;
            Node current = head;
            while (current != null)
            {
                if (i % 2 == 0)
                {
                    sum += current.Value;
                }
                current = current.Next;
                i++;
            }
            return sum;
        }

        public MyLinkedList filterGreaterThan(long value)
        {
            MyLinkedList result = new MyLinkedList();
            Node current = head;
            while (current != null)
            {
                if (current.Value > value)
                {
                    result.Add(current.Value);
                }
                current = current.Next;
            }
            return result;
        }

        public void RemoveNode(Node node)
        {
            if (node.Previous != null)
                node.Previous.Next = node.Next;
            else
                head = node.Next;

            if (node.Next != null)
                node.Next.Previous = node.Previous;
            else
                tail = node.Previous;

            count--;
        }


        public void removeGreaterThanAverage()
        {
            if (count == 0)
                return;
            long totalNumbers = 0;
            Node current = head;
            while (current != null)
            {
                totalNumbers += current.Value;
                current = current.Next;
            }

            double averageNumber = (double)totalNumbers / count;

            current = head;
            while (current != null)
            {
                Node next = current.Next;
                if (current.Value > averageNumber)
                {
                    RemoveNode(current);
                }
                current = next;
            }



        }
        public long this[int index]
        {
            get
            {
                if (isEmpty)
                {
                    throw new InvalidOperationException("Список порожній.");
                }
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Індекс поза межами діапазону.");
                }
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            set
            {
                if (isEmpty)
                {
                    throw new InvalidOperationException("Список порожній.");
                }
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Індекс поза межами діапазону.");
                }
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }
        public void removeAtIndex(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            RemoveNode(current);
        }

        public IEnumerator<long> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


