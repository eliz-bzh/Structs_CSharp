using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Structs
{
    class MyStackIterator<T> : IEnumerator<T>
    {
        private MyStack<T> data;

        public T Current
        {
            get
            {
                Console.WriteLine("current");
                return myCurrent.Data;
            }
        }

        object IEnumerator.Current { get; }

        private NodeStack<T> myCurrent;

        public MyStackIterator(MyStack<T> data)
        {
            this.data = data;
            myCurrent = data.Head;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            Console.WriteLine("moveNext");
            myCurrent = myCurrent.Next;
            return myCurrent != null;
        }

        public void Reset() { }
    }
    public class NodeStack<T>
    {
        public NodeStack<T> Next { get; set; }
        public T Data { get; set; }
        public NodeStack() { Next = null; }
        public NodeStack(T data, NodeStack<T> next = null)
        {
            Next = next;
            Data = data;
        }
    }
    class MyStack<T> : ICollection<T>
    {
        public NodeStack<T> Head { get; private set; } = null;
        public NodeStack<T> Tail { get; private set; } = null;
        int Size { get; set; } = 0;

        public int Count => Size;

        public bool IsReadOnly => false;

        public MyStack()
        {
            Head = new NodeStack<T>();
        }

        void push(T value)
        {
            NodeStack<T> temp = new NodeStack<T>(value);
            if (Tail == null)
            {
                Tail = temp;
            }
            else
            {
                temp.Next = Tail;
                Tail = temp;
            }
            ++Size;
        }

        public T top()
        {
            if (Tail == null)
            {
                Console.WriteLine("Stack is empty!");
            }
            return Tail.Data;
        }

        public void pop()
        {
            if (Tail == null)
            {
                Console.WriteLine("Stack is empty!");
            }
            NodeStack<T> delptr = Tail;
            Tail = Tail.Next;
            //delete delptr;
        }

        public void print()
        {
            if (Tail == null)
            {
                Console.WriteLine("Stack is empty!");
            }
            for (NodeStack<T> ptr = Tail; ptr != null; ptr = ptr.Next)
            {
                Console.WriteLine(ptr.Data);
            }
        }

        public void Add(T item)
        {
            push(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public bool Contains(T item)
        {
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
        }

        public bool Remove(T item)
        {
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("GetEnumerator");
            return new MyStackIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

