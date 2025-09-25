/*
 * Copyright (c) 2025 Min Oak Kyaw
 * Licensed under the MIT License. See LICENSE file for details.
 */

using KeyPadPhone.Core.Entities;
using KeyPadPhone.Core.Infrastructure.Constants;

namespace KeyPadPhone.Core;

// API Class so that the application layer is not directly dependent on the domain layer
public static class KeyPadPhoneApi
{
    /// <summary>
    /// Processes T9 keypad input and converts it to text output.
    /// </summary>
    /// <param name="inputString">The keypad input string</param>
    /// <param name="phoneType">The type of phone to emulate</param>
    /// <returns>The converted text string, or empty string if input is invalid</returns>
    public static string OldPhonePad(string inputString, PhoneType phoneType = PhoneType.T9Keypad)
    {
        return Phone.OldPhonePad(inputString, phoneType);
    }
}
