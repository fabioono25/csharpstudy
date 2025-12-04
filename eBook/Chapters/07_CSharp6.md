# Chapter 7 --- C# 6.0: Code Simplification

## Summary
Released in 2015 with Visual Studio 2015, C# 6.0 was the first version released with the **Roslyn** compiler (the .NET Compiler Platform). This version focused on "syntactic sugar"—small features that remove boilerplate and make code more concise and readable. It didn't introduce major paradigm shifts like LINQ or Async, but it significantly improved daily coding life.

## Highlights & Internal Changes
*   **Roslyn Compiler**: The compiler was rewritten in C#, opening up the compilation process to developers (analyzers, code fixes).
*   **Static Imports**: Ability to import static members directly.

## Topics

### Null-conditional operator (`?.`, `?[]`)

#### Summary
**Null-conditional operators** safely access members (`?.`) or elements (`?[]`) when the operand is not null. If null, the expression short-circuits and returns null.

#### Motivation / When to Use
*   **Chained Properties**: Safely navigate `order?.Customer?.Address?.City`.
*   **Array/List Access**: `items?[0]?.Name`.
*   **Event Invocation**: `PropertyChanged?.Invoke(...)`.

#### Benefits
*   **Concise**: Replaces nested `if (x != null)` checks.
*   **Safe**: Prevents `NullReferenceException`.

#### Improvements (C# specifics)
*   **Short-Circuit**: Entire chain evaluates to null if any part is null.
*   **Works with value types**: Returns `Nullable<T>`.

#### Example
```csharp
string? city = customer?.Address?.City;
int? firstOrderId = customer?.Orders?[0]?.Id;

// Event invocation pattern
PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
```

#### Line-by-Line Explanation
*   `customer?.Address`: Returns `null` if `customer` is null, otherwise accesses `Address`.
*   `?[0]`: Safely accesses first element if collection is not null.

#### Tests
[1 - NullConditionalOperator.cs](../../CSharpStudy.Tests/CSharp6/1%20-%20NullConditionalOperator.cs)

```csharp
[Fact]
public void NullConditional_ReturnsNull_WhenNull()
{
    string? s = null;
    int? len = s?.Length;
    
    Assert.Null(len);
}
```

#### Common Pitfalls / Gotchas
*   **Value Type Results**: `obj?.IntProperty` returns `int?`, not `int`.
*   **Method Calls**: `list?.Clear()` still requires null check for void methods.

#### Best Practices / Checklist
*   Combine with `??` for defaults: `name?.Length ?? 0`.
*   Use for event invocation to avoid null checks.

#### Related Topics
*   Null-coalescing operator (`??`, `??=`)
*   Nullable Reference Types (C# 8.0)

### String Interpolation (`$""`)

#### Summary
**String Interpolation** allows embedding expressions directly within string literals using `$""` syntax. Expressions are placed inside `{}` braces.

#### Motivation / When to Use
*   **Logging**: Build log messages with variable values.
*   **Display Strings**: Format user-facing text.
*   **SQL/Queries**: (Careful!) Build dynamic queries.

#### Benefits
*   **Readable**: Variables inline with text.
*   **Format Support**: `{value:format}` for dates, numbers.

#### Improvements (C# specifics)
*   **`$@""` or `@$""`**: Combines interpolation with verbatim strings.
*   **`$$"...{{expr}}..."`**: Raw string literals (C# 11).

#### Example
```csharp
string name = "Alice";
int age = 30;
DateTime now = DateTime.Now;

string msg = $"Hello, {name}! You are {age} years old.";
string formatted = $"Date: {now:yyyy-MM-dd}";
```

#### Line-by-Line Explanation
*   `$"..."`: Prefix enables interpolation.
*   `{name}`: Replaced with variable value.
*   `{now:yyyy-MM-dd}`: Format specifier after colon.

#### Tests
[2 - StringInterpolation.cs](../../CSharpStudy.Tests/CSharp6/2%20-%20StringInterpolation.cs)

```csharp
[Fact]
public void Interpolation_EmbedsValues()
{
    int x = 5;
    string result = $"Value is {x}";
    
    Assert.Equal("Value is 5", result);
}
```

#### Common Pitfalls / Gotchas
*   **SQL Injection**: Don't use for raw SQL—use parameterized queries.
*   **Curly Braces**: Escape with `{{` and `}}`.

#### Best Practices / Checklist
*   Prefer over `string.Format`.
*   Use format specifiers for numbers and dates.

#### Related Topics
*   `FormattableString`
*   Composite Formatting
*   Raw String Literals (C# 11)

### Expression-bodied members

#### Summary
**Expression-bodied members** use `=>` syntax for methods, properties, and other members that consist of a single expression. Introduced in C# 6.0 for methods/properties, expanded in C# 7.0.

#### Motivation / When to Use
*   **Simple Methods**: One-liner calculations or returns.
*   **Read-Only Properties**: `public int Age => DateTime.Now.Year - BirthYear;`
*   **ToString/GetHashCode**: Common single-expression overrides.

#### Benefits
*   **Concise**: Less boilerplate.
*   **Readable**: Intent is clear at a glance.

#### Improvements (C# specifics)
*   **C# 6.0**: Methods and read-only properties.
*   **C# 7.0**: Constructors, finalizers, accessors added.

#### Example
```csharp
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    // Expression-bodied method
    public string GetFullName() => $"{FirstName} {LastName}";
    
    // Expression-bodied property
    public string Initials => $"{FirstName[0]}{LastName[0]}";
}
```

#### Line-by-Line Explanation
*   `=> $"{FirstName} {LastName}"`: Single expression, no braces or `return` needed.

#### Tests
[3 - ExpressionBodiedMembers.cs](../../CSharpStudy.Tests/CSharp6/3%20-%20ExpressionBodiedMembers.cs)

#### Common Pitfalls / Gotchas
*   **Multi-statement logic**: Not suitable—use block body instead.
*   **Void methods**: `public void Log() => Console.WriteLine("Hi");` is valid.

#### Best Practices / Checklist
*   Use for single-expression members.
*   Don't force complex logic into expression bodies.

#### Related Topics
*   Lambda Expressions
*   Properties

### `nameof` expressions

#### Summary
**`nameof`** returns the simple string name of a variable, type, or member at compile time. Essential for refactoring-safe strings.

#### Motivation / When to Use
*   **Argument Validation**: `throw new ArgumentNullException(nameof(arg))`.
*   **INotifyPropertyChanged**: `OnPropertyChanged(nameof(Property))`.
*   **Logging**: Include member names in log messages.

#### Benefits
*   **Refactoring-Safe**: Rename refactoring updates the string.
*   **Compile-Time**: No runtime reflection.

#### Improvements (C# specifics)
*   Returns "simple name" (not fully qualified).
*   Works with types, members, parameters, locals.

#### Example
```csharp
public void SetName(string name)
{
    if (name == null)
        throw new ArgumentNullException(nameof(name));
    _name = name;
}

// INotifyPropertyChanged
public string Title
{
    set
    {
        _title = value;
        OnPropertyChanged(nameof(Title)); // "Title"
    }
}
```

#### Line-by-Line Explanation
*   `nameof(name)`: Returns the string `"name"`.
*   `nameof(Title)`: Returns `"Title"`, not `"MyClass.Title"`.

#### Tests
Conceptual feature; tested implicitly via argument validation tests.

#### Common Pitfalls / Gotchas
*   **Only simple name**: `nameof(System.Int32)` returns `"Int32"`, not fully qualified.

#### Best Practices / Checklist
*   Always use for exception parameter names.
*   Use with `INotifyPropertyChanged`.

#### Related Topics
*   Caller Info Attributes (C# 5.0)
*   Argument Validation

### `using static`

#### Summary
**`using static`** imports static members of a class into the current scope, allowing you to call them without the type prefix.

#### Motivation / When to Use
*   **Math Operations**: `using static System.Math;` allows direct use of `PI`, `Sin`, `Cos`.
*   **Console Apps**: `using static System.Console;` for `WriteLine`, `ReadLine`.
*   **Enums**: Access enum values directly.

#### Benefits
*   **Cleaner Code**: Less repetition of type names.
*   **Fluent Reading**: Code reads more naturally.

#### Improvements (C# specifics)
*   Works with static classes and non-static classes (imports only static members).
*   Extension methods from static imports work on their target types.

#### Example
```csharp
using static System.Math;
using static System.Console;

double radius = 5;
double area = PI * Pow(radius, 2);
WriteLine($"Area: {area}");
```

#### Line-by-Line Explanation
*   `using static System.Math`: Imports `PI`, `Pow`, `Sin`, etc.
*   `PI`: No need to write `Math.PI`.

#### Tests
Conceptual feature; no dedicated test file.

#### Common Pitfalls / Gotchas
*   **Ambiguity**: If two static imports have the same member name, you must qualify.
*   **Readability**: Overuse can make code harder to understand (where does `Max` come from?).

#### Best Practices / Checklist
*   Use for well-known types like `Math`, `Console`.
*   Be cautious in large files with many imports.

#### Related Topics
*   Static Classes
*   Extension Methods

### Exception Filters

#### Summary
**Exception Filters** use the `when` keyword to add conditions to `catch` blocks. The catch executes only if both the exception type matches AND the condition is true.

#### Motivation / When to Use
*   **Selective Handling**: Catch only specific error codes or messages.
*   **Logging Without Handling**: Filter that always returns `false` to log then rethrow.
*   **HTTP Status Codes**: Handle `HttpRequestException` only for specific status codes.

#### Benefits
*   **Preserves Stack Trace**: Unlike catch-and-rethrow, original stack is intact.
*   **Cleaner Logic**: Avoids nested if-statements inside catch.

#### Improvements (C# specifics)
*   `when` clause evaluated before entering catch block.
*   Side effects in `when` are discouraged but possible.

#### Example
```csharp
try
{
    await httpClient.GetAsync(url);
}
catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
{
    Console.WriteLine("Resource not found");
}
catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
{
    Console.WriteLine("Access denied");
}
```

#### Line-by-Line Explanation
*   `when (ex.StatusCode == ...)`: Only enters catch if condition is true.
*   Multiple filtered catches can exist for the same exception type.

#### Tests
[6 - ExceptionFilters.cs](../../CSharpStudy.Tests/CSharp6/6%20-%20ExceptionFilters.cs)

#### Common Pitfalls / Gotchas
*   **Side Effects**: Avoid modifying state in `when`—it may be evaluated multiple times.
*   **Order Matters**: More specific filters should come first.

#### Best Practices / Checklist
*   Use for conditional exception handling.
*   Keep `when` conditions simple and side-effect free.

#### Related Topics
*   Exception Handling
*   Pattern Matching in Exceptions (C# 9.0)

### Auto-Property Initializers

#### Summary
**Auto-Property Initializers** allow setting default values for auto-implemented properties directly in the declaration.

#### Motivation / When to Use
*   **Default Values**: Properties that need non-null defaults.
*   **Immutable Objects**: Initialize read-only properties without a constructor.
*   **Collections**: Initialize list properties to empty collections.

#### Benefits
*   **Concise**: No separate constructor code needed.
*   **Read-Only Support**: `{ get; }` properties can be initialized.

#### Improvements (C# specifics)
*   Works with both `{ get; set; }` and `{ get; }` (read-only).
*   Expression is evaluated once per instance creation.

#### Example
```csharp
public class Order
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Created { get; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public List<Item> Items { get; } = new List<Item>();
}
```

#### Line-by-Line Explanation
*   `{ get; } = Guid.NewGuid()`: Read-only property initialized to a new GUID.
*   `{ get; set; } = "Pending"`: Writable property with a default value.

#### Tests
[5 - AutoPropertyInitializers.cs](../../CSharpStudy.Tests/CSharp6/5%20-%20AutoPropertyInitializers.cs)

#### Common Pitfalls / Gotchas
*   **Mutable Defaults**: `new List<T>()` creates one list per instance, not a shared static list.
*   **Expression Evaluation**: Complex expressions run for every instantiation.

#### Best Practices / Checklist
*   Use for simple default values.
*   Prefer for read-only properties to avoid constructor boilerplate.

#### Related Topics
*   Required Properties (C# 11)
*   init-only setters (C# 9.0)

### Dictionary Initializers (Index initializers)

#### Summary
**Dictionary Initializers** use indexer syntax `[key] = value` within object initializers, providing a cleaner alternative to the traditional `{ key, value }` syntax.

#### Motivation / When to Use
*   **Dictionary Creation**: Initialize dictionaries with multiple entries.
*   **Custom Types**: Any type with an indexer can use this syntax.

#### Benefits
*   **Readable**: Key-value pairs are clearly associated.
*   **Overwrites**: Unlike `Add`, the indexer overwrites duplicate keys.

#### Improvements (C# specifics)
*   Works with any type having an indexer.
*   More intuitive than `{ { key, value } }` syntax.

#### Example
```csharp
var errorCodes = new Dictionary<int, string>
{
    [200] = "OK",
    [404] = "Not Found",
    [500] = "Internal Server Error"
};

// Traditional syntax (still valid)
var legacy = new Dictionary<int, string>
{
    { 200, "OK" },
    { 404, "Not Found" }
};
```

#### Line-by-Line Explanation
*   `[200] = "OK"`: Uses indexer to set value for key 200.
*   Indexer syntax allows overwriting; `Add` would throw on duplicates.

#### Tests
[9 - DictionaryInitializers.cs](../../CSharpStudy.Tests/CSharp6/9%20-%20DictionaryInitializers.cs)

#### Common Pitfalls / Gotchas
*   **Duplicate Keys**: Indexer syntax silently overwrites; `Add` throws.

#### Best Practices / Checklist
*   Prefer indexer syntax for clarity.
*   Use when you might have duplicate keys (last one wins).

#### Related Topics
*   Object/Collection Initializers (C# 3.0)
*   Dictionaries
