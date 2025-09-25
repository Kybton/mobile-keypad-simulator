using KeyPadPhone.Core.Entities;

namespace KeyPadPhone.Tests.Entities;

public class T9InputProcessorTests
{
    [Theory]
    [InlineData("*#", "")] // Backspace only
    [InlineData("2*#", "")] // Digit then backspace
    [InlineData("22*3#", "D")] // Backspace in middle
    [InlineData("2 3#", "AD")] // Pause character
    [InlineData("0#", " ")] // Space character
    [InlineData("2222#", "A")] // Cycling
    public void Process_SpecialCases_HandlesCorrectly(string input, string expected)
    {
        var result = T9InputProcessor.Process(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Process_InputWithoutSendCommand_ReturnsPartialResult()
    {
        var result = T9InputProcessor.Process("222");
        Assert.Equal("", result); // No # means no final character
    }
}
