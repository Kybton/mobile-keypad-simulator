using KeyPadPhone.Core.Services;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Tests.Services;

public class KeypadServiceTests
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("222 2 22#", "CAB")]
    public void ProcessInput_ValidInputs_ReturnsExpectedOutput(string input, string expected)
    {
        var result = KeypadService.ProcessInput(input, PhoneType.T9Keypad);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ProcessInput_UnsupportedPhoneType_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            KeypadService.ProcessInput("123#", (PhoneType)999));
    }
}
