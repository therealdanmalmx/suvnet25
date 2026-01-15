namespace kort_projekt;

class Program
{
    static void Main(string[] args)
    {
        List<string> people = ["Bob", "Bill", "Kim"];

        Console.WriteLine(people[1]);

        foreach (string item in people)
        {
            Console.WriteLine(item);
        }

        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine(i);
        }
    }
}
