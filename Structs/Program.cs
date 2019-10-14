using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            /*MyList<int> list = new MyList<int>();

            for (int i = 0; i != 5; ++i)
            {
                list.Add(i);
            }

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }*/


            MyStack<int> stack = new MyStack<int>();

            for(int i = 0; i != 5; ++i)
            {
                stack.Add(i);
            }
            stack.pop();

            stack.print();

            Console.ReadLine();
        }
    }
}
