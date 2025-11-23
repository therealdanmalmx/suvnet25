namespace StringCalculator;

public class StringCalculator
{
    static void Main(string[] args)
    {
    }

    public static int Add(string numbers)
    {
        string[] numberList = numbers.Split(",").ToArray();
        Console.WriteLine(numberList.Length);

        int sum = 0;

        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        else if (numberList.Length == 1)
        {
            sum = int.Parse(numbers);
        }

        else if (numberList.Length == 2)
        {
            sum = int.Parse(numberList[0]) + int.Parse(numberList[1]);
        }

        else if (numberList.Length > 2)
        {
            foreach (string num in numberList)
            {
                sum += int.Parse(num);
            }
        }
        return sum;
    }
}