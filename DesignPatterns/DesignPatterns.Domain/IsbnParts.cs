namespace DesignPatterns.Domain;

/// <summary>
/// Represents the parsed components of an ISBN
/// </summary>
public sealed class IsbnParts
{
    /// <summary>
    /// The GS1 prefix (978 or 979 for ISBN-13, null for ISBN-10)
    /// </summary>
    public string? Prefix { get; }
    
    /// <summary>
    /// Identifies the country, geographical region, or language area
    /// </summary>
    public string RegistrationGroup { get; }
    
    /// <summary>
    /// Identifies the publisher or imprint
    /// </summary>
    public string Registrant { get; }
    
    /// <summary>
    /// Identifies the specific edition and format
    /// </summary>
    public string Publication { get; }
    
    /// <summary>
    /// The check digit (can be 'X' for ISBN-10)
    /// </summary>
    public string CheckDigit { get; }

    public IsbnParts(string? prefix, string registrationGroup, string registrant, string publication, string checkDigit)
    {
        Prefix = prefix;
        RegistrationGroup = registrationGroup;
        Registrant = registrant;
        Publication = publication;
        CheckDigit = checkDigit;
    }
}