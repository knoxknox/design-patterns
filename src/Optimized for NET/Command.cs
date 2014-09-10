using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Command.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Command Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create user and let her compute
            User user = new User();

            // Issue several compute commands
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Command' interface
    /// </summary>
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class CalculatorCommand : ICommand
    {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        // Constructor
        public CalculatorCommand(Calculator calculator,
            char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = @operator;
            this._operand = operand;
        }

        // Sets operator
        public char Operator
        {
            set { _operator = value; }
        }

        // Sets operand
        public int Operand
        {
            set { _operand = value; }
        }

        // Execute command
        public void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }

        // Unexecute command
        public void UnExecute()
        {
            _calculator.Operation(Undo(_operator), _operand);
        }

        // Return opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new
                  ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    class Calculator
    {
        private int _current = 0;

        // Perform operation for given operator and operand
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _current += operand; break;
                case '-': _current -= operand; break;
                case '*': _current *= operand; break;
                case '/': _current /= operand; break;
            }
            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                _current, @operator, operand);
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class User
    {
        private Calculator _calculator = new Calculator();
        private List<ICommand> _commands = new List<ICommand>();
        private int _current = 0;

        // Redo original commands
        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (_current < _commands.Count - 1)
                {
                    _commands[_current++].Execute();
                }
            }
        }

        // Undo prior commands
        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    _commands[--_current].UnExecute();
                }
            }
        }

        // Compute new value given operator and operand
        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            ICommand command = new CalculatorCommand(
                                 _calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            _commands.Add(command);
            _current++;
        }
    }
}
