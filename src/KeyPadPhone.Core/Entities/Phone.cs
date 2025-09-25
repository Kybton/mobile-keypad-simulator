using KeyPadPhone.Core.Infrastructure.Constants;
using KeyPadPhone.Core.Services;

namespace KeyPadPhone.Core.Entities;

public static class Phone
{
    public static string OldPhonePad(string inputString, PhoneType phoneType)
    {
        if (!ValidationService.IsValidInput(inputString, phoneType))
            return string.Empty;

        return KeypadService.ProcessInput(inputString, phoneType);
    }
}
