namespace DesignPatterns.Domain;

/// <summary>
/// Represents a book's identifier (International Standard Book Number)
/// </summary>
public sealed class Isbn
{
    private readonly int[] _digits;
    
    public IsbnParts Parts { get; }
    public int Length => _digits.Length;
    private bool IsIsbn13 => Length == 13;
    
    public Isbn(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        _digits = Validate(value);
        Parts = ParseParts(value.Replace("-", ""));
    }

    private static int[] Validate(string value)
    {
        // For ISBN-10, 'X' is allowed as the last character (check digit = 10)
        if (value.Any(c => !char.IsAsciiDigit(c) && c != '-' && c != 'X' && c != 'x'))
        {
            throw new ArgumentException("ISBN should only be composed of digits (0-9), dashes (-), and optionally 'X' as the last character", nameof(value));
        }

        var digitsString = value.Replace("-", "");
        
        // Convert to int array, handling 'X' as 10
        var digits = new int[digitsString.Length];
        for (var i = 0; i < digitsString.Length; i++)
        {
            if (char.ToUpper(digitsString[i]) == 'X')
            {
                if (i != digitsString.Length - 1)
                {
                    throw new ArgumentException("'X' can only appear as the last character in ISBN-10", nameof(value));
                }
                digits[i] = 10;
            }
            else
            {
                digits[i] = digitsString[i] - '0';
            }
        }

        var checkDigit = digits.Length switch
        {
            10 => GetCheckDigitFor10(digits[..^1]),
            13 => GetCheckDigitFor13(digits[..^1]),
            _ => throw new ArgumentException("ISBN must be 10 or 13 digits long.", nameof(value))
        };

        return checkDigit == digits[^1] 
            ? digits 
            : throw new ArgumentException($"ISBN check digit is incorrect. Expected check digit: '{(checkDigit == 10 ? "X" : checkDigit.ToString())}'", nameof(value));
    }

    private static int GetCheckDigitFor10(int[] value)
    {
        var sum = 0;

        for (var i = 0; i < 9; i++)
        {
            sum += value[i] * (10 - i);
        }

        var r = 11 - sum % 11;
        return r % 11;
    }

    private static int GetCheckDigitFor13(int[] value)
    {
        var sum = 0;

        for (var i = 0; i < 12; i++)
        {
            sum += i % 2 == 0 
                ? value[i] 
                : value[i] * 3;
        }

        var r = 10 - sum % 10;
        return r % 10;
    }

    private static IsbnParts ParseParts(string digitsString)
    {
        if (digitsString.Length == 13)
        {
            var prefix = digitsString[..3]; // 978 or 979
            
            // Simplified
            var registrationGroup = digitsString[3..4];
            var registrant = digitsString[4..8];
            var publication = digitsString[8..12];
            var checkDigit = digitsString[12..];
            
            return new IsbnParts(prefix, registrationGroup, registrant, publication, checkDigit);
        }
        else
        {
            var registrationGroup = digitsString[0..1];
            var registrant = digitsString[1..5];
            var publication = digitsString[5..9];
            var checkDigit = digitsString[9..];
            
            return new IsbnParts(null, registrationGroup, registrant, publication, checkDigit);
        }
    }

    public override string ToString()
    {
        return IsIsbn13 ?
            $"{Parts.Prefix}-{Parts.RegistrationGroup}-{Parts.Registrant}-{Parts.Publication}-{Parts.CheckDigit}" :
            $"{Parts.RegistrationGroup}-{Parts.Registrant}-{Parts.Publication}-{Parts.CheckDigit}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Isbn other && _digits.SequenceEqual(other._digits);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var digit in _digits)
        {
            hash.Add(digit);
        }
        return hash.ToHashCode();
    }
}