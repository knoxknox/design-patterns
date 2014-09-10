using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace DoFactory.GangOfFour.Memento.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Memento Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Init sales prospect through object initialization
            SalesProspect s = new SalesProspect
                      {
                          Name = "Joel van Halen",
                          Phone = "(412) 256-0990",
                          Budget = 25000.0
                      };

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Change originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    [Serializable]
    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Name:   " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone:  " + _phone);
            }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }

        // Stores (serializes) memento
        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");

            Memento memento = new Memento();
            return memento.Serialize(this);
        }

        // Restores (deserializes) memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");

            SalesProspect s = (SalesProspect)memento.Deserialize();
            this.Name = s.Name;
            this.Phone = s.Phone;
            this.Budget = s.Budget;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private MemoryStream _stream = new MemoryStream();
        private SoapFormatter _formatter = new SoapFormatter();

        public Memento Serialize(object o)
        {
            _formatter.Serialize(_stream, o);
            return this;
        }

        public object Deserialize()
        {
            _stream.Seek(0, SeekOrigin.Begin);
            object o = _formatter.Deserialize(_stream);
            _stream.Close();

            return o;
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class ProspectMemory
    {
        public Memento Memento { get; set; }
    }
}
