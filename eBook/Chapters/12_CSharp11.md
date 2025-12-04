# Chapter 12 --- C# 11.0: Raw Strings & Generic Math

## Summary
Released in 2022 with .NET 7, C# 11.0 focused on developer productivity and mathematical capabilities. It introduced **Raw String Literals** to simplify working with JSON, XML, and SQL, and **Generic Math**, which allows writing mathematical algorithms once for all number types.

## Highlights & Internal Changes
*   **Static Abstract Members in Interfaces**: The underlying feature that enables Generic Math. It allows interfaces to define static methods (like operators) that implementing types must provide.

## Topics

### Raw String Literals (`"""`)

#### Summary
**Raw String Literals** allow you to create string literals containing any text, including quotes, backslashes, and newlines, without needing escape sequences. They are delimited by at least three double quotes (`"""`).

#### Motivation / When to Use
*   **Embedded Code**: JSON, XML, HTML, SQL, or Regex patterns.
*   **Multiline Text**: Large blocks of text where whitespace matters.
*   **Paths**: Windows file paths with backslashes.

#### Benefits
*   **Copy-Paste Friendly**: Paste JSON/XML directly without modifying it.
*   **Indentation**: The compiler automatically removes common leading whitespace, so you can align the string with your code.

#### Improvements (C# specifics)
*   Start/End with `"""` (or more quotes if the content contains `"""`).
*   Interpolation: Use multiple `$` (e.g., `$$"""`) to require multiple braces `{{` for interpolation, allowing single braces `{` to appear literally in the content (great for JSON).

#### Example
```csharp
// No escaping needed for quotes or backslashes
string json = """
    {
        "name": "Alice",
        "path": "C:\Users\Alice"
    }
    """;

// Interpolation with JSON (using $$ to escape { })
string name = "Bob";
string json2 = $$"""
    {
        "name": "{{name}}"
    }
    """;
```

#### Line-by-Line Explanation
*   `"""`: Starts the raw string.
*   Indentation: The indentation of the closing `"""` determines the "baseline". Any whitespace to the left of that baseline is removed from all lines.

#### Tests
[2 - RawStringLiterals.cs](../../CSharpStudy.Tests/CSharp11/2%20-%20RawStringLiterals.cs)

#### Common Pitfalls / Gotchas
*   **Indentation**: The closing `"""` must be on its own line and aligned with the start of the text (or further left).
*   **Line Endings**: Normalizes line endings to the source file's format.

#### Best Practices / Checklist
*   Use for any multiline string or string containing special characters.
*   Align the closing quotes with the start of the variable declaration or block for readability.

#### Related Topics
*   Verbatim Strings (`@""`)
*   String Interpolation

### Generic Math (`static abstract` members in interfaces)
*   **Summary**: Allows defining mathematical operations in interfaces.
*   **Benefits**: Enables writing generic algorithms that work with any number type (`int`, `double`, `decimal`, or custom types).
*   **Improvements**: Previously, you couldn't use operators (`+`, `-`) on generic types `T`.
*   **Tests**: [8 - GenericMath.cs](../../CSharpStudy.Tests/CSharp11/8%20-%20GenericMath.cs)
*   **Example**:
    ```csharp
    T Add<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }
    ```

> [!NOTE]
> **Generic Math** is built on top of **Static Abstract Members in Interfaces**, which allows interfaces to define static methods and operators that implementing types must provide. This is the underlying feature that enables operator constraints on generic types.

### Required Members (`required` keyword)

#### Summary
**Required Members** enforce that specific properties or fields *must* be set during object initialization. If the caller forgets to set a required member, the compiler issues an error.

#### Motivation / When to Use
*   **Object Initializers**: Enforce mandatory fields without writing a constructor.
*   **DTOs**: Ensure data integrity for models used in serialization/deserialization.

#### Benefits
*   **Safety**: Prevents partially initialized objects.
*   **Flexibility**: Works with object initializers, unlike constructor parameters which are positional.

#### Improvements (C# specifics)
*   `required` modifier on properties/fields.
*   `[SetsRequiredMembers]` attribute for constructors that handle initialization internally.

#### Example
```csharp
public class Person
{
    public required string Name { get; init; }
    public int Age { get; set; } // Optional
}

// OK
var p1 = new Person { Name = "Alice" };

// Error: Required member 'Person.Name' must be set
// var p2 = new Person { Age = 30 }; 
```

#### Line-by-Line Explanation
*   `required string Name`: Compiler checks this property is assigned in the object initializer.

#### Tests
[3 - RequiredMembers.cs](../../CSharpStudy.Tests/CSharp11/3%20-%20RequiredMembers.cs)

#### Common Pitfalls / Gotchas
*   **Constructors**: If you have a constructor that sets the property, you must mark the constructor with `[SetsRequiredMembers]` to tell the compiler "I got this", otherwise the caller is still forced to set it.
*   **Versioning**: Adding `required` is a breaking change for consumers.

#### Best Practices / Checklist
*   Use for properties that are essential for the object's validity.
*   Prefer over constructors for DTOs with many fields.

#### Related Topics
*   Init-only properties (C# 9.0)
*   Object Initializers

### List Patterns (advanced sequence matching)

#### Summary
**List Patterns** extend pattern matching to arrays, lists, and other indexable collections. You can match against the sequence of elements, including using `..` (slice pattern) to match ranges.

#### Motivation / When to Use
*   **CSV Parsing**: Matching columns in a split string line.
*   **Validation**: Checking if a list starts/ends with specific values.
*   **Recursive Algorithms**: Processing head/tail of a list (functional style).

#### Benefits
*   **Expressive**: Concise syntax for structural validation.
*   **Recursive**: Can contain other patterns (e.g., property patterns) inside the list pattern.

#### Improvements (C# specifics)
*   Works with any type that is countable and indexable.
*   `..` (slice pattern) captures the remainder of the list.

#### Example
```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

// Match start
if (numbers is [1, 2, ..]) 
    Console.WriteLine("Starts with 1, 2");

// Match start and end, capture middle
if (numbers is [1, .. var middle, 5])
{
    Console.WriteLine($"Middle: {string.Join(",", middle)}"); // 2,3,4
}

// Recursive pattern matching
string[][] csv = { new[] { "Alice", "30" }, new[] { "Bob", "40" } };
foreach (var row in csv)
{
    if (row is [var name, var age])
        Console.WriteLine($"{name} is {age}");
}
```

#### Line-by-Line Explanation
*   `[1, 2, ..]`: Matches list starting with 1, 2, followed by anything.
*   `.. var middle`: Captures the slice into a variable.

#### Tests
[4 - ListPatterns.cs](../../CSharpStudy.Tests/CSharp11/4%20-%20ListPatterns.cs)

#### Common Pitfalls / Gotchas
*   **Count Check**: List patterns implicitly check the count. `[1, 2]` only matches a list of length 2. Use `[1, 2, ..]` for "starts with".
*   **Allocation**: Capturing a slice (`.. var x`) allocates a new array/list unless using `Span<T>`.

#### Best Practices / Checklist
*   Use for parsing and validation logic.
*   Combine with `switch` expressions for powerful data processing.

#### Related Topics
*   Pattern Matching
*   Indices and Ranges

### Generic Attributes

#### Summary
**Generic Attributes** allow you to create attribute classes that take generic type parameters. This removes the need to pass `typeof(T)` to the attribute constructor.

#### Motivation / When to Use
*   **Type Metadata**: Attributes that associate a type with a member (e.g., serializers, validators).
*   **Dependency Injection**: Registering services via attributes.

#### Benefits
*   **Cleaner Syntax**: `[Type<int>]` vs `[Type(typeof(int))]`.
*   **Type Safety**: Generic constraints apply.

#### Improvements (C# specifics)
*   Base class `Attribute` does not change, but derived classes can be generic.
*   Generic type arguments must be fully constructed (no open generics).

#### Example
```csharp
// Before C# 11
public class TypeAttribute : Attribute
{
    public TypeAttribute(Type t) { ... }
}
[Type(typeof(int))] // Verbose

// C# 11
public class GenericTypeAttribute<T> : Attribute { }

[GenericType<int>] // Clean!
public class MyClass { }

[GenericType<List<string>>] // Works with complex types
public class OtherClass { }
```

#### Line-by-Line Explanation
*   `GenericTypeAttribute<T>`: Defines the generic attribute.
*   `[GenericType<int>]`: Applies it with `int` as the type argument.

#### Tests
Verified via compiler.

#### Common Pitfalls / Gotchas
*   **Open Generics**: You cannot use open generics like `[GenericType<>]`.
*   **Constraints**: Generic constraints are enforced at compile time.

#### Best Practices / Checklist
*   Update existing attributes that take `Type` parameters to use generics if targeting .NET 7+.

#### Related Topics
*   Attributes
*   Generics

### UTF-8 String Literals

#### Summary
**UTF-8 String Literals** allow you to define a string literal that is compiled directly into a UTF-8 byte sequence (`ReadOnlySpan<byte>`) by appending the `u8` suffix.

#### Motivation / When to Use
*   **Web Protocols**: HTTP headers and bodies are often UTF-8.
*   **File I/O**: Writing text to files usually requires UTF-8 encoding.
*   **Performance**: Avoids runtime overhead of `Encoding.UTF8.GetBytes("...")`.

#### Benefits
*   **Zero Allocation**: The bytes are embedded in the DLL data section; no array allocation at runtime.
*   **Speed**: Immediate access to bytes.

#### Improvements (C# specifics)
*   Suffix `u8` turns a string literal into a `ReadOnlySpan<byte>`.

#### Example
```csharp
// Standard string (UTF-16)
string s = "Hello";

// UTF-8 bytes (ReadOnlySpan<byte>)
ReadOnlySpan<byte> utf8 = "Hello"u8;

// Usage with APIs taking Span<byte>
using var stream = new MemoryStream();
stream.Write("Hello World"u8);
```

#### Line-by-Line Explanation
*   `"Hello"u8`: Compiler emits the byte sequence `0x48, 0x65, 0x6C, 0x6C, 0x6F`.
*   `stream.Write(...)`: Writes bytes directly without encoding overhead.

#### Tests
[1 - UTF8StringLiterals.cs](../../CSharpStudy.Tests/CSharp11/1%20-%20UTF8StringLiterals.cs)

#### Common Pitfalls / Gotchas
*   **Type**: The type is `ReadOnlySpan<byte>`, NOT `byte[]` or `string`. You cannot assign it to `byte[]` directly (use `.ToArray()` if you really need an array, but that allocates).
*   **Constants**: Cannot be used as a `const` field because spans are ref structs (cannot be fields).

#### Best Practices / Checklist
*   Use `u8` literals when calling APIs that accept `ReadOnlySpan<byte>` or `byte[]` for text data.
*   Avoid `.ToArray()` if possible to maintain the zero-allocation benefit.

#### Related Topics
*   Spans (`Span<T>`, `ReadOnlySpan<T>`)
*   Character Encoding
