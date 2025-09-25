using KeyPadPhone.Core.Services;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Tests.Services;

public class ValidationServiceTests
{
    [Theory]
    [InlineData("123#", true)]
    [InlineData("222 2 22#", true)]
    [InlineData("*#", true)]
    [InlineData("", false)]
    [InlineData("abc", false)]
    [InlineData("123!", false)]
    public void IsValidInput_VariousInputs_ReturnsExpected(string input, bool expected)
    {
        var result = ValidationService.IsValidInput(input, PhoneType.T9Keypad);
        Assert.Equal(expected, result);
    }
}
