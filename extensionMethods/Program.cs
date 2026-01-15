using System.Security.Cryptography.X509Certificates;

public static class Program
{
    private static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        List<double> decimals = new List<double> { 1, 2, 3, 4, 5, 6 };

        List<int> evenList = numbers.FilterList(s => s % 2 == 0);
        List<double> squaredList = numbers.SquaredNumber(s => Math.Pow(s, 2));
        IEnumerable<double> decimalList = decimals.DoubleNumbers(n => n * 2);

        // evenList.ForEach(n => Console.WriteLine(n));
        // Console.WriteLine("--------");
        // squaredList.ForEach(n => Console.WriteLine(n));

        foreach (var item in decimalList)
        {
            Console.WriteLine(item);
        }

    }

    public static List<int> FilterList(this List<int> numbers, Func<int, bool> predicate)
    {
        List<int> evenNumbers = [];
        foreach (var n in numbers)
        {
            if (predicate(n))
            {
                evenNumbers.Add(n);
            }
        }
        return evenNumbers;
    }
    public static List<double> SquaredNumber(this List<int> numbers, Func<int, double> predicate)
    {
        List<double> squaredNumber = [];

        foreach (var n in numbers)
        {
            squaredNumber.Add(predicate(n));
        }

        return squaredNumber;

    }
    public static IEnumerable<T> DoubleNumbers<T>(this IEnumerable<T> numbers, Func<T, T> predicate)
    {
        List<T> doubleNumbers = [];

        foreach (var n in numbers)
        {
            doubleNumbers.Add(predicate(n));
        }

        return doubleNumbers;

    }
}