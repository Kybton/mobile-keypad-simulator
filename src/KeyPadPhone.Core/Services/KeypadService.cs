using KeyPadPhone.Core.Entities;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Core.Services;

public static class KeypadService
{
    public static string ProcessInput(string input, PhoneType phoneType)
    {
        return phoneType switch
        {
            PhoneType.T9Keypad => T9InputProcessor.Process(input),
            _ => throw new ArgumentException($"Unsupported phone type: {phoneType}")
        };
    }
}