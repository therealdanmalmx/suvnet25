namespace CRC;

class Program
{

    static void Main(string[] args)
    {
        Driver driver = new Driver("Gustav", "123456-7890");
        Console.WriteLine($"Förare skapad: {driver.Name}, Personnummer: {driver.PersonalNumber}");

        Vehicle vehicle = new Vehicle("ABC123", "Volvo", 0.7, FuelType.Diesel);
        Vehicle vehicle2 = new Vehicle("XYZ789", "Toyota", 0.5, FuelType.Gasoline);

        //Skapa några resor
        Journey journey1 = new Journey(new DateTime(2023, 1, 1, 6, 0, 0), new DateTime(2023, 1, 1, 7, 0, 0), 100, driver, vehicle);
        Journey journey2 = new Journey(new DateTime(2023, 1, 1, 8, 0, 0), new DateTime(2023, 1, 1, 10, 0, 0), 200, driver, vehicle2);

        // Registrera resorna i FleetManager
        FleetManager fleetManager = new FleetManager();
        fleetManager.RegisterJourney(journey1);
        fleetManager.RegisterJourney(journey2);

        // Generera rapporter för en viss förare som en sträng (Hur långt den kört totalt, total bränsleföbrukning, total kostnad)
        Console.WriteLine(fleetManager.GenerateReportForDriver(driver));

        // Mer avancerad, generera en rapport för ett visst fordon och ta emot det som ett VehicleReport objekt
        VehicleReport report = fleetManager.GenerateReportForVehicle(vehicle);
        Console.WriteLine($"Vehicle Report for {vehicle.Name} ({vehicle.RegistrationNumber}):");
        Console.WriteLine($"Total Distance: {report.TotalDistance} km");
        Console.WriteLine($"Total Fuel Consumption: {report.TotalFuelConsumption} liters");
        Console.WriteLine($"Total Cost: {report.TotalCost} SEK");

        // Generera en total rapport för alla fordon på samma sätt som ovan
        var totalReport = fleetManager.GenerateTotalReport();
        Console.WriteLine("Total Report for all vehicles:");
        Console.WriteLine($"Total Distance: {totalReport.TotalDistance} km");
        Console.WriteLine($"Total Fuel Consumption: {totalReport.TotalFuelConsumption} liters");
        Console.WriteLine($"Total Cost: {totalReport.TotalCost} SEK");
    }
}
enum FuelType
{
    Gasoline,
    Diesel,
}

class Driver
{
    public string Name { get; set; }
    public string PersonalNumber { get; set; }

    public Driver(string name, string personalNumber)
    {
        Name = name;
        PersonalNumber = personalNumber;
    }
}

class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Name { get; set; }
    public double Milage { get; set; }
    public FuelType FuelType { get; set; }

    public Vehicle(string registrationNumber, string name, double milage, FuelType fuelType)
    {
        RegistrationNumber = registrationNumber;
        Name = name;
        Milage = milage;
        FuelType = fuelType;
    }

    public double CalculateFulePrice(Vehicle vehicle)
    {
        double fuelPrice = 0.0;

        if (vehicle.FuelType == FuelType.Gasoline)
        {
            fuelPrice = 18.75;
        }

        if (vehicle.FuelType == FuelType.Diesel)
        {
            fuelPrice = 19.55;
        }

        return fuelPrice;
    }
}

class Journey
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Distance { get; set; }
    public Driver Driver { get; set; }
    public Vehicle Vehicle { get; set; }

    public Journey(DateTime startTime, DateTime endTime, int distance, Driver driver, Vehicle vehicle)
    {
        StartTime = startTime;
        EndTime = endTime;
        Distance = distance;
        Driver = driver;
        Vehicle = vehicle;
    }
}

class FleetManager
{
    public double TotalDistance { get; set; }
    public double TotalFuelConsumption { get; set; }
    public double TotalCost { get; set; }
    public double CummulatedTotalDistance { get; set; }
    public double CummulatedTotalFuelConsumption { get; set; }
    public double CummulatedTotalCost { get; set; }
    List<Journey> journeys = [];

    public List<Journey> RegisterJourney(Journey journey)
    {
        journeys.Add(journey);

        TotalCost += journey.Vehicle.CalculateFulePrice(journey.Vehicle) * journey.Distance * (journey.Vehicle.Milage / 10);
        TotalDistance += journey.Distance;
        TotalFuelConsumption += Math.Round(journey.Vehicle.Milage / 10 * journey.Distance, 2);

        return journeys;
    }

    public string GenerateReportForDriver(Driver driver)
    {
        return $"{driver.Name}: {TotalDistance}km, {TotalFuelConsumption} liter, {TotalCost}kr";
    }

    public VehicleReport GenerateReportForVehicle(Vehicle vehicle)
    {
        VehicleReport report = new();

        foreach (var journey in journeys)
        {
            if (journey.Vehicle.Name == vehicle.Name)
            {
                report.TotalCost += journey.Vehicle.CalculateFulePrice(journey.Vehicle) * journey.Distance * (journey.Vehicle.Milage / 10);
                report.TotalDistance += journey.Distance;
                report.TotalFuelConsumption += Math.Round(journey.Vehicle.Milage / 10 * journey.Distance, 2);
            }
        }

        return report;
    }

    public VehicleReport GenerateTotalReport()
    {
        VehicleReport report = new();

        foreach (var journey in journeys)
        {
            report.TotalCost += journey.Vehicle.CalculateFulePrice(journey.Vehicle) * journey.Distance * (journey.Vehicle.Milage / 10);
            report.TotalDistance += journey.Distance;
            report.TotalFuelConsumption += Math.Round(journey.Vehicle.Milage / 10 * journey.Distance, 2);
        }

        return report;
    }
}
class VehicleReport
{
    public double TotalDistance { get; set; }
    public double TotalFuelConsumption { get; set; }
    public double TotalCost { get; set; }
}