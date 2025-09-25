using KeyPadPhone.Core.Entities;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Core.Services;

public static class ValidationService
{
    public static bool IsValidInput(string input, PhoneType phoneType)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        if (!input.Contains(SpecialCharacters.Send))
            return false;

        var validator = KeypadValidator.CreateDefault(phoneType);
        return validator.IsValidInput(input);
    }
}