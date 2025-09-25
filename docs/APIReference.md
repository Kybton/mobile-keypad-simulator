# KeyPadPhone API Reference

## Core API

### KeyPadPhoneApi Class

**Namespace**: `KeyPadPhone.Core`

The main public API for the KeyPadPhone library. This class provides a clean interface for the application layer without direct dependency on the domain layer.

#### `OldPhonePad(string, PhoneType)`

Main entry point for T9 keypad functionality.

```csharp
public static string OldPhonePad(string inputString, PhoneType phoneType = PhoneType.T9Keypad)
```

**Parameters**:

- `inputString` - The keypad input string (digits, \*, #, space)
- `phoneType` - Phone type (default: T9Keypad)

**Returns**: Converted text string, or empty string if invalid

**Examples**:

```csharp
KeyPadPhoneApi.OldPhonePad("222#");           // "C"
KeyPadPhoneApi.OldPhonePad("4433555 555666#"); // "HELLO"
KeyPadPhoneApi.OldPhonePad("abc");            // "" (invalid)
```

---

### Phone Class (Internal)

**Namespace**: `KeyPadPhone.Core.Entities`

Internal domain entity that handles the core T9 keypad processing logic.

#### `OldPhonePad(string, PhoneType)`

Internal implementation of T9 keypad functionality.

```csharp
public static string OldPhonePad(string inputString, PhoneType phoneType)
```

**Parameters**:

- `inputString` - The keypad input string
- `phoneType` - Phone type

**Returns**: Converted text string, or empty string if invalid

**Note**: This class is used internally by `KeyPadPhoneApi`. Application code should use `KeyPadPhoneApi.OldPhonePad()` instead.

---

## Services

### ValidationService

**Namespace**: `KeyPadPhone.Core.Services`

#### `IsValidInput(string, PhoneType)`

Validates input characters.

```csharp
public static bool IsValidInput(string input, PhoneType phoneType)
```

**Valid characters for T9**: `0-9`, `*`, `#`, space

**Example**:

```csharp
ValidationService.IsValidInput("222#", PhoneType.T9Keypad); // true
ValidationService.IsValidInput("abc", PhoneType.T9Keypad);  // false
```

### KeypadService

**Namespace**: `KeyPadPhone.Core.Services`

#### `ProcessInput(string, PhoneType)`

Processes validated input according to phone type strategy.

```csharp
public static string ProcessInput(string input, PhoneType phoneType)
```

**Throws**: `ArgumentException` for unsupported phone types

---

## Infrastructure

### T9CharacterMapper

**Namespace**: `KeyPadPhone.Core.Infrastructure.Mappers`

#### `MapToCharacter(char, int)`

Maps key press to character.

```csharp
public static char? MapToCharacter(char key, int pressCount)
```

**Examples**:

```csharp
T9CharacterMapper.MapToCharacter('2', 0); // 'A'
T9CharacterMapper.MapToCharacter('2', 1); // 'B'
T9CharacterMapper.MapToCharacter('2', 3); // 'A' (cycles)
```

#### `IsValidKey(char)`

Checks if character is a valid T9 key.

```csharp
public static bool IsValidKey(char key)
```

---

## Constants

### T9Constants

**Namespace**: `KeyPadPhone.Core.Infrastructure.Constants`

#### Key Mappings

```csharp
['1'] = "('&"    ['6'] = "MNO"
['2'] = "ABC"    ['7'] = "PQRS"
['3'] = "DEF"    ['8'] = "TUV"
['4'] = "GHI"    ['9'] = "WXYZ"
['5'] = "JKL"    ['0'] = " "
```

### SpecialCharacters

**Namespace**: `KeyPadPhone.Core.Infrastructure.Constants`

```csharp
Send = '#'        // Finalizes input
Pause = ' '       // Commits current character
Backspace = '*'   // Clears current character
```

---

## Entities

### InputState

**Namespace**: `KeyPadPhone.Core.Entities`

Manages current input state during processing.

**Properties**:

- `CurrentCharacter` - Current character being processed
- `PressCount` - Number of presses for current character
- `IsEmpty` - Whether state is empty

**Methods**:

- `IncrementPress()` - Increment press count
- `Reset()` - Reset to empty state
- `WithCharacter(char)` - Set new character

### KeypadValidator

**Namespace**: `KeyPadPhone.Core.Entities`

Validates input against allowed character sets.

#### `CreateDefault(PhoneType)`

Creates validator for phone type.

```csharp
public static KeypadValidator CreateDefault(PhoneType phoneType)
```

#### `IsValidInput(string)`

Validates all characters in input.

```csharp
public bool IsValidInput(string input)
```

---

## Enums

### PhoneType

**Namespace**: `KeyPadPhone.Core.Infrastructure.Constants`

```csharp
public enum PhoneType
{
    T9Keypad
}
```

---

## Error Handling

### Return Values

- **Empty string**: Invalid input to `Phone.OldPhonePad()`
- **null**: Invalid key to `T9CharacterMapper.MapToCharacter()`
- **false**: Invalid input to validation methods

### Exceptions

- **ArgumentException**: Unsupported phone type in services

### Best Practices

```csharp
// Use the public API
string result = KeyPadPhoneApi.OldPhonePad(input, PhoneType.T9Keypad);
if (!string.IsNullOrEmpty(result))
{
    // Process result
}

// The API handles validation internally
string result = KeyPadPhoneApi.OldPhonePad("4433555 555666#");
Console.WriteLine(result); // "HELLO"

// Invalid input returns empty string
string invalid = KeyPadPhoneApi.OldPhonePad("abc");
Console.WriteLine(invalid); // "" (empty)
```

---

## Performance

| Operation                            | Time | Space | Notes             |
| ------------------------------------ | ---- | ----- | ----------------- |
| `KeyPadPhoneApi.OldPhonePad()`       | O(n) | O(n)  | n = input length  |
| `Phone.OldPhonePad()` (internal)     | O(n) | O(n)  | n = input length  |
| `ValidationService.IsValidInput()`   | O(n) | O(1)  | n = input length  |
| `T9CharacterMapper.MapToCharacter()` | O(1) | O(1)  | Dictionary lookup |

**Thread Safety**: All static methods are thread-safe. `InputState` is not thread-safe.
