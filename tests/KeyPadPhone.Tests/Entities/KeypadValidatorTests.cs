using KeyPadPhone.Core.Entities;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Tests.Entities;

public class KeypadValidatorTests
{
    [Fact]
    public void CreateDefault_T9Keypad_ReturnsValidValidator()
    {
        var validator = KeypadValidator.CreateDefault(PhoneType.T9Keypad);
        Assert.NotNull(validator);
        Assert.Contains('2', validator.ValidCharacters);
        Assert.Contains('#', validator.ValidCharacters);
        Assert.Contains(' ', validator.ValidCharacters);
    }

    [Theory]
    [InlineData("123#", true)]
    [InlineData("abc", false)]
    [InlineData("123!", false)]
    [InlineData("", false)]
    public void IsValidInput_VariousInputs_ReturnsExpected(string input, bool expected)
    {
        var validator = KeypadValidator.CreateDefault(PhoneType.T9Keypad);
        var result = validator.IsValidInput(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CreateDefault_UnsupportedPhoneType_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            KeypadValidator.CreateDefault((PhoneType)999));
    }

    [Fact]
    public void IsValidInput_NullInput_ReturnsFalse()
    {
        var validator = KeypadValidator.CreateDefault(PhoneType.T9Keypad);
        var result = validator.IsValidInput(null!);
        Assert.False(result);
    }
}
