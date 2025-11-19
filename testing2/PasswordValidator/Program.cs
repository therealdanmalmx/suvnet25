using System.Runtime.InteropServices;

namespace PasswordValidator;

public class PasswordValidator
{
    static void Main(string[] args)
    {
    }

    public static bool Validate(string input)
    {
        Console.WriteLine(ValidateLength(input));
        Console.WriteLine(ValidateSpecialCharacter(input));
        Console.WriteLine(ValidateHasNumber(input));

        if (!ValidateLength(input))
        {
            return false;
        }

        else if (!ValidateHasNumber(input))
        {
            return false;
        }

        else if (!ValidateSpecialCharacter(input))
        {
            return false;
        }

        return true;
    }
    public static bool ValidateSpecialCharacter(string input)
    {
        char[] validators = ['!', '#', '&', '/', '(', ')', '?', '[', ']'];

        bool hasSpecialCharacter = false;

        foreach (char character in validators)
        {
            bool chekValue = !input.Contains(character) ? false : true;

            if (chekValue == true)
            {
                hasSpecialCharacter = true;
            }
        }

        return hasSpecialCharacter;
    }
    public static bool ValidateHasNumber(string input)
    {
        bool containsNumber = false;

        foreach(char numb in input)
        {
            bool checkNumber = char.IsNumber(numb) ? true : false;

            if (checkNumber == true)
            {
                containsNumber = true;
            }
        }

        return containsNumber;
    }
    public static bool ValidateLength(string input)
    {
        bool correctLength = input.Length >= 8 ? true : false;

        return correctLength;
    }
}
