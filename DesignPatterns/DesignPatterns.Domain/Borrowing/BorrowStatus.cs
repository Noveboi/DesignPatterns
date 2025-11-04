namespace DesignPatterns.Domain.Borrowing;

/// <summary>
/// Data class that contains information about library item borrowing. 
/// </summary>
public sealed record BorrowStatus(
    TimeSpan LoanPeriod,
    double FineMultiplier = 1,
    DateTime? BorrowedAtUtc = null,
    bool HasPaidFine = false,
    User? BorrowedBy = null)
{
    public bool IsBorrowed => BorrowedBy is not null && BorrowedAtUtc is not null;
    public DateTime? DueDate => BorrowedAtUtc + LoanPeriod;
}