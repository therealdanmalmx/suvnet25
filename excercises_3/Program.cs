int number = 5;

Action<string> stringPrinter = SomeMethod;

void SomeMethod(string what)
{
    Console.WriteLine($"{what}");
}

// action delegat med sträng. Skall returnera strängen och heltalet ovan

for (int i = 0; i < number; i++)
{
    stringPrinter("nice: " + number);
}