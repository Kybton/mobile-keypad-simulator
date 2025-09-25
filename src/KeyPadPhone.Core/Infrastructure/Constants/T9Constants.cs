namespace KeyPadPhone.Core.Infrastructure.Constants;

public static class T9Constants
{
    public static readonly IReadOnlyDictionary<char, string> KeyMapping = new Dictionary<char, string>
    {
        ['1'] = "('&",
        ['2'] = "ABC",
        ['3'] = "DEF",
        ['4'] = "GHI",
        ['5'] = "JKL",
        ['6'] = "MNO",
        ['7'] = "PQRS",
        ['8'] = "TUV",
        ['9'] = "WXYZ",
        ['0'] = " "
    }.AsReadOnly();
}