using System;
using System.Collections;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Iterator.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Iterator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create and item collection
            ItemCollection<Item> collection = new ItemCollection<Item>
              {
                new Item{ Name = "Item 0"},
                new Item{ Name = "Item 1"},
                new Item{ Name = "Item 2"},
                new Item{ Name = "Item 3"},
                new Item{ Name = "Item 4"},
                new Item{ Name = "Item 5"},
                new Item{ Name = "Item 6"},
                new Item{ Name = "Item 7"},
                new Item{ Name = "Item 8"}
              };

            Console.WriteLine("Iterate front to back");
            foreach (Item item in collection)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nIterate back to front");
            foreach (Item item in collection.BackToFront)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            // Iterate given range and step over even ones
            Console.WriteLine("\nIterate range (1-7) in steps of 2");
            foreach (Item item in collection.FromToStep(1, 7, 2))
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    /// <typeparam name="T">Collection item type</typeparam>
    class ItemCollection<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T t)
        {
            _items.Add(t);
        }

        // The 'ConcreteIterator'
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        public IEnumerable<T> FrontToBack
        {
            get { return this; }
        }

        public IEnumerable<T> BackToFront
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    yield return _items[i];
                }
            }
        }

        public IEnumerable<T> FromToStep(int from, int to, int step)
        {
            for (int i = from; i <= to; i = i + step)
            {
                yield return _items[i];
            }
        }

        // Gets number of items
        public int Count
        {
            get { return _items.Count; }
        }

        // System.Collections.IEnumerable member implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The collection item
    /// </summary>
    class Item
    {
        // Gets or sets item name
        public string Name { get; set; }
    }
}
