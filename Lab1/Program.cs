using System;
using Lab1.Stack;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mystack = new NewStack<int>();

            mystack.OnPush += (int t) => Console.WriteLine("On Push: " + t);
            mystack.OnPop += (int t) => Console.WriteLine("On Pop: " + t);
            mystack.OnPeek += (int t) => Console.WriteLine("On Peek: " + t);
            mystack.OnClear += () => Console.WriteLine("On Clear");

            mystack.Push(13);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(40);
            mystack.Push(5);
            Console.WriteLine(mystack.Peek());

            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
        }
    }
}
