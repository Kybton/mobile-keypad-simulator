# KeyPadPhone - T9 Keypad Text Input System

A clean, efficient C# implementation of the classic T9 (Text on 9 keys) predictive text input system used in old mobile phones.

## Quick Start

```bash
# Clone and build
git clone https://github.com/Kybton/mobile-keypad-simulator.git
cd KeyPadPhone
dotnet build

# Run demo
cd src/KeyPadPhone.Console
dotnet run
```

### Basic Usage

```csharp
using KeyPadPhone.Core;

// Simple text input
string result = KeyPadPhoneApi.OldPhonePad("222 2 22#");
Console.WriteLine(result); // Output: "CAB"

// Word input
string hello = KeyPadPhoneApi.OldPhonePad("4433555 555666#");
Console.WriteLine(hello); // Output: "HELLO"
```

## How T9 Works

**Key Mappings**: `1`=('&, `2`=ABC, `3`=DEF, `4`=GHI, `5`=JKL, `6`=MNO, `7`=PQRS, `8`=TUV, `9`=WXYZ, `0`=Space,

**Special Keys**: `#`=Send, `*`=Backspace, `Space`=Pause

**Usage**: Multiple presses cycle through characters (`2`=A, `22`=B, `222`=C). Use space to pause between characters, `*` to backspace, `#` to send.

**Loopback Input**: The system handles loopback input by detecting when the same key is pressed multiple times beyond the available characters, cycling back to the first character of that key.

## Examples

```csharp
KeyPadPhoneApi.OldPhonePad("2#");                  // "A"
KeyPadPhoneApi.OldPhonePad("222 2 22#");           // "CAB"
KeyPadPhoneApi.OldPhonePad("4433555 555666#");     // "HELLO"
KeyPadPhoneApi.OldPhonePad("227*#");               // "A" (backspace demo)
KeyPadPhoneApi.OldPhonePad("2222#");               // "A" (loopback: 4th press cycles back to A)
```

## Testing

```bash
# Run all tests
dotnet test
```

## Documentation

- **[Architecture](docs/Architecture.md)**: System design and component relationships
- **[API Reference](docs/APIReference.md)**: Complete API documentation with examples

## Features

- **Performance**: O(n) time complexity, minimal memory allocation
- **Thread Safe**: Immutable configurations, stateless design
- **Extensible**: Easy to add new phone types and character mappings
- **Zero Dependencies**: Pure .NET implementation

## Requirements

- **.NET 8.0** or compatible
- **No external dependencies**

## License

- This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
