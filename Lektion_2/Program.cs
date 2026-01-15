// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();

        string greeting = "Hello";
        string greeting2 = "World!";
        Console.WriteLine($"{greeting} {greeting2}");

        Console.Write("Vad heter du? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hej {name}!");

        int num1 = 5;
        int num2 = 10;
        Console.WriteLine($"{num1} och {num2}");

        Console.Write("Hur gammal är du? ");
        string age = Console.ReadLine();
        int ageNumber = int.Parse(age);
        int div = 3;

        int ageDivide = ageNumber / div;
        Console.WriteLine(ageDivide);
        int daysOld = ageNumber * 365;

        Console.WriteLine($"Du är {daysOld} dagara gammal.");

        if (ageNumber < 18)
        {
            Console.WriteLine("Du får inte ta körkort än");
        }
        else if (ageNumber > 18)
        {
        }
        else if (ageNumber == 18)
        {
            Console.WriteLine("Du är exact 18 år gammal!");
        }
        else
        {
            Console.WriteLine("Du får ta körkort!");

        }

        float pi = 3.14f;

        Console.WriteLine(pi);

        Console.WriteLine(ageNumber / pi);

        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        Console.Write("Välj ett nummer: ");
        string number = Console.ReadLine();
        int numberInt = int.Parse(number);

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numberInt} * {i} = {numberInt * i}");
        }

        for (int i = 1; i <= 10; i++)
        {
            if (i >= 3 && i <= 7)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("Burr");
                }
                else if (i % 2 == 0)
                {
                    Console.WriteLine("Birr");
                }

                Console.WriteLine(i);
            }
        }

        string[] nameList = ["Anna", "Bertil", "Cecilia", "David", "Eva"];

         for (int i = 0; i < nameList.Length; i++)
         {
             Console.WriteLine(nameList[i]);
         }

        long longNumber = 21474836471;

        Console.WriteLine(longNumber);


        for (int i = 5; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        Console.Write("Välj ett nummer: ");
        string num = Console.ReadLine();
        int numConvert = int.Parse(num);

        for (int i = 0; i <= numConvert; i++)
        {
            for (int j = 0; j < numConvert - i; j++)
            {
                Console.Write(" ");
            }

            for (int u = 0; u < i; u++)
            {
                Console.Write("*");
            }

            Console.Write(" ");
            for (int y = 0; y < i; y++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}