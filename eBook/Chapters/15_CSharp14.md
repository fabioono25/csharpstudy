# Chapter 15 --- C# 14.0: Evolving the Language Core

## Summary
Projected for late 2025 with .NET 10, C# 14.0 introduces major extensibility improvements with **Extension Members**, allowing developers to add properties and simplify extension method syntax. The `field` keyword is stabilized for semi-auto properties.

## Highlights & Internal Changes
*   **Extension Members**: Revolutionary feature allowing "extension everything" - properties, static members, and more.
*   **First-Class Spans**: More implicit conversions make `Span<T>` easier to use throughout the language.

## Topics

### Extension Members

#### Summary
**Extension Members** (also known as "Roles" or "Extensions") allow you to add properties, static members, and other members to existing types, going beyond just extension methods.

#### Motivation / When to Use
*   **Augmenting Types**: Adding a `FullName` property to a `Person` class you don't own.
*   **Adapters**: Making a third-party class implement an interface (if supported by the final design).

#### Benefits
*   **Natural Syntax**: Access extensions as if they were native members (`person.FullName` instead of `person.GetFullName()`).
*   **Organization**: Group related extensions together.

#### Improvements (C# specifics)
*   New `implicit extension` or `extension` syntax (exact syntax subject to change).
*   Removes the need for the `this` modifier on the first parameter.

#### Example
```csharp
// Proposed syntax (subject to change)
public implicit extension PersonExtensions for Person
{
    // Extension Property!
    public string FullName => $"{FirstName} {LastName}";

    // Extension Method (no 'this' needed)
    public void Print() => Console.WriteLine(FullName);
}

// Usage
var p = new Person { FirstName = "Alice", LastName = "Smith" };
Console.WriteLine(p.FullName); // Access property
p.Print();
```

#### Line-by-Line Explanation
*   `implicit extension ... for Person`: Defines extensions that apply to `Person`.
*   `FullName`: A property that doesn't exist on the original `Person` class but is added by the extension.

#### Tests
[2 - ExtensionMembers.cs](../../CSharpStudy.Tests/CSharp14/2%20-%20ExtensionMembers.cs)

#### Common Pitfalls / Gotchas
*   **State**: Extension members usually cannot add *instance state* (fields). They can only compute values from existing public members.
*   **Ambiguity**: If the type adds a member with the same name later, it takes precedence over the extension.

#### Best Practices / Checklist
*   Use to add computed properties or helper methods to types you don't control.

#### Related Topics
*   Extension Methods
*   Type Classes (Concept)

### Field Keyword (Stabilized)

#### Summary
The **`field` keyword** allows you to access the compiler-generated backing field of an auto-implemented property. This enables "semi-auto" properties where you can add logic to the `set` accessor without manually declaring a private backing field.

#### Motivation / When to Use
*   **Validation**: Trimming a string or checking a range in the setter.
*   **Notification**: Raising `PropertyChanged` events (MVVM).
*   **Lazy Loading**: Initializing the field on first access.

#### Benefits
*   **Conciseness**: Removes the need for `private string _name;`.
*   **Readability**: Keeps the property definition self-contained.

#### Improvements (C# specifics)
*   `field` is a contextual keyword inside the property accessor.

#### Example
```csharp
public class User
{
    public string Name
    {
        get; // Default getter
        set => field = value.Trim(); // Access backing field to trim input
    }

    public int Age
    {
        get => field;
        set
        {
            if (value < 0) throw new ArgumentException("Age cannot be negative");
            field = value;
        }
    }
}
```

#### Line-by-Line Explanation
*   `field = value.Trim()`: Assigns the trimmed value to the invisible backing field.

#### Tests
[1 - FieldKeyword.cs](../../CSharpStudy.Tests/CSharp14/1%20-%20FieldKeyword.cs)

#### Common Pitfalls / Gotchas
*   **Keyword Conflict**: If you have a member named `field`, you might need to use `@field` or `this.field` to disambiguate (though `field` is usually contextual).

#### Best Practices / Checklist
*   Use whenever you need simple validation or transformation in a property.
*   Stop writing manual backing fields for simple cases.

#### Related Topics
*   Properties
*   Auto-Implemented Properties

### First-Class Span Types

#### Summary
**First-Class Span Types** aims to make `Span<T>` and `ReadOnlySpan<T>` feel more like native language primitives by adding more implicit conversions and allowing them in more contexts.

#### Motivation / When to Use
*   **Ease of Use**: Passing arrays or strings to methods expecting spans without explicit casting or `.AsSpan()`.
*   **Consistency**: Reducing friction when working with high-performance APIs.

#### Benefits
*   **Cleaner Code**: Less verbose `.AsSpan()` calls.
*   **Adoption**: Encourages using spans by default.

#### Improvements (C# specifics)
*   Implicit conversions from `T[]` to `Span<T>` (already exists, but refined).
*   Better type inference for spans.

#### Example
```csharp
void ProcessText(ReadOnlySpan<char> text) { }

// C# 14 (Proposed) - Smoother conversions
ProcessText("Hello"); // Works (existing)
ProcessText(new char[] { 'a', 'b' }); // Works (existing)

// Future improvements might allow more seamless interop with other types
```

#### Line-by-Line Explanation
*   `ProcessText("Hello")`: Implicitly converts string to `ReadOnlySpan<char>`.

#### Tests
[3 - FirstClassSpanTypes.cs](../../CSharpStudy.Tests/CSharp14/3%20-%20FirstClassSpanTypes.cs)

#### Common Pitfalls / Gotchas
*   **Lifetime**: Spans are still stack-only types. You cannot store them in fields of classes.

#### Best Practices / Checklist
*   Use `ReadOnlySpan<T>` for parameters representing buffers or text.

#### Related Topics
*   Span<T>
*   Memory Management

### Params Expansion (generalized access)

#### Summary
**Params Expansion** generalizes the `params` keyword to work with any collection type, including `List<T>`, `Span<T>`, and `IEnumerable<T>`. This builds upon the work in C# 13.

#### Motivation / When to Use
*   **API Design**: Creating flexible APIs that accept variable arguments but don't force array allocation.
*   **Overloads**: Reducing the need for multiple overloads (one for array, one for list, etc.).

#### Benefits
*   **Flexibility**: Callers can pass individual items OR a collection of their choice.
*   **Performance**: Zero-allocation passing via `params ReadOnlySpan<T>`.

#### Improvements (C# specifics)
*   Completes the `params` journey started in C# 13.

#### Example
```csharp
void Print(params List<string> items) 
{ 
    items.Add("Done"); // It's a real list!
    foreach (var item in items) Console.WriteLine(item);
}

Print("A", "B", "C"); // Compiler creates a List<string> and passes it
```

#### Line-by-Line Explanation
*   `params List<string>`: The compiler synthesizes a `List<string>` containing the arguments.

#### Tests
[1 - ParamsCollections.cs](../../CSharpStudy.Tests/CSharp13/1%20-%20ParamsCollections.cs)

#### Common Pitfalls / Gotchas
*   **Allocation**: `params List<T>` *does* allocate a list. Use `params ReadOnlySpan<T>` if you want zero allocation.

#### Best Practices / Checklist
*   Use `params ReadOnlySpan<T>` for reading.
*   Use `params IEnumerable<T>` for general iteration.
*   Use `params List<T>` only if you need to mutate the collection or store it.

#### Related Topics
*   Params Collections (C# 13)
*   Collection Expressions

### Refinements to Method Group Conversions

#### Summary
**Refinements to Method Group Conversions** improve how the compiler treats method names when assigned to delegates or `var`. The compiler is smarter about selecting the best overload and avoiding unnecessary allocations.

#### Motivation / When to Use
*   **Delegates**: Assigning a method to a `Func` or `Action`.
*   **LINQ**: Passing methods directly to LINQ operators (e.g., `.Select(int.Parse)`).

#### Benefits
*   **Performance**: Reduces delegate allocation overhead in some cases (compiler can cache the delegate).
*   **Inference**: Better type inference when multiple overloads exist.

#### Improvements (C# specifics)
*   The compiler can now better disambiguate between overloads when converting a method group to a delegate.

#### Example
```csharp
void DoWork(Func<int, int> worker) { ... }
void DoWork(Func<string, int> worker) { ... }

int Parse(string s) => int.Parse(s);
int Parse(int i) => i;

// Compiler can now better figure out which 'Parse' you mean based on context
DoWork(Parse); 
```

#### Line-by-Line Explanation
*   `DoWork(Parse)`: The compiler analyzes the available `DoWork` overloads and `Parse` overloads to find a matching pair.

#### Tests
Verified via compiler behavior.

#### Common Pitfalls / Gotchas
*   **Ambiguity**: If the overloads are too similar, you might still need to cast explicitly: `DoWork((Func<string, int>)Parse)`.

#### Best Practices / Checklist
*   Pass method groups directly to delegates/LINQ instead of wrapping them in lambdas `x => Method(x)` when possible, for cleaner code.

#### Related Topics
*   Delegates
*   Method Groups

### The Continuous Cycle of .NET Annual Releases

#### Summary
Microsoft has adopted an **annual release cadence** for .NET and C#. New major versions are released every **November**.

#### Motivation / When to Use
*   **Planning**: Enterprises can plan upgrades predictably.
*   **Support**: Even-numbered releases (like .NET 8, 10) are **LTS** (Long Term Support - 3 years). Odd-numbered releases (like .NET 9, 11) are **STS** (Standard Term Support - 18 months).

#### Benefits
*   **Predictability**: No guessing when the next version comes out.
*   **Agility**: New features reach developers faster.

#### Improvements (C# specifics)
*   C# version numbers align with .NET version numbers (mostly).
    *   .NET 8 -> C# 12
    *   .NET 9 -> C# 13
    *   .NET 10 -> C# 14
    *   .NET 11 -> C# 15

#### Example
*   **November 2023**: .NET 8 (LTS) + C# 12
*   **November 2024**: .NET 9 (STS) + C# 13
*   **November 2025**: .NET 10 (LTS) + C# 14
*   **November 2026**: .NET 11 (STS) + C# 15

#### Best Practices / Checklist
*   Target **LTS** versions for long-running production applications that you don't want to upgrade often.
*   Target **STS** versions if you want the absolute latest features and are willing to upgrade every year.

#### Related Topics
*   .NET Versioning
*   LTS vs STS
