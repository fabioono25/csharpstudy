# Chapter 10 --- C# 9.0: Immutability & Minimalism

## Summary
Released in 2020 with .NET 5, C# 9.0 focused on supporting immutable data models and reducing code verbosity. It introduced **Records**, a concise way to define reference types with value-based equality, perfect for modern cloud-native and functional programming styles.

## Highlights & Internal Changes
*   **Native Integers**: Introduced `nint` and `nuint` types that map to the platform's native integer size.
*   **Function Pointers**: Added support for calling functions using the `ldftn` and `calli` opcodes, improving performance for low-level scenarios.

## Topics

### Records (value equality and `with` expressions)

#### Summary
**Records** are reference types that provide value-based equality and built-in immutability features. They are ideal for data-centric models (DTOs).

#### Motivation / When to Use
*   **DTOs**: Data Transfer Objects where equality depends on content, not identity.
*   **Functional Programming**: Immutable data structures.
*   **Concise Models**: Define a class with properties and constructor in one line.

#### Benefits
*   **Value Equality**: `r1 == r2` checks if all properties are equal.
*   **Immutability**: Safe to share; `with` expressions allow non-destructive mutation.
*   **Conciseness**: Positional records generate constructor, properties, and deconstructor automatically.

#### Improvements (C# specifics)
*   `record` keyword defines the type.
*   Compiler generates `Equals`, `GetHashCode`, `ToString`, and `Deconstruct`.
*   `with` keyword creates a copy with modified properties.

#### Example
```csharp
// Positional record
public record Person(string Name, int Age);

var p1 = new Person("Alice", 30);
var p2 = new Person("Alice", 30);

Console.WriteLine(p1 == p2); // True (Value equality)

// Non-destructive mutation (with expression)
var p3 = p1 with { Age = 31 }; // New instance, Name is "Alice"
```

#### Line-by-Line Explanation
*   `public record Person(...)`: Defines a class with init-only properties.
*   `p1 == p2`: Compares values of Name and Age.
*   `p1 with { ... }`: Clones `p1` and updates specified properties.

#### Tests
[3 - Records.cs](../../CSharpStudy.Tests/CSharp9/3%20-%20Records.cs)

#### Common Pitfalls / Gotchas
*   **Reference Type**: Records are classes (unless `record struct` in C# 10).
*   **Mutable Properties**: You *can* define mutable properties in records, but it breaks the immutability guarantee.

#### Best Practices / Checklist
*   Use positional records for immutable data.
*   Prefer records over classes for DTOs.

#### Related Topics
*   Classes
*   Structs
*   Record Structs (C# 10.0)

### Init-only properties

#### Summary
**Init-only properties** (`init` accessor) allow properties to be set during object initialization but become read-only afterwards.

#### Motivation / When to Use
*   **Immutable Objects**: Allow object initializer syntax (`new Obj { Prop = val }`) while keeping the object immutable.
*   **Constructor Flexibility**: Avoid massive constructors with many optional parameters.

#### Benefits
*   **Flexibility**: Callers choose which properties to set.
*   **Immutability**: Guarantees property won't change after initialization.

#### Improvements (C# specifics)
*   Replaces `set` with `init`.
*   Can be set in constructor or object initializer.

#### Example
```csharp
public class Configuration
{
    public string Host { get; init; }
    public int Port { get; init; } = 80;
}

// Allowed
var config = new Configuration { Host = "localhost", Port = 8080 };

// Error: Cannot be assigned to -- it is read-only
// config.Host = "127.0.0.1"; 
```

#### Line-by-Line Explanation
*   `get; init;`: Property can be written to only during construction/initialization.

#### Tests
[4 - InitOnly.cs](../../CSharpStudy.Tests/CSharp9/4%20-%20InitOnly.cs)

#### Common Pitfalls / Gotchas
*   **Reflection**: Reflection can still set init-only properties (though it's discouraged).
*   **Constructor**: You can set init properties inside the class constructor.

#### Best Practices / Checklist
*   Use `init` instead of `set` for properties that shouldn't change.
*   Combine with nullable reference types for required properties (or `required` in C# 11).

#### Related Topics
*   Properties
*   Required Members (C# 11.0)

### Top-level statements

#### Summary
**Top-level statements** allow you to write the main entry point of an application directly at the root of a file, without wrapping it in a `class Program` and `static void Main`.

#### Motivation / When to Use
*   **Scripting**: Write simple scripts quickly.
*   **Learning**: Remove boilerplate for beginners.
*   **Microservices**: Minimal setup for small apps (e.g., Azure Functions).

#### Benefits
*   **Concise**: Reduces noise (namespace, class, method).
*   **Focus**: Immediate visibility of the program logic.

#### Improvements (C# specifics)
*   Compiler generates the `Program` class and `Main` method for you.
*   Only one file in the project can have top-level statements.

#### Example
```csharp
using System;

Console.WriteLine("Hello, World!");

if (args.Length > 0)
{
    Console.WriteLine($"Arg: {args[0]}");
}

// Can define methods at the bottom
void Log(string msg) => Console.WriteLine(msg);
```

#### Line-by-Line Explanation
*   `using System;`: Usings go at the top.
*   `Console.WriteLine`: Executed immediately.
*   `args`: Magic variable available for command-line arguments.

#### Tests
[1 - TopLevelStatements.cs](../../CSharpStudy.Tests/CSharp9/1%20-%20TopLevelStatements.cs)

#### Common Pitfalls / Gotchas
*   **Multiple Entry Points**: Only one file can use this feature.
*   **Scope**: Variables defined here are in the "global" scope of the generated Main method, but not truly global to other classes.

#### Best Practices / Checklist
*   Use for `Program.cs` in console apps and web APIs.
*   Keep it clean; move complex logic to classes.

#### Related Topics
*   Main Method
*   Program Class

### Relational and logical pattern improvements

#### Summary
**Pattern Matching** was enhanced with relational operators (`<`, `>`, `<=`, `>=`) and logical operators (`and`, `or`, `not`), allowing for expressive and readable conditions.

#### Motivation / When to Use
*   **Range Checks**: Checking if a number is within a range.
*   **Null Checks**: `is not null` is clearer than `! (x is null)`.
*   **Complex Logic**: Combining multiple conditions without nested `if`s.

#### Benefits
*   **Readability**: Reads like natural language.
*   **Conciseness**: Reduces boilerplate code.

#### Improvements (C# specifics)
*   Works in `is` expressions and `switch` expressions.
*   `not` pattern negates a pattern match.

#### Example
```csharp
int age = 25;

// Relational and logical patterns
if (age is >= 18 and <= 65)
{
    Console.WriteLine("Working age");
}

// 'not' pattern
object? obj = GetObject();
if (obj is not null)
{
    // Safe to use obj
}

// Switch expression with patterns
string category = age switch
{
    < 13 => "Child",
    >= 13 and < 20 => "Teenager",
    _ => "Adult"
};
```

#### Line-by-Line Explanation
*   `is >= 18 and <= 65`: Checks if age is between 18 and 65 inclusive.
*   `is not null`: Checks if object is not null.

#### Tests
[2 - PatternMatchingEnhancements.cs](../../CSharpStudy.Tests/CSharp9/2%20-%20PatternMatchingEnhancements.cs)

#### Common Pitfalls / Gotchas
*   **Precedence**: `and` has higher precedence than `or`.
*   **Variable Capture**: You cannot capture variables in `or` or `not` patterns easily.

#### Best Practices / Checklist
*   Use `is not null` instead of `!= null` for clarity.
*   Use ranges in switch expressions for numeric logic.

#### Related Topics
*   Pattern Matching (C# 7.0)
*   Switch Expressions (C# 8.0)

### Target-typed `new` expressions

#### Summary
**Target-typed `new`** allows you to omit the type name when instantiating an object if the type can be inferred from the context (the "target").

#### Motivation / When to Use
*   **Field Initialization**: `private List<string> _names = new();`
*   **Argument Passing**: `Process(new("data"));`
*   **Collection Initializers**: Less repetition.

#### Benefits
*   **DRY (Don't Repeat Yourself)**: Avoids typing the class name twice.
*   **Readability**: Reduces visual clutter.

#### Improvements (C# specifics)
*   Works for fields, properties, variables, and arguments.
*   Type must be explicitly known (cannot use with `var`).

#### Example
```csharp
// Explicit type
List<string> names = new();

// Field initialization
private Dictionary<string, int> _cache = new();

// Method argument
DoSomething(new Person("Alice", 30));

// Collection initializer
Point[] points = { new(1, 2), new(3, 4) };
```

#### Line-by-Line Explanation
*   `new()`: Compiler infers `List<string>` from the variable declaration.
*   `new(1, 2)`: Infers `Point` from the array type.

#### Tests
[5 - TargetTypedNew.cs](../../CSharpStudy.Tests/CSharp9/5%20-%20TargetTypedNew.cs)

#### Common Pitfalls / Gotchas
*   **`var`**: `var x = new();` is invalid (compiler doesn't know the type).
*   **Readability**: Avoid if the type isn't obvious from context (e.g., `Process(new())`).

#### Best Practices / Checklist
*   Use when the type is explicitly stated on the left side.
*   Use for field initializers.

#### Related Topics
*   Constructors
*   var keyword


### Covariant Return Types

#### Summary
**Covariant Return Types** allow an overriding method to return a more derived type than the method in the base class.

#### Motivation / When to Use
*   **Factory Methods**: `Clone()` method returning the specific type instead of `object`.
*   **Builder Pattern**: Fluent APIs returning the specific builder type.

#### Benefits
*   **Type Safety**: Callers get the specific type without casting.
*   **Usability**: Cleaner API consumption.

#### Improvements (C# specifics)
*   Previously, overrides had to match the return type exactly.
*   Now, the return type just needs to be convertible to the base return type.

#### Example
```csharp
public class Animal
{
    public virtual Animal Clone() => new Animal();
}

public class Dog : Animal
{
    // Override returns 'Dog', which is derived from 'Animal'
    public override Dog Clone() => new Dog();
}

// Usage
Dog d = new Dog();
Dog clone = d.Clone(); // No cast needed!
```

#### Line-by-Line Explanation
*   `public override Dog Clone()`: Returns `Dog` instead of `Animal`.
*   `d.Clone()`: Compiler knows this returns a `Dog`.

#### Tests
[6 - CovariantReturns.cs](../../CSharpStudy.Tests/CSharp9/6%20-%20CovariantReturns.cs)

#### Common Pitfalls / Gotchas
*   **Value Types**: Does not work with value types (e.g., returning `int` when base returns `object`).
*   **Language Version**: Requires C# 9.0+ runtime support (.NET 5+).

#### Best Practices / Checklist
*   Use whenever the derived method naturally returns a more specific type.
*   Great for `Clone` methods.

#### Related Topics
*   Inheritance
*   Polymorphism

### Module Initializers

#### Summary
**Module Initializers** allow you to define code that runs automatically when an assembly (module) is first loaded. This is done by marking a static method with the `[ModuleInitializer]` attribute.

#### Motivation / When to Use
*   **Library Setup**: Registering dependencies or configuration.
*   **Interop**: Initializing native libraries.
*   **Registration**: Auto-registering plugins or extensions.

#### Benefits
*   **Automatic**: No need for the user to call `Init()`.
*   **Guaranteed**: Runs before any other code in the module.

#### Improvements (C# specifics)
*   Exposes the CLR feature `.cctor` for modules to C#.
*   Method must be `static`, `void`, and parameterless.

#### Example
```csharp
using System.Runtime.CompilerServices;

public class LibrarySetup
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.WriteLine("Library Loaded!");
        // Perform one-time setup here
    }
}
```

#### Line-by-Line Explanation
*   `[ModuleInitializer]`: Compiler marker.
*   `Init()`: Executed by the runtime when the DLL is loaded.

#### Tests
[9 - ModuleInitializers.cs](../../CSharpStudy.Tests/CSharp9/9%20-%20ModuleInitializers.cs)

#### Common Pitfalls / Gotchas
*   **Order**: If multiple initializers exist, order is undefined.
*   **Exceptions**: Exceptions here can crash the application startup.

#### Best Practices / Checklist
*   Keep initialization logic fast and fail-safe.
*   Use sparingly; explicit initialization is often clearer.

#### Related Topics
*   Static Constructors
*   Attributes
