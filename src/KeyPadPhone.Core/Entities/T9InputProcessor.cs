using System.Text;
using KeyPadPhone.Core.Infrastructure.Constants;
using KeyPadPhone.Core.Infrastructure.Mappers;

namespace KeyPadPhone.Core.Entities;

public static class T9InputProcessor
{
    public static string Process(string input)
    {
        StringBuilder result = new();
        InputState currentState = new();

        foreach (char c in input)
        {
            switch (c)
            {
                case SpecialCharacters.Send:
                    return ProcessSendCommand(result, currentState).ToString();

                case SpecialCharacters.Pause:
                    result = ProcessPauseCommand(result, currentState);
                    break;

                case SpecialCharacters.Backspace:
                    ProcessBackspaceCommand(currentState);
                    break;

                default:
                    result = ProcessDigitInput(result, currentState, c);
                    break;
            }
        }

        return result.ToString();
    }

    private static StringBuilder ProcessSendCommand(StringBuilder result, InputState currentState)
    {
        if (!currentState.IsEmpty)
        {
            var character = T9CharacterMapper.MapToCharacter(currentState.CurrentCharacter, currentState.PressCount);
            if (character.HasValue)
                result.Append(character.Value);
        }
        return result;
    }

    private static StringBuilder ProcessPauseCommand(
        StringBuilder result, InputState currentState)
    {
        if (!currentState.IsEmpty)
        {
            var character = T9CharacterMapper.MapToCharacter(currentState.CurrentCharacter, currentState.PressCount);
            if (character.HasValue)
                result.Append(character.Value);

            currentState.Reset();
            return result;
        }
        return result;
    }

    private static void ProcessBackspaceCommand(InputState currentState)
    {
        if (char.IsDigit(currentState.CurrentCharacter))
        {
            currentState.Reset();
        }
    }

    private static StringBuilder ProcessDigitInput(
        StringBuilder result, InputState currentState, char newChar)
    {
        if (newChar.Equals(currentState.CurrentCharacter))
        {
            currentState.IncrementPress();
            return result;
        }

        if (!currentState.IsEmpty)
        {
            var character = T9CharacterMapper.MapToCharacter(currentState.CurrentCharacter, currentState.PressCount);
            if (character.HasValue)
                result.Append(character.Value);
        }

        currentState.WithCharacter(newChar);
        return result;
    }
}