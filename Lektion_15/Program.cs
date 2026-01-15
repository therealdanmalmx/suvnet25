namespace Lektion_15;

class Program
{
    static void Main(string[] args)
    {
        List<Sensor> sensors = [];

        TemperatureSensor temSens = new("°C");
        HumiditySensor humSens = new("%");
        LightSensor lightSens = new("lux");

        sensors.Add(temSens);
        sensors.Add(humSens);
        sensors.Add(lightSens);

        foreach (Sensor item in sensors)
        {
            Console.WriteLine($"{item.ReadValue()}{item.Unit}");
        }
        // List<Animal> animals = [];

        // Dog dog = new("Robby");
        // Cat cat = new("Missy");

        // animals.Add(dog);
        // animals.Add(cat);

        // foreach (Animal item in animals)
        // {
        //     Console.WriteLine(item.MakeSound());
        // }
    }

    // public abstract class Animal
    // {
    //     public string Name { get; private set; }
    //     public abstract string MakeSound();

    //     public Animal(string name)
    //     {
    //         Name = name;
    //     }
    // }

    // class Dog : Animal
    // {
    //     public string Name { get; set; }

    //     public Dog(string name) : base(name)
    //     {
    //         Name = name;
    //     }
    //     public override string MakeSound()
    //     {
    //         return $"{Name} says Woof!";
    //     }
    // }
    // class Cat : Animal
    // {
    //     public string Name { get; set; }
    //     public Cat(string name) : base(name)
    //     {
    //         Name = name;
    //     }
    //     public override string MakeSound()
    //     {
    //         return $"{Name} says Meow!";
    //     }
    // }

    abstract class Sensor
    {
        public string Unit { get; private set; }

        public abstract double ReadValue();

        public Sensor(string unit)
        {
            Unit = unit;
        }
    }

    class TemperatureSensor : Sensor
    {
        public string Unit { get; private set; }
        public TemperatureSensor(string unit) : base(unit)
        {
            Unit = unit;
        }
        public override double ReadValue()
        {
            return Random.Shared.Next(-10, 50);
        }
    }

    class HumiditySensor : Sensor
    {
        public string Unit { get; private set; }
        public HumiditySensor(string unit) : base(unit)
        {
            Unit = unit;
        }
        public override double ReadValue()
        {
            double randomValue = Random.Shared.Next(0, 100);
            return randomValue;
        }
    }
    class LightSensor : Sensor
    {
        public string Unit { get; private set; }
        public LightSensor(string unit) : base(unit)
        {
            Unit = unit;
        }
        public override double ReadValue()
        {
            double randomValue = Random.Shared.Next(0, 1000);
            return randomValue;
        }
    }
}
