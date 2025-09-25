using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Core.Infrastructure.Mappers;

public static class T9CharacterMapper
{
    public static char? MapToCharacter(char key, int pressCount)
    {
        if (T9Constants.KeyMapping.TryGetValue(key, out string? value))
        {
            int index = pressCount % value.Length;
            return value[index];
        }
        return null;
    }

    public static bool IsValidKey(char key) => T9Constants.KeyMapping.ContainsKey(key);
}