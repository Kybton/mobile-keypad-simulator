using KeyPadPhone.Core;

namespace KeyPadPhone.Tests
{
    public class PhoneTests
    {
        [Theory]
        [InlineData("33#", "E")]
        // Input with Backspace Test
        [InlineData("227*#", "B")]
        // Input with Pause Character Test
        [InlineData("222 2 22#", "CAB")]
        [InlineData("8#4#", "T")]
        // Testing Input Loop
        [InlineData("99999 44444 2222 8888#", "WHAT")]

        // Empty string test
        [InlineData("", "")]
        // Invalid character test
        [InlineData("abc", "")]
        // Invalid character test with !
        [InlineData("123!", "")]
        public void OldPhonePad_ValidInputs_ReturnsExpectedOutput(
            string input, string expected)
        {
            var result = KeyPadPhoneApi.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}
