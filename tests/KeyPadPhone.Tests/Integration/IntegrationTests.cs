using KeyPadPhone.Core;
using KeyPadPhone.Core.Services;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Tests.Integration;

public class IntegrationTests
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("222 2 22#", "CAB")]
    [InlineData("99999 44444 2222 8888#", "WHAT")]
    public void FullWorkflow_EndToEnd_ProducesCorrectResult(string input, string expected)
    {
        var result = KeyPadPhoneApi.OldPhonePad(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123!")]
    public void FullWorkflow_InvalidInput_ReturnsEmptyString(string input)
    {
        var result = KeyPadPhoneApi.OldPhonePad(input);
        Assert.Equal(string.Empty, result);
    }
}
