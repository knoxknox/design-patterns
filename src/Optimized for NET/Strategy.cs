using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Strategy.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Strategy Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList()
              {
                new Student{ Name = "Samual", Ssn = "154-33-2009" },
                new Student{ Name = "Jimmy", Ssn = "487-43-1665" },
                new Student{ Name = "Sandra", Ssn = "655-00-2944" },
                new Student{ Name = "Vivek", Ssn = "133-98-8399" },
                new Student{ Name = "Anna", Ssn = "760-94-9844" },
              };

            studentRecords.SortStrategy = new QuickSort();
            studentRecords.SortStudents();

            studentRecords.SortStrategy = new ShellSort();
            studentRecords.SortStudents();

            studentRecords.SortStrategy = new MergeSort();
            studentRecords.SortStudents();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Strategy' interface
    /// </summary>
    interface ISortStrategy
    {
        void Sort(List<Student> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class QuickSort : ISortStrategy
    {
        public void Sort(List<Student> list)
        {
            // Call overloaded Sort
            Sort(list, 0, list.Count - 1);
            Console.WriteLine("QuickSorted list ");
        }

        // Recursively sort
        private void Sort(List<Student> list, int left, int right)
        {
            int lhold = left;
            int rhold = right;

            // Use a random pivot
            Random random = new Random();
            int pivot = random.Next(left, right);
            Swap(list, pivot, left);
            pivot = left;
            left++;

            while (right >= left)
            {
                int compareleft = list[left].Name.CompareTo(list[pivot].Name);
                int compareright = list[right].Name.CompareTo(list[pivot].Name);

                if ((compareleft >= 0) && (compareright < 0))
                {
                    Swap(list, left, right);
                }
                else
                {
                    if (compareleft >= 0)
                    {
                        right--;
                    }
                    else
                    {
                        if (compareright < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                            left++;
                        }
                    }
                }
            }
            Swap(list, pivot, right);
            pivot = right;

            if (pivot > lhold) Sort(list, lhold, pivot);
            if (rhold > pivot + 1) Sort(list, pivot + 1, rhold);
        }

        // Swap helper function
        private void Swap(List<Student> list, int left, int right)
        {
            Student temp = list[right];
            list[right] = list[left];
            list[left] = temp;
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ShellSort : ISortStrategy
    {
        public void Sort(List<Student> list)
        {
            // ShellSort();  not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class MergeSort : ISortStrategy
    {
        public void Sort(List<Student> list)
        {
            // MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class SortedList : List<Student>
    {
        // Sets sort strategy
        public ISortStrategy SortStrategy { get; set; }

        // Perform sort
        public void SortStudents()
        {
            SortStrategy.Sort(this);

            // Display sort results
            foreach (Student student in this)
            {
                Console.WriteLine(" " + student.Name);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Represents a student
    /// </summary>
    class Student
    {
        // Gets or sets student name
        public string Name { get; set; }

        // Gets or sets student social security number
        public string Ssn { get; set; }
    }
}
