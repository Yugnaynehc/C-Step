using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTree;

namespace BuildTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<char> charTree = new Tree<char>('M');
            InsertIntoTree<char>(charTree, 'X', 'A', 'M', 'Z', 'Z', 'N');
            charTree.WalkTree();
        }

        static void InsertIntoTree<T>(Tree<T> tree, params T[] data) where T : IComparable<T>
        {
            if (data.Length == 0)
                throw new ArgumentException("Must provide at least one data value");

            foreach (T datum in data)
            {
                tree.Insert(datum);
            }
        }
    }
}
