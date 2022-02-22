using System;
using System.Collections.Generic;

// Зубарев Филипп

class Progrram{ 

    class StackItem
    {
        public int value, min, max;
        public StackItem parent;


        public StackItem(int value, StackItem stackItem, int min, int max)
        {
            this.value = value;
            this.parent = stackItem;
            this.min = min;
            this.max = max;
        }
    }

    class Stack
    {
        public int count = 0;
        public StackItem Current;

        public Stack()
        {
            count = 0;
        }

        public void Push(int value)
        {
            if (Current == null)
                Current = new StackItem(value, Current, value, value);
            else
            {
                var max = 0;
                var min = 0;
                if (Current.max >= value)
                    max = Current.max;
                else
                    max = value;
                if (Current.min <= value)
                    min = Current.min;
                else
                    min = value;
                Current = new StackItem(value, Current, min, max);
            }
            count++;
        }

        public int Pop()
        {
            var ret = Current.value;
            Current = Current.parent;
            count--;
            return Current.value;
        }
        public int GetMax()
        {
            return Current.max;
        }
        public int GetMin()
        {
            return Current.min;
        }
        public void Clear(){ Current = null; }
    }

    class Queue
    {
        Stack s1 = new Stack();
        Stack s2 = new Stack();

        public int Count { get { return s1.count; } }

        public void Enqueue(int element)
        {
            s1.Push(element);
        }
        public int Dequeue()
        {
            if (s2.count == 0)
                while (s1.count > 0) { s2.Push(s1.Pop()); }
            return s2.Pop();
        }
    }

    public static void Main()
    {
        
    }
}
