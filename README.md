# Design Patterns

Contains all the documents for the final project.

## Θέμα 1

### Overview

In the first exercise, I use a simplified library business model as the backbone for the application of the required design patterns and SOLID principles.

The solution is written in C# and contains 4 projects structured with a standard Clean Architecture approach:

- **Domain**: Contains the code implementation of the business, including business logic.

- **Application**: Contains business workflow/orchestration such as commands and queries.

- **Infrastructure**: Contains any interaction with an external service (such as database and messaging).

- **Web API**: Contains the main entry point of the system as well as REST API endpoint definition and dependency injection configuration.

### SOLID Principles

#### Single Responsibility

In the solution, the single responsibility principle is enforced everywhere, a clear example is the Commands/Queries setup. Each business use case is contained within its own file.

#### Open-Closed

The Open/Closed principle states that entities should be open for extension but closed for modification. I've illustrated this principle in the "Fine Calculation" use case. A violation of this principle could look like this:

```csharp
public class FineCalculator 
{
    public double CalculateFine(BookType bookType, int daysLate) 
    {
        var multipler = bookType switch 
        {
            BookType.Book => 0.5,
            BookType.Dvd => 1,
            BookType.Magazine => 0.3,
            _ => 0.25
        };

        return daysLate * multiplier; 
    }
}
```

If another book type were to be supported, then we'd have to **modify** the existing implementation.

#### Liskov Substitution

LSP is enforced implicitly through ISP, by splitting interfaces into smaller interfaces that typically describe just one behavior we allow classes to naturally declare what behaviors they want to have without breaking existing behavior defined in interfaces.

I'll illustrate with an example:

```csharp
interface ILibraryItem 
{
    string Title { get; }
    void Borrow();
}

// This class is ok, no violations.
class Book : ILibraryItem 
{
    public required string Title { get; init; }
    
    public void Borrow() 
    {
        ...
    }
}

// This class is not ok, it violates LSP by breaking the Borrow behavior
class Archive : ILibraryItem 
{
    public required string Title { get; init; }

    public void Borrow() 
    {
        throw new NotSupportedException("Borrowing archives is not supported.");
    }
}
```

I'll provide a solution to this in the next section (ISP).

#### Interface Segregation

With ISP, we create small, bite-sized interfaces that typically define one behavior. In the example above, we can enforce the principle by removing the `Borrow` behavior from the `ILibraryItem` and placing it in a separate interface:

```csharp
interface ILibraryItem 
{
    string Title { get; }
}

interface IBorrowable 
{
    void Borrow();
}

// and then...
class Book : ILibraryItem, IBorrowable { ... }
class Archive : ILibraryItem { ... }
// problem eliminated!
```

#### Dependency Inversion

As with the single responsibility principle, this principle is enforced everywhere in the solution due to Dependency Injection and designing for testability.