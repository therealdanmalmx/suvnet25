/*

Skapa en klass som:

heter Car
har följande egenskaper (properties):
Make (string)
Model (string)
Year (int)
har en metod GetCarInfo som returnerar en sträng med bilens information i formatet "Year Make Model"

*/

namespace classesAndObjects;

class Program
{
    static void Main(string[] args)
    {
        Car newCar = new(1991, "BMW", "i3");

        Console.WriteLine($"{newCar.Year} {newCar.Make} {newCar.Model}");
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public string GetCarInfo()
        {
            return $"{Year} {Make} {Model}";
        }

        public Car(int year, string make, string model)
        {
            Year = year;
            Model = model;
            Make = make;
        }
    }
}
