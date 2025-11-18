using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
namespace dogshow;

partial class Program
{
    static void Main(string[] args)
    {
        string conenctionString = File.ReadLines("connection.txt").First();
        IDbConnection dbConnection = new MySqlConnection(conenctionString);

        bool exitProgram = false;
        List<string> firstChoices = ["Lägg till", "Lista"];
        List<string> addChoices = ["Lägga till en hund", "Lägga till en utställning", "Lägg till en tävling", "Lägg till en ras", "Avbryt"];
        List<string> listChoices = ["Lista alla hundar", "Lista alla utställningar", "Lista lla tävlingar", "Lista alla raser", "Avbryt"];

        while (exitProgram == false)
        {
            Console.WriteLine();
            for (int i = 0; i < firstChoices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {firstChoices[i]}.");
            }
            Console.WriteLine();
            Console.WriteLine("Vad vill du göra: ");
            int menueChoice = int.Parse(Console.ReadLine());

            if (menueChoice == 1)
            {
                 Console.WriteLine();
                for (int i = 0; i < addChoices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {addChoices[i]}.");
                }
                Console.WriteLine();
                Console.WriteLine("Vad vill du göra: ");
                int addChoicesMenuChoice = int.Parse(Console.ReadLine());

                if (addChoicesMenuChoice == 1)
                {
                    Console.WriteLine("Vad heter hunden? ");
                    string dogName = Console.ReadLine();

                    IEnumerable<Breed> breeds = dbConnection.Query<Breed>("SELECT Name FROM Breed");
                    Console.WriteLine("Which breed? ");

                    int i = 0;
                    foreach (Breed breed in breeds)
                    {
                        Console.WriteLine($"{i} {breed.Name}");
                        i++;
                    }
                    Console.WriteLine("Vilken ras har den?");
                    int dogBreed = int.Parse(Console.ReadLine());

                    Dog newDog = new();
                    newDog.Name = dogName;
                    newDog.BreedId = dogBreed;

                    Console.WriteLine($"Din hund {newDog.Name} är en {newDog.BreedId}");
                }
            }
            else if (menueChoice == 2)
            {
                Console.WriteLine();
                for (int i = 0; i < listChoices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listChoices[i]}.");
                }
                Console.WriteLine();
                Console.WriteLine("Vad vill du göra: ");
                int addChoicesMenuChoice = int.Parse(Console.ReadLine());

                if (addChoicesMenuChoice == 1)
                {
                    var query = @"
                        SELECT
                            d.Name AS 'DogName',
                            b.Name AS 'BreedType',
                            e.Name AS 'ExhibitorName'
                        FROM Dog d
                        JOIN Breed b ON d.BreedId = b.Id
                        JOIN Exhibitor e ON d.ExhibitorId = e.Id";
                    IEnumerable<(string DogName, string BreedType, string ExhibitorName)> data = dbConnection.Query<(string DogName, string BreedType, string ExhibitorName)>(query);

                    // IEnumerable<Dog> dogs = dbConnection.Query<Dog>("SELECT Name, BreedId, ExhibitorId FROM Dog");

                    foreach (var d in data)
                    {
                        Console.WriteLine($"{d.DogName} is a {d.BreedType} and own by {d.ExhibitorName}.");
                    }
                }
                // else if (addChoicesMenuChoice == 2)
                // {

                // }
                // else if (addChoicesMenuChoice == 3)
                // {

                // }
                // else if (addChoicesMenuChoice == 4)
                // {

                // }
            }
            // else if (menueChoice == 2)
            // {
            //     Console.WriteLine();
            //     for (int i = 0; i < listChoices.Count; i++)
            //     {
            //         Console.WriteLine($"{i + 1}. {listChoices[i]}.");
            //     }
            //     Console.WriteLine();
            //     Console.WriteLine("Vad vill du göra: ");
            //     int listChoicesMenuChoice = int.Parse(Console.ReadLine());

            //     if (listChoicesMenuChoice == 1)
            //     {
            //         IEnumerable<Dog> dogs = dbConnection.Query<Dog>("SELECT Name, BreedId, ExhibitorId FROM Dog");

            //         foreach (Dog dog in dogs)
            //         {
            //             Console.WriteLine(dog);
            //         }
            //     }
            // }
            // else if (menueChoice == 3)
            // {
            //     Environment.Exit(0);
            // }

        }

        static void AddDog()
        {
            Console.WriteLine("Vad heter din hund?");
            string dogName = Console.ReadLine().Trim();

            Dog newDog = new();
            newDog.Name = dogName;
        }

        // static void ListAllDogs()
        // {
        //     IEnumerable<Dog> teachers = dbConnection.Query<Dog>("SELECT Id, Name, Email FROM Teacher").ToList();

        //     for (int i = 0; i < dogs.Count; i++)
        //     {
        //         Console.WriteLine($"{i + 1}. {dogs[i]}.");
        //     }
        // }
    }
}
