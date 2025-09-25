namespace KeyPadPhone.Core.Entities;

public class InputState(char character = default, int pressCount = -1)
{
    public char CurrentCharacter { get; private set; } = character;
    public int PressCount { get; private set; } = pressCount;
    public bool IsEmpty => CurrentCharacter == default && PressCount < 0;

    public void IncrementPress()
    {
        PressCount++;
    }

    public void Reset()
    {
        CurrentCharacter = default;
        PressCount = -1;
    }

    public void WithCharacter(char character)
    {
        CurrentCharacter = character;
        PressCount = 0;
    }
}