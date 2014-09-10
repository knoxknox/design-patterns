using System;

namespace DoFactory.GangOfFour.Abstract.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Abstract Factory Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world
            AnimalWorld world = new AnimalWorld(Continent.Africa);
            world.RunFoodChain();

            // Create and run the American animal world
            world = new AnimalWorld(Continent.America);
            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractFactory' interface. 
    /// </summary>
    interface IContinentFactory
    {
        IHerbivore CreateHerbivore();
        ICarnivore CreateCarnivore();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class.
    /// </summary>
    class AfricaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    class AmericaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface IHerbivore
    {
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface ICarnivore
    {
        void Eat(IHerbivore h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Wildebeest : IHerbivore
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Lion : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
                " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bison : IHerbivore
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Wolf : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
                " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' class
    /// </summary>
    class AnimalWorld
    {
        private IHerbivore _herbivore;
        private ICarnivore _carnivore;

        /// <summary>
        /// Contructor of Animalworld
        /// </summary>
        /// <param name="continent">Continent of the animal world that is created.</param>
        public AnimalWorld(Continent continent)
        {
            // Get fully qualified factory name
            string name = this.GetType().Namespace + "." +
                continent.ToString() + "Factory";

            // Dynamic factory creation
            IContinentFactory factory =
                (IContinentFactory)System.Activator.CreateInstance
                (Type.GetType(name));

            // Factory creates carnivores and herbivores
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        /// <summary>
        /// Runs the foodchain, that is, carnivores are eating herbivores.
        /// </summary>
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }

    /// <summary>
    /// Enumeration of continents.
    /// </summary>
    enum Continent
    {
        /// <summary>
        /// Represents continent of Africa.
        /// </summary>
        Africa,

        /// <summary>
        /// Represents continent of America.
        /// </summary>
        America,

        /// <summary>
        /// Represents continent of Asia.
        /// </summary>
        Asia,

        /// <summary>
        /// Represents continent of Europe.
        /// </summary>
        Europe,

        /// <summary>
        /// Represents continent of Australia.
        /// </summary>
        Australia
    }
}
