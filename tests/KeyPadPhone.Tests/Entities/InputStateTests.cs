using KeyPadPhone.Core.Entities;

namespace KeyPadPhone.Tests.Entities;

public class InputStateTests
{
    [Fact]
    public void InputState_DefaultConstructor_IsEmpty()
    {
        var state = new InputState();
        Assert.True(state.IsEmpty);
        Assert.Equal(default, state.CurrentCharacter);
        Assert.Equal(-1, state.PressCount);
    }

    [Fact]
    public void InputState_WithParameters_SetsValues()
    {
        var state = new InputState('2', 0);
        Assert.False(state.IsEmpty);
        Assert.Equal('2', state.CurrentCharacter);
        Assert.Equal(0, state.PressCount);
    }

    [Fact]
    public void IncrementPress_IncreasesCount()
    {
        var state = new InputState('2', 0);
        state.IncrementPress();
        Assert.Equal(1, state.PressCount);
    }

    [Fact]
    public void Reset_ClearsState()
    {
        var state = new InputState('2', 5);
        state.Reset();
        Assert.True(state.IsEmpty);
    }

    [Fact]
    public void WithCharacter_SetsCharacterAndResetsCount()
    {
        var state = new InputState();
        state.WithCharacter('3');
        Assert.Equal('3', state.CurrentCharacter);
        Assert.Equal(0, state.PressCount);
    }
}
