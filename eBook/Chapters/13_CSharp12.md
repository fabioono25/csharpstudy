# Chapter 13 --- C# 12.0: Refining Type Definitions

## Summary
Released in 2023 with .NET 8, C# 12.0 continued to refine the language syntax, making it more consistent and concise. The headlining feature was **Primary Constructors**, which allows defining constructor parameters directly on the class declaration, reducing boilerplate for dependency injection and initialization.

## Highlights & Internal Changes
*   **Collection Expressions**: A unified syntax for creating all kinds of collections (arrays, lists, spans), optimized by the compiler for performance.

## Topics

### Primary Constructors (for all classes and structs)

#### Summary
**Primary Constructors** allow you to declare constructor parameters directly on the class or struct declaration line. These parameters are available throughout the class body.

#### Motivation / When to Use
*   **Dependency Injection**: Injecting services into a controller or service class.
*   **Initialization**: Simple classes that just need to initialize fields.

#### Benefits
*   **Conciseness**: Removes the need for a manual constructor and explicit field declarations (if used directly).
*   **Consistency**: Unifies syntax with Records (though behavior differs slightly).

#### Improvements (C# specifics)
*   Unlike records, primary constructor parameters in classes are *not* automatically promoted to public properties. They are private fields/parameters.
*   Can be used to initialize properties or fields.

#### Example
```csharp
// Dependency Injection
public class UserService(ILogger<UserService> logger, IRepository repo)
{
    public void DoWork()
    {
        logger.LogInformation("Working...");
        repo.Save();
    }
}

// Initialization
public class Person(string name)
{
    public string Name { get; } = name; // Initialize property
    
    public override string ToString() => name; // Use parameter directly
}
```

#### Line-by-Line Explanation
*   `class UserService(...)`: Declares the constructor.
*   `logger.LogInformation`: Uses the captured parameter directly.

#### Tests
[2 - PrimaryConstructors.cs](../../CSharpStudy.Tests/CSharp12/2%20-%20PrimaryConstructors.cs)

#### Common Pitfalls / Gotchas
*   **Capture**: Parameters are captured as private fields if used in methods.
*   **Mutability**: Parameters are mutable. Reassigning them (`name = "Bob"`) affects their value everywhere in the class.
*   **No Properties**: Unlike `record`, `class Person(string Name)` does NOT create a `Name` property.

#### Best Practices / Checklist
*   Use for DI-heavy classes to reduce boilerplate.
*   Be careful with parameter mutability; treat them as readonly if possible.

#### Related Topics
*   Constructors
*   Records

### Collection Expressions (unified collection initialization)

#### Summary
**Collection Expressions** provide a unified, concise syntax `[...]` to create common collection types (arrays, lists, spans).

#### Motivation / When to Use
*   **Initialization**: Creating lists or arrays with initial values.
*   **Empty Collections**: `[]` is cleaner than `new List<int>()` or `Array.Empty<int>()`.
*   **Combining**: Merging collections using the spread operator `..`.

#### Benefits
*   **Readability**: Less visual noise.
*   **Performance**: Compiler optimizes the creation (e.g., pre-sizing lists, using stack allocation for spans).
*   **Flexibility**: Target type determines the implementation (List, Array, Span, etc.).

#### Improvements (C# specifics)
*   Replaces `new T[] { ... }`, `new List<T> { ... }`, etc.
*   Supports `..` spread operator to inline other collections.

#### Example
```csharp
// Array
int[] a = [1, 2, 3];

// List
List<int> b = [4, 5, 6];

// Span
Span<int> c = [7, 8, 9];

// Jagged 2D array
int[][] d = [[1, 2], [3, 4]];

// Spread operator (combining)
int[] combined = [..a, ..b]; // [1, 2, 3, 4, 5, 6]
```

#### Line-by-Line Explanation
*   `[1, 2, 3]`: Creates a collection containing 1, 2, 3.
*   `..a`: Expands the elements of `a` into the new collection.

#### Tests
[6 - CollectionExpressions.cs](../../CSharpStudy.Tests/CSharp12/6%20-%20CollectionExpressions.cs)

#### Common Pitfalls / Gotchas
*   **Type Inference**: `var x = [1, 2];` does NOT work because the compiler doesn't know if you want an array or list. You must specify the type or cast.
*   **Custom Types**: Works with custom types if they have a `[CollectionBuilder]` attribute (advanced).

#### Best Practices / Checklist
*   Use `[]` for all collection initializations where the target type is known.
*   Use `[]` instead of `Array.Empty<T>()`.

#### Related Topics
*   Arrays
*   Lists
*   Spans

### Default Parameters for Lambda Expressions

#### Summary
**Default Parameters for Lambda Expressions** allow you to specify default values for parameters in lambdas, just like in regular methods.

#### Motivation / When to Use
*   **Optional Arguments**: When a lambda is used as a callback but some arguments are optional.
*   **Flexibility**: Reducing the number of overloads needed for delegate types.

#### Benefits
*   **Parity**: Lambdas behave more like local functions or methods.
*   **Convenience**: Callers can omit arguments.

#### Improvements (C# specifics)
*   Syntax: `(int x = 10) => x * 2`.
*   Also supports `params` arrays in lambdas.

#### Example
```csharp
var log = (string msg, string level = "INFO") => Console.WriteLine($"[{level}] {msg}");

log("System started");          // [INFO] System started
log("Error occurred", "ERROR"); // [ERROR] Error occurred
```

#### Line-by-Line Explanation
*   `string level = "INFO"`: Default value if the second argument is missing.

#### Tests
[5 - DefaultLambdaParameters.cs](../../CSharpStudy.Tests/CSharp12/5%20-%20DefaultLambdaParameters.cs)

#### Common Pitfalls / Gotchas
*   **Delegate Type**: The inferred delegate type must support optional parameters (usually `Action` or `Func` do NOT, so you might need a custom delegate or rely on `var` inference which generates a custom delegate signature internally).

#### Best Practices / Checklist
*   Use when defining short, reusable callbacks locally.

#### Related Topics
*   Lambda Expressions
*   Optional Arguments

### Alias Any Type (`using` aliases)

#### Summary
**Alias Any Type** allows you to use the `using` directive to create aliases for *any* type, not just named types. This includes tuples, arrays, pointers, and other unsafe types.

#### Motivation / When to Use
*   **Tuples**: Giving semantic names to complex tuples.
*   **Arrays**: Aliasing array types for clarity.
*   **Pointers**: Aliasing pointer types in unsafe code.

#### Benefits
*   **Readability**: `Point` is easier to read than `(int X, int Y)`.
*   **Maintainability**: Change the underlying type in one place.

#### Improvements (C# specifics)
*   Removes the restriction that `using X = ...` could only target classes/structs.

#### Example
```csharp
using Point = (int X, int Y);
using Matrix = int[][];
using unsafe IntBuffer = int*;

Point p = (10, 20);
Console.WriteLine($"X: {p.X}, Y: {p.Y}");

Matrix m = [[1, 2], [3, 4]];
```

#### Line-by-Line Explanation
*   `using Point = ...`: Defines `Point` as an alias for the tuple `(int X, int Y)`.

#### Tests
[3 - AliasAnyType.cs](../../CSharpStudy.Tests/CSharp12/3%20-%20AliasAnyType.cs)

#### Common Pitfalls / Gotchas
*   **Scope**: Aliases are file-scoped (unless using `global using`).
*   **Identity**: It is a true alias, not a new type. `Point` *is* `(int, int)`. Overloading based on alias vs underlying type is not possible.

#### Best Practices / Checklist
*   Use to simplify complex type signatures, especially tuples.
*   Combine with `global using` for project-wide aliases.

#### Related Topics
*   Using Directives
*   Tuples

### Inline Arrays

#### Summary
**Inline Arrays** allow you to create fixed-size arrays inside a struct without the overhead of a separate array object. They are primarily used by the runtime and library authors for performance.

#### Motivation / When to Use
*   **Performance**: High-performance scenarios where you need a small, fixed-size buffer on the stack.
*   **Interop**: Interfacing with native code that expects fixed-size buffers.

#### Benefits
*   **Zero Allocation**: No heap allocation for the array.
*   **Safety**: Safe code (unlike `fixed` buffers which require `unsafe`).

#### Improvements (C# specifics)
*   `[InlineArray(length)]` attribute on a struct.
*   Compiler generates the necessary storage and indexer.

#### Example
```csharp
[System.Runtime.CompilerServices.InlineArray(10)]
public struct Buffer10<T>
{
    private T _element0; // Placeholder for the first element
}

// Usage
var buffer = new Buffer10<int>();
buffer[0] = 42;
buffer[9] = 100;

foreach (var item in buffer) // Can iterate!
{
    Console.WriteLine(item);
}
```

#### Line-by-Line Explanation
*   `[InlineArray(10)]`: Tells the compiler this struct behaves like an array of size 10.
*   `private T _element0`: Required single field to define the element type.

#### Tests
[4 - InlineArrays.cs](../../CSharpStudy.Tests/CSharp12/4%20-%20InlineArrays.cs)

#### Common Pitfalls / Gotchas
*   **Advanced Feature**: Most developers won't need to define these. They are used by `Span<T>` and other types internally.
*   **Struct Semantics**: It's a struct, so passing it by value copies the entire array. Pass by `ref` or `in` to avoid copying.

#### Best Practices / Checklist
*   Use only for low-level performance optimization.
*   Prefer `Span<T>` for general usage.

#### Related Topics
*   Structs
*   Span<T>

### Spread Element (`..`)

#### Summary
The **Spread Element** (`..`) allows you to expand a collection into another collection expression. It replaces the need for `AddRange` or `Concat`.

#### Motivation / When to Use
*   **Merging**: Combining two lists or arrays.
*   **Slicing**: Taking a slice of an array and adding it to another.

#### Benefits
*   **Concise**: `[..a, ..b]` vs `a.Concat(b).ToArray()`.
*   **Efficient**: Compiler optimizes the copy operation.

#### Improvements (C# specifics)
*   Works inside `[...]` collection expressions.
*   Works with any enumerable type.

#### Example
```csharp
int[] first = [1, 2, 3];
int[] second = [4, 5, 6];

// Combine
int[] all = [..first, ..second]; // [1, 2, 3, 4, 5, 6]

// With literal elements
int[] more = [0, ..first, 100]; // [0, 1, 2, 3, 100]
```

#### Line-by-Line Explanation
*   `..first`: Expands elements of `first` into the new array.

#### Tests
Included in [6 - CollectionExpressions.cs](../../CSharpStudy.Tests/CSharp12/6%20-%20CollectionExpressions.cs)

#### Common Pitfalls / Gotchas
*   **Null**: Spreading `null` throws a `NullReferenceException` at runtime (unless the collection type handles it, but standard ones don't).

#### Best Practices / Checklist
*   Use for flattening collections.

#### Related Topics
*   Collection Expressions
*   Ranges

### Experimental Attribute

#### Summary
The `[Experimental]` attribute marks types, members, or assemblies as experimental. Using them produces a compiler warning that must be explicitly suppressed.

#### Motivation / When to Use
*   **Preview Features**: Shipping a library with features that are not yet stable.
*   **Feedback**: Encouraging users to try a feature while warning them it might change.

#### Benefits
*   **Safety**: Users can't accidentally depend on unstable APIs.
*   **Control**: Library authors can break experimental APIs without violating semantic versioning rules (technically).

#### Improvements (C# specifics)
*   Requires a diagnostic ID (e.g., "MyLib001") so users can suppress specific warnings.

#### Example
```csharp
using System.Diagnostics.CodeAnalysis;

[Experimental("WIDGET001")]
public class NewWidget
{
    public void Draw() { }
}

// Usage
#pragma warning disable WIDGET001
var w = new NewWidget(); // Warning suppressed
#pragma warning restore WIDGET001
```

#### Line-by-Line Explanation
*   `[Experimental("...")]`: Marks the class. Any usage triggers the specific warning ID.

#### Tests
Verified via compiler diagnostics.

#### Common Pitfalls / Gotchas
*   **Suppression**: Users *must* suppress the warning to build (if warnings as errors is on).

#### Best Practices / Checklist
*   Use for public APIs that are likely to change.
*   Document the diagnostic ID clearly.

#### Related Topics
*   Obsolete Attribute
*   Attributes

### Interceptors (Preview)

#### Summary
**Interceptors** allow a method call to be rerouted to a different method at compile time. This is an advanced, low-level feature primarily for source generators to optimize code (e.g., AOT compilation).

#### Motivation / When to Use
*   **AOT (Ahead-of-Time)**: Replacing reflection-based calls (like `MapGet` in ASP.NET Core) with static code generation.
*   **Optimization**: Specializing generic methods for specific types.

#### Benefits
*   **Performance**: Removes runtime overhead of dynamic dispatch or reflection.
*   **Trimming**: Helps the linker remove unused code.

#### Improvements (C# specifics)
*   Uses `[InterceptsLocation]` attribute to target specific source lines.
*   **Experimental**: Subject to change in future versions.

#### Example
```csharp
// User code
var app = WebApplication.Create();
app.MapGet("/", () => "Hello"); // Compiler rewrites this call!

// Generated code (Interceptor)
static class GeneratedInterceptors
{
    [InterceptsLocation("Program.cs", line: 2, character: 5)]
    public static void MapGetInterceptor(...) 
    {
        // Optimized implementation
    }
}
```

#### Line-by-Line Explanation
*   `[InterceptsLocation]`: Tells the compiler "When you see a call at this file/line, call ME instead".

#### Tests
Verified via ASP.NET Core 8+ internals (not easily testable in user code without setup).

#### Common Pitfalls / Gotchas
*   **Fragile**: Relies on file paths and line numbers. Editing the file breaks the interception if the generator doesn't run again.
*   **Preview**: Do not use in application code directly; rely on frameworks (like ASP.NET Core) to use it.

#### Best Practices / Checklist
*   **Don't use manually**. This is for tool authors.

#### Related Topics
*   Source Generators
*   AOT Compilation
