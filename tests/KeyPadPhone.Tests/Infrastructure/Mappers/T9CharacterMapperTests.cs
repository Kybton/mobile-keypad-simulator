using KeyPadPhone.Core.Infrastructure.Mappers;

namespace KeyPadPhone.Tests.Infrastructure.Mappers;

public class T9CharacterMapperTests
{
    [Theory]
    [InlineData('2', 0, 'A')]
    [InlineData('2', 1, 'B')]
    [InlineData('2', 2, 'C')]
    [InlineData('2', 3, 'A')] // Wraps around
    [InlineData('7', 3, 'S')] // 4-letter key
    [InlineData('0', 0, ' ')] // Space
    [InlineData('x', 0, null)] // Invalid key
    public void MapToCharacter_VariousInputs_ReturnsExpected(char key, int pressCount, char? expected)
    {
        var result = T9CharacterMapper.MapToCharacter(key, pressCount);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('2', true)]
    [InlineData('9', true)]
    [InlineData('0', true)]
    [InlineData('x', false)]
    [InlineData('#', false)]
    public void IsValidKey_VariousKeys_ReturnsExpected(char key, bool expected)
    {
        var result = T9CharacterMapper.IsValidKey(key);
        Assert.Equal(expected, result);
    }
}
