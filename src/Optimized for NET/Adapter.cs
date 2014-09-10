using System;

namespace DoFactory.GangOfFour.Adapter.NETOptimized
{
    /// <summary>
    /// MainApp startup class for the .NET optimized 
    /// Adapter Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Non-adapted chemical compound 
            Compound unknown = new Compound(Chemical.Unknown);
            unknown.Display();

            // Adapted chemical compounds
            Compound water = new RichCompound(Chemical.Water);
            water.Display();

            Compound benzene = new RichCompound(Chemical.Benzene);
            benzene.Display();

            Compound ethanol = new RichCompound(Chemical.Ethanol);
            ethanol.Display();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Target' class
    /// </summary>
    class Compound
    {
        // Constructor
        public Compound(Chemical chemical)
        {
            this.Chemical = chemical;
        }

        // Automatic properties
        public Chemical Chemical { get; set; }
        public float BoilingPoint { get; set; }
        public float MeltingPoint { get; set; }
        public double MolecularWeight { get; set; }
        public string MolecularFormula { get; set; }

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: {0} -- ", Chemical);
        }
    }

    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    class RichCompound : Compound
    {
        private ChemicalDatabank _bank;

        // Constructor
        public RichCompound(Chemical chemical) : base(chemical) {}

        public override void Display()
        {
            // The Adaptee
            _bank = new ChemicalDatabank();

            // Adaptee request methods
            BoilingPoint = _bank.GetCriticalPoint(Chemical, State.Boiling);
            MeltingPoint = _bank.GetCriticalPoint(Chemical, State.Melting);
            MolecularWeight = _bank.GetMolecularWeight(Chemical);
            MolecularFormula = _bank.GetMolecularStructure(Chemical);

            base.Display();
            Console.WriteLine(" Formula: {0}", MolecularFormula);
            Console.WriteLine(" Weight : {0}", MolecularWeight);
            Console.WriteLine(" Melting Pt: {0}", MeltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", BoilingPoint);
        }
    }

    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    class ChemicalDatabank
    {
        // The databank 'legacy API'
        public float GetCriticalPoint(Chemical compound, State point)
        {
            // Melting Point
            if (point == State.Melting)
            {
                switch (compound)
                {
                    case Chemical.Water: return 0.0f;
                    case Chemical.Benzene: return 5.5f;
                    case Chemical.Ethanol: return -114.1f;
                    default: return 0f;
                }
            }
            // Boiling Point
            else 
            {
                switch (compound)
                {
                    case Chemical.Water: return 100.0f;
                    case Chemical.Benzene: return 80.1f;
                    case Chemical.Ethanol: return 78.3f;
                    default: return 0f;
                }
            }
        }

        public string GetMolecularStructure(Chemical compound)
        {
            switch (compound)
            {
                case Chemical.Water: return "H20"; 
                case Chemical.Benzene: return "C6H6";
                case Chemical.Ethanol: return "C2H5OH";
                default: return "";
            }
        }

        public double GetMolecularWeight(Chemical compound)
        {
            switch (compound)
            {
                case Chemical.Water: return 18.015;
                case Chemical.Benzene: return 78.1134;
                case Chemical.Ethanol: return 46.0688;
            }
            return 0d;
        }
    }

    
    /// <summary>
    /// Chemical enumeration
    /// </summary>
    public enum Chemical
    {
        Unknown,
        Water,
        Benzene,
        Ethanol
    }

    /// <summary>
    /// State enumeration
    /// </summary>
    public enum State
    {
        Boiling,
        Melting
    }
}
