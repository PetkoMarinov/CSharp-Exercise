using System;

namespace DoublyLinkedList
{
    public class LinkedList
    {
        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(element);
            }
            else
            {
                var newHead = new Node(element);
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(element);
            }
            else
            {
                var newTail = new Node(element);
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public int RemoveFirst(int element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.Next;

            if (this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }
            this.Count--;

            return firstElement;
        }

        public int RemoveLast(int element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.Previous;

            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;

            return lastElement;
        }

        public void ForEach (Action<int> action)
        {
            var currentNode = this.head;
            while (currentNode!=null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int counter = 0;

            var currentNode = this.head;
            while (currentNode!=null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }

            return array;
        }
    }
}
