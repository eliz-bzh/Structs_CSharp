using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

namespace Structs
{
    class MyListIterator<T> : IEnumerator<T>
    {
        private MyList<T> data;

        public T Current
        {
            get
            {
                Console.WriteLine("current");
                return myCurrent.Data;
            }
        }

        object IEnumerator.Current { get; }

        private Node<T> myCurrent;

        public MyListIterator(MyList<T> data)
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

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node() { Next = null; }
        public Node(T data, Node<T> next = null)
        {
            Next = next;
            Data = data;
        }
    }

    class MyList<T> : ICollection<T>
    {

        public Node<T> Head { get; private set; } = null;
        int Size { get; set; } = 0;

        public int Count => Size;

        public bool IsReadOnly => false;

        public MyList()
        {
            Head = new Node<T>();
        }

        Node<T> find_last()
        {
            Node<T> i = Head;
            for (; i.Next != null; i = i.Next) ;
            return i;
        }

        void push_back(T value)
        {
            Node<T> temp = find_last();
            temp.Next = new Node<T>(value);
            ++Size;
        }

        public void Add(T item)
        {
            push_back(item);
        }

        public void Clear()
        {
            Head = null;
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
            return new MyListIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
