using System;
using System.Collections.Generic;
using System.Reflection;

namespace DoFactory.GangOfFour.Visitor.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Visitor Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Setup employee collection
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Visitor' abstract class
    /// </summary>
    public abstract class Visitor
    {
        // Use reflection to see if the Visitor has a method 
        // named Visit with the appropriate parameter type 
        // (i.e. a specific Employee). If so, invoke it.
        public void ReflectiveVisit(IElement element)
        {
            Type[] types = new Type[] { element.GetType() };
            MethodInfo mi = this.GetType().GetMethod("Visit", types);

            if (mi != null)
            {
                mi.Invoke(this, new object[] { element });
            }
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class IncomeVisitor : Visitor
    {
        // Visit clerk
        public void Visit(Clerk clerk)
        {
            DoVisit(clerk);
        }

        // Visit director
        public void Visit(Director director)
        {
            DoVisit(director);
        }

        private void DoVisit(IElement element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class VacationVisitor : Visitor
    {
        // Visit director
        public void Visit(Director director)
        {
            DoVisit(director);
        }

        private void DoVisit(IElement element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name,
                employee.VacationDays);
        }
    }

    /// <summary>
    /// The 'Element' interface
    /// </summary>
    public interface IElement
    {
        void Accept(Visitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    class Employee : IElement
    {
        // Constructor
        public Employee(string name, double income,
            int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }

        // Gets or sets name
        public string Name { get; set; }

        // Gets or set income
        public double Income { get; set; }

        // Gets or sets vacation days
        public int VacationDays { get; set; }

        public virtual void Accept(Visitor visitor)
        {
            visitor.ReflectiveVisit(this);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    class Employees : List<Employee>
    {
        public void Attach(Employee employee)
        {
            Add(employee);
        }

        public void Detach(Employee employee)
        {
            Remove(employee);
        }

        public void Accept(Visitor visitor)
        {
            // Iterate over all employees and accept visitor
            this.ForEach(employee => employee.Accept(visitor));
            
            Console.WriteLine();
        }
    }

    // Three employee types

    class Clerk : Employee
    {
        // Constructor
        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        // Constructor
        public Director()
            : base("Elly", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        // Constructor
        public President()
            : base("Dick", 45000.0, 21)
        {
        }
    }
}
