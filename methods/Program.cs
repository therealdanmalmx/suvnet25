namespace methods;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = [5, 9, 6, 3];
        Console.WriteLine(Sum(numbers));
        Console.WriteLine(Avg(numbers));
    }

    static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }

        return sum;
    }

    static double Avg(List<int> numbers)
    {
        double sum = Sum(numbers);
        double avg = sum / numbers.Count;

        return avg;
    }
}
