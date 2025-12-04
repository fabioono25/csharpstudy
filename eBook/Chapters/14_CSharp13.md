# Chapter 14 --- C# 13.0: Advanced Performance Features

## Summary
Released in late 2024 with .NET 9, C# 13.0 focused on low-level performance and flexibility. It expanded the capabilities of `ref` structs, improved `params` collections, and introduced better concurrency primitives with the new `Lock` type.

## Highlights & Internal Changes
*   **New Lock Type**: Introduces `System.Threading.Lock` for more efficient synchronization than traditional Monitor-based locking.

## Topics

### Advanced `ref` features

#### Summary
**Advanced ref features** in C# 13 allow `ref struct` types to be used in generic arguments (with the `allows ref struct` constraint) and to implement interfaces. This removes many previous restrictions on high-performance types like `Span<T>`.

#### Motivation / When to Use
*   **Generic Algorithms**: Writing generic methods that can accept `Span<T>`.
*   **Abstraction**: Making `ref struct` types implement interfaces like `IDisposable` or `IEnumerable<T>`.

#### Benefits
*   **Flexibility**: Use spans in more places.
*   **Performance**: Avoid boxing even when using interfaces (due to special handling).

#### Improvements (C# specifics)
*   `where T : allows ref struct` constraint.
*   `ref struct` can now implement interfaces.

#### Example
```csharp
// Interface implementation
public ref struct Buffer : IDisposable
{
    public void Dispose() { /* ... */ }
}

// Generic method accepting ref struct
void Process<T>(T value) where T : allows ref struct
{
    // ...
}

Span<int> span = [1, 2, 3];
Process(span); // Now allowed!
```

#### Line-by-Line Explanation
*   `allows ref struct`: Opts in to allowing `ref struct` types, which implies the method must follow strict scoping rules.

#### Tests
[2 - RefStructInterfaces.cs](../../CSharpStudy.Tests/CSharp13/2%20-%20RefStructInterfaces.cs)

#### Common Pitfalls / Gotchas
*   **Boxing**: Casting a `ref struct` to an interface usually boxes it, which is illegal for `ref struct`. C# 13 handles this specially for generic constraints, but direct casting might still be restricted or tricky.

#### Best Practices / Checklist
*   Use `allows ref struct` when your generic method doesn't need to heap-allocate the value.

#### Related Topics
*   Ref Structs
*   Span<T>

### Stack Allocation Improvements

#### Summary
**Stack Allocation Improvements** allow `stackalloc` to be used in more contexts, particularly with collection expressions and implicit types, making stack-based arrays safer and easier to use.

#### Motivation / When to Use
*   **Performance**: Allocating temporary buffers on the stack (zero GC pressure).
*   **Interop**: Passing buffers to native APIs.

#### Benefits
*   **Safety**: Compiler ensures stack pointers don't escape their scope.
*   **Ease of Use**: Can often use `Span<T>` instead of `int*`.

#### Improvements (C# specifics)
*   Can use `stackalloc` in collection expressions: `Span<int> x = stackalloc[] { 1, 2, 3 };` (or just `[1, 2, 3]` if target is Span).

#### Example
```csharp
// Implicit stack allocation via collection expression
Span<int> numbers = [1, 2, 3, 4, 5];

// Explicit stackalloc
Span<byte> buffer = stackalloc byte[1024];
```

#### Line-by-Line Explanation
*   `Span<int> numbers = [...]`: The compiler sees the target is `Span` and allocates the array on the stack automatically.

#### Tests
Verified via compiler behavior.

#### Common Pitfalls / Gotchas
*   **Stack Overflow**: Allocating too much on the stack (e.g., inside a loop or recursion) will crash the app.
*   **Scope**: You cannot return a stack-allocated span from a method.

#### Best Practices / Checklist
*   Use for small, short-lived buffers.
*   Prefer `Span<T>` over unsafe pointers.

#### Related Topics
*   Stackalloc
*   Span<T>

### params Collections

#### Summary
**params Collections** extend the `params` keyword to support any collection type that can be initialized with a collection expression, not just arrays.

#### Motivation / When to Use
*   **Performance**: Avoid allocating an array when passing arguments.
*   **Flexibility**: Accept `ReadOnlySpan<T>`, `List<T>`, or `IEnumerable<T>` directly.

#### Benefits
*   **Zero Allocation**: `params ReadOnlySpan<T>` allows passing arguments without any heap allocation.
*   **Convenience**: Callers can pass a comma-separated list, and the compiler handles the rest.

#### Improvements (C# specifics)
*   Previously `params` only worked with `T[]`.
*   Now works with `Span<T>`, `ReadOnlySpan<T>`, `List<T>`, `IEnumerable<T>`, etc.

#### Example
```csharp
// Zero-allocation params!
void Log(params ReadOnlySpan<string> messages)
{
    foreach (var msg in messages) Console.WriteLine(msg);
}

Log("Hello", "World"); // Compiler creates a span on the stack (if possible)
```

#### Line-by-Line Explanation
*   `params ReadOnlySpan<string>`: The compiler constructs the span from the arguments.

#### Tests
[1 - ParamsCollections.cs](../../CSharpStudy.Tests/CSharp13/1%20-%20ParamsCollections.cs)

#### Common Pitfalls / Gotchas
*   **Overloads**: Be careful with ambiguity between `params T[]` and `params ReadOnlySpan<T>`. The compiler usually prefers the span version for performance.

#### Best Practices / Checklist
*   Prefer `params ReadOnlySpan<T>` for high-performance logging or processing methods.
*   Use `params IEnumerable<T>` for maximum flexibility if allocation isn't a concern.

#### Related Topics
*   Params
*   Collection Expressions

### New Locking Object (`System.Threading.Lock`)

#### Summary
**System.Threading.Lock** is a new, dedicated type for mutual exclusion. It provides a more efficient alternative to locking on arbitrary objects (`Monitor.Enter`).

#### Motivation / When to Use
*   **Concurrency**: Protecting shared resources in multi-threaded code.
*   **Performance**: Reducing the overhead of locking in high-throughput applications.

#### Benefits
*   **Efficiency**: Uses a lightweight implementation compared to the object header lock used by `Monitor`.
*   **Safety**: The `Lock` object cannot be used for other purposes (like `Wait`/`Pulse`), reducing misuse.

#### Improvements (C# specifics)
*   The `lock` statement recognizes `System.Threading.Lock` and generates optimized code (using `Lock.EnterScope`).

#### Example
```csharp
public class Cache
{
    // New dedicated lock type
    private readonly System.Threading.Lock _syncRoot = new();
    private readonly Dictionary<int, string> _data = new();

    public void Add(int key, string value)
    {
        // Compiler uses _syncRoot.EnterScope()
        lock (_syncRoot)
        {
            _data[key] = value;
        }
    }
}
```

#### Line-by-Line Explanation
*   `new System.Threading.Lock()`: Creates the lock instance.
*   `lock (_syncRoot)`: Enters the critical section.

#### Tests
[3 - NewLockingObject.cs](../../CSharpStudy.Tests/CSharp13/3%20-%20NewLockingObject.cs)

#### Common Pitfalls / Gotchas
*   **Compatibility**: `System.Threading.Lock` is a .NET 9+ feature.
*   **Mixing**: Do not mix `lock (obj)` and `lock (myLock)` for the same resource.

#### Best Practices / Checklist
*   Use `System.Threading.Lock` for all new locking requirements in .NET 9+.
*   Replace `private readonly object _lock = new();` with `private readonly Lock _lock = new();`.

#### Related Topics
*   Thread Synchronization
*   Monitor Class

### Overload Resolution Priority

#### Summary
The `[OverloadResolutionPriority]` attribute allows API authors to explicitly tell the compiler which overload to prefer when multiple overloads match the arguments.

#### Motivation / When to Use
*   **Performance**: Preferring a `ReadOnlySpan<T>` overload over an `IEnumerable<T>` overload to avoid allocation.
*   **Evolution**: Introducing a new, better overload without breaking existing code that recompiles.

#### Benefits
*   **Control**: Resolves ambiguity without forcing the user to cast arguments.
*   **Optimization**: Automatically guides users to the faster API.

#### Improvements (C# specifics)
*   Higher priority number wins.
*   Resolves "betterness" when standard rules consider two overloads equally good.

#### Example
```csharp
using System.Runtime.CompilerServices;

public class DataProcessor
{
    // Prefer this one (Priority 1)
    [OverloadResolutionPriority(1)]
    public void Process(ReadOnlySpan<int> data) 
    {
        Console.WriteLine("Processing Span (Fast)");
    }

    // Fallback (Priority 0 - default)
    public void Process(int[] data) 
    {
        Console.WriteLine("Processing Array");
    }
}

// Usage
var processor = new DataProcessor();
int[] array = [1, 2, 3];
processor.Process(array); // Calls Span version because of priority!
```

#### Line-by-Line Explanation
*   `[OverloadResolutionPriority(1)]`: Gives this method higher precedence.
*   `processor.Process(array)`: Normally `int[]` matches `int[]` better than `ReadOnlySpan<int>`, but the attribute overrides this.

#### Tests
[4 - OverloadResolutionPriority.cs](../../CSharpStudy.Tests/CSharp13/4%20-%20OverloadResolutionPriority.cs)

#### Common Pitfalls / Gotchas
*   **Binary Compatibility**: This affects *compilation*. Existing compiled binaries won't switch overloads until recompiled.
*   **Confusion**: Can make it confusing why a specific method is chosen if the attribute isn't visible in the documentation.

#### Best Practices / Checklist
*   Use when adding a `Span`-based overload to an existing API.
*   Set priority higher for the modern/faster overload.

#### Related Topics
*   Overloading
*   Span<T>

### Implicit Index Access in Initializers

#### Summary
**Implicit Index Access** allows you to use the "from-end" index operator (`^`) inside object initializers for collections.

#### Motivation / When to Use
*   **Initialization**: Setting the last element of a collection during initialization.
*   **Readability**: `[^1] = val` is clearer than `[Length - 1] = val`.

#### Benefits
*   **Consistency**: Brings the `^` operator (available in indexers) to initializers.
*   **Conciseness**: Removes the need to know the length explicitly.

#### Improvements (C# specifics)
*   Works in `new T { [^1] = ... }`.

#### Example
```csharp
public class Buffer
{
    public int[] Data { get; } = new int[10];
}

var b = new Buffer
{
    Data = 
    { 
        [0] = 1,      // First
        [^1] = 99     // Last (Data[Data.Length - 1])
    }
};
```

#### Line-by-Line Explanation
*   `[^1]`: Accesses the last element.

#### Tests
Verified via compiler.

#### Common Pitfalls / Gotchas
*   **Supported Types**: The collection must support `Length` or `Count` and an indexer.

#### Best Practices / Checklist
*   Use whenever you need to initialize elements relative to the end of the collection.

#### Related Topics
*   Indices and Ranges
*   Object Initializers
