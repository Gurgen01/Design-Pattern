using System;
using System.Collections.Generic;

namespace Design_Pattern
{
    public interface IAirConditioner
    {
        void Operate();
    }
    public class CoolingManager : IAirConditioner
    {
        private readonly double _temperature;
        public CoolingManager(double temperature)
        {
            _temperature = temperature;

        }
        public void Operate()
        {
            Console.WriteLine($"Cooling the room to the required temperature of {_temperature} degrees.");
        }
    }
    public class WarmingManager:IAirConditioner
    {
        private readonly double _temperature;
        public WarmingManager(double temperature)
        {
            _temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Warming the room to the required temperature of {_temperature} degrees.");
        }
    }
    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }

public class CoolingFactory:AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new CoolingManager(temperature);
        
    }
    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new WarmingManager(temperature);
    }
    public enum Actions
    {
        Cooling,
        Warming
    }
    public class AirConditioner
    { private readonly Dictionary<Actions, AirConditionerFactory> _factories;
            public AirConditioner()
        {
            _factories = new Dictionary<Actions, AirConditionerFactory>
            { {Actions.Cooling,new CoolingFactory()},
                {Actions.Warming,new WarmingFactory() }
            };

        }
        public IAirConditioner ExecuteCreation(Actions action, double temperature) => _factories[action].Create(temperature);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new AirConditioner().ExecuteCreation(Actions.Cooling, 22.5);
            factory.Operate();
        }
    }
}
