using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Core.Entities;

public class KeypadValidator(ISet<char> validCharacters)
{
    public IReadOnlySet<char> ValidCharacters { get; private set; } = validCharacters.ToHashSet();

    public static KeypadValidator CreateDefault(PhoneType phoneType)
    {
        return phoneType switch
        {
            PhoneType.T9Keypad => new KeypadValidator(
                validCharacters: new HashSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '*', '#', ' ' }
            ),
            _ => throw new ArgumentException($"Unsupported phone type: {phoneType}")
        };
    }

    public bool IsValidInput(string input)
    {
        return !string.IsNullOrEmpty(input) &&
                input.All(c => ValidCharacters.Contains(c));
    }
}
