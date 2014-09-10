using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Builder.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            VehicleBuilder builder;

            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Create builders and display vehicle
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        // Constructor
        public VehicleBuilder(VehicleType vehicleType)
        {
            vehicle = new Vehicle(vehicleType);
        }

        // Property
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public MotorCycleBuilder()
            : base(VehicleType.MotorCycle)
        {
        }

        public override void BuildFrame()
        {
            vehicle[PartType.Frame] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle[PartType.Engine] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public CarBuilder()
            : base(VehicleType.Car)
        {
        }

        public override void BuildFrame()
        {
            vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle[PartType.Engine] = "2500 cc";
        }

        public override void BuildWheels()
        {
            vehicle[PartType.Wheel] = "4";
        }

        public override void BuildDoors()
        {
            vehicle[PartType.Door] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public ScooterBuilder()
            : base(VehicleType.Scooter)
        {
        }

        public override void BuildFrame()
        {
            vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            vehicle[PartType.Engine] = "50 cc";
        }

        public override void BuildWheels()
        {
            vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private VehicleType _vehicleType;

        private Dictionary<PartType, string> _parts =
          new Dictionary<PartType, string>();

        // Constructor
        public Vehicle(VehicleType vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer 
        public string this[PartType key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame  : {0}",
                this[PartType.Frame]);
            Console.WriteLine(" Engine : {0}",
                this[PartType.Engine]);
            Console.WriteLine(" #Wheels: {0}",
                this[PartType.Wheel]);
            Console.WriteLine(" #Doors : {0}",
                this[PartType.Door]);
        }
    }

    /// <summary>
    /// Part type enumeration
    /// </summary>
    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    /// <summary>
    /// Vehicle type enumeration
    /// </summary>
    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }
}

