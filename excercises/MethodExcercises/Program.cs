/*
Skriv en metod som:

returnerar en sträng
heter CreateGreeting
tar emot en parameter av typen string som heter name
returnerar en hälsning i form av en sträng, t.ex. "Hello, [name]!"

Skriv en metod som:

returnerar en double
heter CalculateArea
tar emot två parametrar av typen double som heter width och height
returnerar arean av rektangeln (width * height)

*/

namespace MethodExcercises;

class Program
{
    static void Main(string[] args)
    {
        // CreateGreeting("Daniel");

        // CalculateArea(4, 5);

        // ShowMessage();

        // string userName = GetUserName();

        // GreetUser(userName);

        // int age = GetUserAge();

        // int convertedAge = ConvertAgeToDays(age);
        // Console.WriteLine($"Du är {convertedAge} dagar gammal");

        ShowHeader(); // Ska visa programmets namn: "Word analyzer"

        string word1 = GetWordFromUser(); // Ska fråga användaren om ett ord och returnera det
        string word2 = GetWordFromUser();

        int length1 = GetLengthOfWord(word1); // Ska returnera längden på ordet
        int length2 = GetLengthOfWord(word2);

        Console.WriteLine($"The word {word1} has {length1} letters.");
        Console.WriteLine($"The word {word2} has {length2} letters.");

        string longerWord = GetLongerWord(word1, word2); // Ska returnera det längsta ordet
        Console.WriteLine($"The longer word is: {longerWord}");

        // Ska visa ett avslutningsmeddelande som ska visa texten "Hejdå! Du skrev in X antal bokstäver totalt."
        // ShowFooter(word1, word2);
    }

    static void ShowHeader()
    {
        Console.WriteLine("Word Analyzer"); ;
    }

    static string GetWordFromUser()
    {
        Console.Write("Skriv ett ord: ");
        string word = Console.ReadLine();

        return word;
    }

    static int GetLengthOfWord(string word)
    {
        int wordLength = word.Length;
        return wordLength;
    }
    public static string CreateGreeting(string name)
    {
        Console.WriteLine($"Hello {name}");
        return $"Hello {name}";
    }

    static string GetLongerWord(string word1, string word2)
    {
        int word1Length = word1.Length;
        int word2Length = word2.Length;
        int longestWord = Math.Max(word1Length, word2Length);

        if (longestWord > word2Length)
        {
            return word1;
        }
        else
        {
            return word2;
        }
    }

    public static double CalculateArea(double width, double height)
    {
        Console.WriteLine(width * height);
        return width * height;
    }

     static void ShowMessage()
    {
        Console.WriteLine("Välkommen till Metodövningar!\n---------------------");
    }

    static string GetUserName()
    {
        Console.Write("Ange ditt namn: ");
        return Console.ReadLine();
    }

    static void GreetUser(string name)
    {
        Console.WriteLine($"Hej, {name}! Hoppas det går bra med kodandet.");
    }

    static int GetUserAge()
    {
        Console.Write("Ange din ålder: ");
        return int.Parse(Console.ReadLine());
    }

    static int ConvertAgeToDays(int age)
    {
        return age * 365;
    }

}
