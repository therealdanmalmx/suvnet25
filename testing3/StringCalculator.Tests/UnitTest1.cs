namespace StringCalculator.Tests;

public class UnitTest1
{
    [Fact]
    public void StringCalculatorNumber()
    {
        //Arrange
        string expect = "30";

        //Act
        string actual = StringCalculator.Add("10,20").ToString();

        //Assert

        Assert.Equal(expect, actual);

    }
}
