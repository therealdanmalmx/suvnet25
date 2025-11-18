using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace PasswordValidator.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("dan_1.2*34567")]
    public void ValidatorWithString(string input)
    {
        // Arrange

        // Act
        bool actual = PasswordValidator.Validate(input);

        //Assert
        Assert.True(actual);
    }
}
