// See https://aka.ms/new-console-template for more information

// 1. Parsningsmetod
// Skriv en metod som heter GetIntFromUser som:

// Tar en sträng som parameter (den ska användas som prompt när användaren ska mata in ett tal).
// Returnerar ett heltal som användaren matat in.
// (Svårare) Om användaren matar in något som inte är ett heltal, ska metoden skriva ut ett felmeddelande och fråga igen tills användaren matar in ett giltigt heltal.

// 2. GetEmailFromUser
// Skriv en metod som heter GetEmailFromUser som:

// Tar en sträng som parameter (den ska användas som prompt när användaren ska mata in en e-postadress).
// Returnerar en sträng som användaren matat in.
// (Svårare) Om användaren matar in något som inte är en giltig e-postadress (dvs. den innehåller inte ett @-tecken), ska metoden skriva ut ett felmeddelande och fråga igen tills användaren matar in en giltig e-postadress.

Console.Clear();

void PrintHello()
{
    Console.WriteLine("Hello World!");
}

void WriteMessage(string name)
{
    Console.WriteLine($"Hej {name}, hur mår du idag?");
}

void CalculateTax(decimal amount)
{
    decimal fraction = amount * 1.30m;
    Console.WriteLine($"{fraction}");
}

void WriteWarning(string message)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(message);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}

void MultipleMessages()
{
    Console.WriteLine("Detta är ett vanligt meddelande");
    WriteWarning("Detta är ett varningsmeddelande");
    Console.WriteLine("Detta är ett annat vanligt meddelande");
}

void GetIntFromUser(string inputNumber)
{
    bool correctType = false;
    while (correctType == false)
    {
        Console.Write($"{inputNumber}: ");
        string number = Console.ReadLine();

        if (int.TryParse(number, out int fedNumber))
        {
            Console.WriteLine($"Du valde: {fedNumber}");
            correctType = true;
        }
        else
        {
            Console.WriteLine("Måste vara ett heltal");
        }
    }
}

void GetEmailFromUser(string email)
{
    bool correctEmailFormat = false;

    while (correctEmailFormat == false)
    {
        Console.Write($"{email}: ");
        email = Console.ReadLine();

        if (!email.Contains("@") || !email.Contains("."))
        {
            Console.WriteLine("Fel format");
        }
        else
        {
            Console.WriteLine($"Din email är: {email}");
            correctEmailFormat = true;
        }
    }
}
PrintHello();
WriteMessage("Daniel");
CalculateTax(5000);
WriteWarning("Detta är ett vanligt meddelande");
MultipleMessages();
GetIntFromUser("Välj ett nummer");
GetEmailFromUser("Vad är din email?");