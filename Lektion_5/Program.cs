// See https://aka.ms/new-console-template for more information
using System.Globalization;

string[] menuList = ["Visa dagens datum och tid", "Lista alla namn", "q = avsluta"];
bool quitMenue = false;

while (quitMenue == false)
{
    ShowMenu();
    GetInput();

    void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine();
        for (int i = 0; i < menuList.Length; i++)
        {
            PrintOnlyExistingStrings($"{i + 1} {menuList[i]}");
        }
    }

    string[] PrintLinesFromFile(string file)
    {
        ShowMenu();
        string[] inputString = file.Split("/");

        if (inputString[inputString.Length - 1] == "input04.txt")
        {
            inputString = File.ReadAllLines(inputString[inputString.Length - 1]);
            return inputString;
        }
        else
        {
            inputString = [];
            return inputString;
        }
    }
    GetInput();

    void PrintOnlyExistingStrings(string input)
    {
        if (input.Length <= 4)
        {
            Console.Write(input);
        }

        if (input.Length > 4)
        {
            Console.WriteLine(input);
        }
    }
    GetInput();

    void PrintDateInBlue()
    {
        ShowMenu();
        string todaysDate = DateTime.Now.ToString("d MMMM", new CultureInfo("sv-SE"));
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Dagens datum: {todaysDate}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    string GetInput()
    {
        PrintOnlyExistingStrings("Val: ");
        ConsoleKeyInfo choice = Console.ReadKey();

        if (choice.KeyChar == '1')
        {
            PrintDateInBlue();
        }

        if (choice.KeyChar == '2')
        {
            ShowMenu();
            string[] fileList = PrintLinesFromFile("https://klassrum.suvnet.se/lektioner/intro/v.%202%20forts/lektion05/input04.txt");

            foreach (string item in fileList)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                PrintOnlyExistingStrings(item);
            }
        }

        if (choice.KeyChar == 'q')
        {
            Console.WriteLine("Hej då!");
            Environment.Exit(0);
        }

        if (choice.KeyChar != '1' || choice.KeyChar != '2' || choice.KeyChar != 'q')
        {
            Console.WriteLine("Fel val");
        }


        return choice.KeyChar.ToString();
    }
}