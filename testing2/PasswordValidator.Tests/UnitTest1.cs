using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace PasswordValidator.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("dan/123malmgreen")]

    public void ValidateAll(string input)
    {
        bool actual = PasswordValidator.Validate(input);

        //Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("dan!123malmgreen")]
    public void ValidatorNumbers(string input)
    {
        bool actual = PasswordValidator.ValidateHasNumber(input);

        Assert.True(actual);
    }

    [Theory]
    [InlineData("dan!")]
    public void ValidatorHasCharacter(string input)
    {
        // Act
        bool actual = PasswordValidator.ValidateSpecialCharacter(input);

        //Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("danmalmthemalm")]
    public void ValidatorLength(string input)
    {
        // Act
        bool actual = PasswordValidator.ValidateLength(input);

        //Assert
        Assert.True(actual);
    }
}
