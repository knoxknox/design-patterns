using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Bridge.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Bridge Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create RefinedAbstraction
            Customers customers = new Customers { Group = "Chicago" };

            // Set ConcreteImplementor
            customers.DataObject = new CustomersData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();

            customers.Add("Henry Velasquez");
            customers.ShowAll();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    class CustomersBase
    {
        // Gets or sets customer group
        public string Group { get; set; }

        // Gets or sets data object
        public IDataObject DataObject { get; set; }

        public virtual void Next()
        {
            DataObject.NextRecord();
        }

        public virtual void Prior()
        {
            DataObject.PriorRecord();
        }

        public virtual void Add(string name)
        {
            DataObject.AddRecord(name);
        }

        public virtual void Delete(string name)
        {
            DataObject.DeleteRecord(name);
        }

        public virtual void Show()
        {
            DataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + Group);
            DataObject.ShowAllRecords();
        }
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    class Customers : CustomersBase
    {
        public override void ShowAll()
        {
            // Add separator lines
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    /// <summary>
    /// The 'Implementor' interface
    /// </summary>
    interface IDataObject
    {
        void NextRecord();
        void PriorRecord();
        void AddRecord(string name);
        void DeleteRecord(string name);
        void ShowRecord();
        void ShowAllRecords();
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    class CustomersData : IDataObject
    {
        private List<string> _customers;
        private int _current = 0;

        // Constructor
        public CustomersData()
        {
            // Simulate loading from database
            _customers = new List<string>
              { "Jim Jones", "Samual Jackson", "Allan Good",
                "Ann Stills", "Lisa Giolani" };
        }

        public void NextRecord()
        {
            if (_current <= _customers.Count - 1)
            {
                _current++;
            }
        }

        public void PriorRecord()
        {
            if (_current > 0)
            {
                _current--;
            }
        }

        public void AddRecord(string customer)
        {
            _customers.Add(customer);
        }

        public void DeleteRecord(string customer)
        {
            _customers.Remove(customer);
        }

        public void ShowRecord()
        {
            Console.WriteLine(_customers[_current]);
        }

        public void ShowAllRecords()
        {
            _customers.ForEach(customer => 
                Console.WriteLine(" " + customer));
        }
    }
}
