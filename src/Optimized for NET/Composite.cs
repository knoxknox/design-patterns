using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Composite.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Composite Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Build a tree of shapes
            TreeNode<Shape> root = new TreeNode<Shape> 
                    { Node = new Shape("Picture") };
            
            root.Add(new Shape("Red Line"));
            root.Add(new Shape("Blue Circle"));
            root.Add(new Shape("Green Box"));

            TreeNode<Shape> branch = root.Add(new Shape("Two Circles"));
            branch.Add(new Shape("Black Circle"));
            branch.Add(new Shape("White Circle"));

            // Add, remove, and add a shape
            Shape shape = new Shape("Yellow Line");
            root.Add(shape);
            root.Remove(shape);
            root.Add(shape);

            // Display tree using static method
            TreeNode<Shape>.Display(root, 1);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Generic tree node class
    /// </summary>
    /// <typeparam name="T">Node type</typeparam>
    class TreeNode<T> where T : IComparable<T>
    {
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();

        // Add a child tree node
        public TreeNode<T> Add(T child)
        {
            TreeNode<T> newNode = new TreeNode<T> { Node = child };
            _children.Add(newNode);
            return newNode;
        }

        // Remove a child tree node
        public void Remove(T child)
        {
            foreach (TreeNode<T> treeNode in _children)
            {
                if (treeNode.Node.CompareTo(child) == 0)
                {
                    _children.Remove(treeNode);
                    return;
                }
            }
        }

        // Gets or sets the node
        public T Node { get; set; }

        // Gets treenode children
        public List<TreeNode<T>> Children
        {
            get { return _children; }
        }

        // Recursively displays node and its children 
        public static void Display(TreeNode<T> node, int indentation)
        {
            string line = new String('-', indentation);
            Console.WriteLine(line + " " + node.Node);

            foreach (TreeNode<T> treeNode in node.Children)
            {
                Display(treeNode, indentation + 1);
            }
        }
    }

    /// <summary>
    /// Shape class
    /// <remarks>
    /// Implements generic IComparable interface
    /// </remarks>
    /// </summary>
 
    class Shape : IComparable<Shape>
    {
        private string _name;

        // Constructor
        public Shape(string name)
        {
            this._name = name;
        }

        // Override ToString method
        public override string ToString()
        {
            return _name;
        }

        // IComparable<Shape> Member
        public int CompareTo(Shape other)
        {
            return (this == other) ? 0 : -1;
        }
    }
}
