using System;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree<int> tree = new MyBinaryTree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(4);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(9);

            Console.WriteLine(tree.root.Value);
            Console.WriteLine(tree.root.Left.Value);
            Console.WriteLine(tree.root.Left.Right.Value);
            Console.WriteLine(tree.root.Right.Value);
            Console.WriteLine(tree.root.Right.Left.Value);
            Console.WriteLine(tree.root.Right.Right.Value);
            Console.WriteLine(tree.root.Right.Right.Right.Value);

            Console.WriteLine();
            tree.Remove(7);

            Console.WriteLine(tree.root.Value);
            Console.WriteLine(tree.root.Left.Value);
            Console.WriteLine(tree.root.Left.Right.Value);
            Console.WriteLine(tree.root.Right.Value);
            Console.WriteLine(tree.root.Right.Left.Value);
            Console.WriteLine(tree.root.Right.Right.Value);
        }
    }
}
