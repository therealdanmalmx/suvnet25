namespace PasswordValidator;

public class PasswordValidator
{
    static void Main(string[] args)
    {
    }
    public static bool Validate(string input)
    {
        bool correctLength = input.Length >= 8 ? true : false;
        Console.WriteLine("correctLength" + correctLength);

        bool chekValue = false;
        char[] validators = ['!'];

        foreach(char v in validators)
        {
            chekValue = !input.Contains(v) ? false : true;
        }

        bool hasNumbers = false;
        foreach(char numb in input)
        {
            if (char.IsNumber(numb))
            {
                hasNumbers = true;
            }
            else
            {
                hasNumbers = false;
            }
        }

        return chekValue && correctLength && hasNumbers;
    }
}
