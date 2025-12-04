# Chapter 9 --- C# 8.0: Nullable Reference Types

## Summary
Released in 2019 with .NET Core 3.0, C# 8.0 was a landmark release that addressed one of the biggest sources of runtime errors: the `NullReferenceException`. It introduced **Nullable Reference Types (NRTs)**, a feature that allows the compiler to enforce null safety for reference types, similar to how it works for value types.

## Highlights & Internal Changes
*   **Nullable Context**: The compiler analyzes the flow of code to determine the "null-state" of variables and warns about potential null dereferences.
*   **Interface Evolution**: Interfaces can now have implementation (default methods), bringing them closer to abstract classes but with multiple inheritance of behavior.

## Topics

### Nullable Reference Types (`string?`)

#### Summary
**Nullable Reference Types (NRTs)** allow you to explicitly state whether a reference type variable can hold `null`. This helps the compiler enforce null safety and prevent `NullReferenceException`.

#### Motivation / When to Use
*   **Prevent Crashes**: Catch null dereferences at compile time.
*   **API Clarity**: Signatures clearly indicate if null is accepted/returned.
*   **Domain Modeling**: Distinguish optional vs. required data.

#### Benefits
*   **Safety**: Compiler warns about unsafe access.
*   **Documentation**: Code intent is self-documenting.

#### Improvements (C# specifics)
*   Enabled via `<Nullable>enable</Nullable>` in csproj.
*   `T?` for nullable, `T` for non-nullable.
*   `!` (null-forgiving operator) to suppress warnings.

#### Example
```csharp
#nullable enable

public void ProcessUser(string name, string? nickname)
{
    Console.WriteLine(name.Length); // Safe
    
    // Console.WriteLine(nickname.Length); // Warning: Possible null reference
    
    if (nickname != null)
    {
        Console.WriteLine(nickname.Length); // Safe (flow analysis)
    }
}
```

#### Line-by-Line Explanation
*   `string name`: Non-nullable. Compiler ensures it's not null.
*   `string? nickname`: Nullable. Compiler forces a check before access.

#### Tests
[1 - NullableRefTypes.cs](../../CSharpStudy.Tests/CSharp8/1%20-%20NullableRefTypes.cs)

#### Common Pitfalls / Gotchas
*   **Warnings, not Errors**: By default, these are warnings (unless treated as errors).
*   **Legacy Code**: Interacting with non-nullable aware code requires care.

#### Best Practices / Checklist
*   Enable NRTs in all new projects.
*   Use `?` for optional values.
*   Avoid `!` unless absolutely necessary.

#### Related Topics
*   Nullable Value Types (C# 2.0)
*   Null-conditional operator (`?.`)

### Default Interface Methods

#### Summary
**Default Interface Methods** allow interfaces to provide concrete implementations for members. This enables adding new members to interfaces without breaking existing implementing classes.

#### Motivation / When to Use
*   **API Evolution**: Add methods to published interfaces safely.
*   **Traits/Mixins**: Provide shared behavior across unrelated classes.
*   **Android/iOS Interop**: Better support for Java/Swift interface features.

#### Benefits
*   **Backward Compatibility**: Existing classes don't need to change.
*   **Code Reuse**: Shared logic in the interface itself.

#### Improvements (C# specifics)
*   Interfaces can have `static` members, `private` members, and `virtual` implementations.
*   Diamond problem resolved by most specific override rule.

#### Example
```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default implementation
    void LogError(string error) => Log($"[Error] {error}");
}

class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
    // LogError is optional to implement
}
```

#### Line-by-Line Explanation
*   `void LogError(...) => ...`: Provides a default body.
*   `ConsoleLogger` inherits this implementation automatically.

#### Tests
[4 - DefaultInterfaceMethods.cs](../../CSharpStudy.Tests/CSharp8/4%20-%20DefaultInterfaceMethods.cs)

#### Common Pitfalls / Gotchas
*   **State**: Interfaces still cannot have instance fields (state).
*   **Diamond Problem**: Multiple interfaces with same default method require explicit override in class.

#### Best Practices / Checklist
*   Use primarily for evolving published APIs.
*   Prefer abstract base classes if state is needed.

#### Related Topics
*   Interfaces
*   Abstract Classes

### Switch Expressions

#### Summary
**Switch Expressions** provide a concise, expression-based syntax for pattern matching. They return a value and are often used in expression-bodied members.

#### Motivation / When to Use
*   **Mapping**: Convert enums/types to strings or other values.
*   **State Machines**: Transition logic based on current state.
*   **Conciseness**: Replace verbose `switch` statements.

#### Benefits
*   **Exhaustiveness**: Compiler warns if not all cases are handled.
*   **Concise**: No `case`, `break`, or `return` keywords needed.

#### Improvements (C# specifics)
*   Uses `=>` syntax.
*   Can be used anywhere an expression is valid.

#### Example
```csharp
public string GetDescription(State state) => state switch
{
    State.Running => "System is running",
    State.Stopped => "System is stopped",
    State.Error   => "System error",
    _             => "Unknown state"
};
```

#### Line-by-Line Explanation
*   `state switch { ... }`: The switch expression.
*   `State.Running => ...`: Pattern and result.
*   `_ =>`: Discard pattern (default case).

#### Tests
[5 - PatternMatchingExpressions.cs](../../CSharpStudy.Tests/CSharp8/5%20-%20PatternMatchingExpressions.cs)

#### Common Pitfalls / Gotchas
*   **Exceptions**: Throws `SwitchExpressionException` at runtime if no case matches (unlike switch statement which does nothing).
*   **Exhaustiveness**: Always include a catch-all `_` if inputs are unbounded.

#### Best Practices / Checklist
*   Use for returning values.
*   Ensure all possible cases are covered.

#### Related Topics
*   Pattern Matching
*   Switch Statements

### `using` declarations (scoped)

#### Summary
**Using declarations** allow you to declare a disposable variable that is automatically disposed at the end of the current scope (usually the method), without the indentation of a `using` block.

#### Motivation / When to Use
*   **File I/O**: Reading/writing files.
*   **Database Connections**: Managing SQL connections.
*   **HTTP Responses**: Disposing response streams.

#### Benefits
*   **Readability**: Reduces "rightward drift" (nesting).
*   **Concise**: Looks like a normal variable declaration.

#### Improvements (C# specifics)
*   Disposal happens at end of scope (closing brace).
*   Can be mixed with regular variables.

#### Example
```csharp
public void ReadFile(string path)
{
    using var reader = new StreamReader(path);
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
} // reader.Dispose() called here
```

#### Line-by-Line Explanation
*   `using var reader`: Declares variable and schedules Dispose.
*   Scope ends at `}`, triggering disposal.

#### Tests
[6 - UsingDeclarations.cs](../../CSharpStudy.Tests/CSharp8/6%20-%20UsingDeclarations.cs)

#### Common Pitfalls / Gotchas
*   **Scope Lifetime**: If you need to dispose *before* end of method, use a block `using (...) { }`.
*   **Structs**: Works with `ref struct` types like `Span<T>` (if they are disposable).

#### Best Practices / Checklist
*   Prefer over `using` blocks for simple linear code.
*   Be aware of when the scope ends.

#### Related Topics
*   IDisposable
*   Disposable Ref Structs

### Asynchronous Streams (`IAsyncEnumerable<T>`)

#### Summary
**Async Streams** allow you to iterate over a collection of data that is retrieved asynchronously, item by item. It combines `IEnumerable<T>` (lazy iteration) with `Task<T>` (asynchrony).

#### Motivation / When to Use
*   **Paginated APIs**: Fetch pages of data one by one.
*   **IoT Streams**: Process sensor data as it arrives.
*   **Large Files**: Read lines asynchronously without loading all into memory.

#### Benefits
*   **Responsiveness**: Process items immediately as they arrive.
*   **Memory Efficiency**: No need to buffer the entire collection.

#### Improvements (C# specifics)
*   `await foreach`: Consumes the stream.
*   `yield return`: Produces items in an async method.
*   Cancellation support via `[EnumeratorCancellation]`.

#### Example
```csharp
public async IAsyncEnumerable<int> GenerateSequenceAsync()
{
    for (int i = 0; i < 3; i++)
    {
        await Task.Delay(100); // Simulate async work
        yield return i;
    }
}

// Consumer
await foreach (var number in GenerateSequenceAsync())
{
    Console.WriteLine(number);
}
```

#### Line-by-Line Explanation
*   `IAsyncEnumerable<int>`: Return type for async iterator.
*   `await foreach`: Awaits the next item before entering loop body.

#### Tests
[2 - AsyncStream.cs](../../CSharpStudy.Tests/CSharp8/2%20-%20AsyncStream.cs)

#### Common Pitfalls / Gotchas
*   **Cancellation**: Must pass `CancellationToken` to `GetAsyncEnumerator` or use `WithCancellation`.
*   **Buffering**: LINQ operators like `ToList()` will buffer everything, defeating the purpose.

#### Best Practices / Checklist
*   Use `[EnumeratorCancellation]` attribute on token parameter.
*   Use `System.Linq.Async` (NuGet) for LINQ operators on async streams.

#### Related Topics
*   Iterators (yield)
*   async/await

### Indices and Ranges

#### Summary
**Indices** (`^`) and **Ranges** (`..`) provide a concise syntax for accessing elements relative to the end of a collection and for slicing collections.

#### Motivation / When to Use
*   **Last Element**: `arr[^1]` instead of `arr[arr.Length - 1]`.
*   **Slicing**: `arr[1..^1]` to get everything except first and last.
*   **Substrings**: `str[0..5]` for first 5 characters.

#### Benefits
*   **Readability**: Cleaner, less error-prone math.
*   **Consistency**: Works with Arrays, Strings, `Span<T>`, `List<T>`.

#### Improvements (C# specifics)
*   `Index` type: `^1` creates a `System.Index`.
*   `Range` type: `1..3` creates a `System.Range`.
*   Compiler optimizes to efficient offset calculations.

#### Example
```csharp
string[] words = { "The", "quick", "brown", "fox" };

string last = words[^1];      // "fox"
string[] middle = words[1..3]; // { "quick", "brown" }
string[] all = words[..];     // Copy of array
```

#### Line-by-Line Explanation
*   `^1`: "1 from the end". `^0` is length (out of bounds).
*   `1..3`: Start at index 1 (inclusive), end at index 3 (exclusive).

#### Tests
[3 - IndexRangeTypes.cs](../../CSharpStudy.Tests/CSharp8/3%20-%20IndexRangeTypes.cs)

#### Common Pitfalls / Gotchas
*   **Exclusive End**: Range end is *exclusive*. `[0..2]` gives elements 0 and 1.
*   **`^0`**: Is equivalent to `Length`. Accessing `[^0]` throws `IndexOutOfRangeException`.

#### Best Practices / Checklist
*   Use `^` for end-relative access.
*   Use `..` for slicing spans and arrays.

#### Related Topics
*   Span<T>
*   Arrays

### Null-coalescing assignment (`??=`)

#### Summary
The **null-coalescing assignment operator** (`??=`) assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand is `null`.

#### Motivation / When to Use
*   **Lazy Initialization**: Initialize a field only when it's accessed.
*   **Default Values**: Assign defaults to null parameters/variables.

#### Benefits
*   **Concise**: Replaces `if (x == null) x = y;`.
*   **Atomic**: Evaluates left side only once.

#### Example
```csharp
List<int>? numbers = null;

// Initialize if null
numbers ??= new List<int>();
numbers.Add(1);

// Lazy property pattern
private List<string>? _cache;
public List<string> Cache => _cache ??= LoadCache();
```

#### Line-by-Line Explanation
*   `numbers ??= ...`: If `numbers` is null, create list and assign. If not null, do nothing.

#### Tests
[9 - NullCoalescingAssignment.cs](../../CSharpStudy.Tests/CSharp8/9%20-%20NullCoalescingAssignment.cs)

#### Related Topics
*   Null-coalescing operator (`??`)
*   Nullable Reference Types

### Static Local Functions

#### Summary
**Static Local Functions** are local functions marked with `static`. They cannot capture local variables or instance state from the enclosing scope.

#### Motivation / When to Use
*   **Performance**: Prevent accidental closures (delegate allocation).
*   **Clarity**: Explicitly state that the function is pure/isolated.

#### Benefits
*   **No Allocation**: Guaranteed to not allocate a closure class.
*   **Safety**: Compiler prevents accidental access to outer variables.

#### Improvements (C# specifics)
*   Extension of C# 7.0 local functions.
*   Can still access static members of the class.

#### Example
```csharp
int Calculate(int x)
{
    int y = 10;
    return Add(x, 20); // Can pass arguments
    
    // static ensures 'y' cannot be accessed here
    static int Add(int a, int b) => a + b; 
}
```

#### Line-by-Line Explanation
*   `static int Add`: Declares function as static.
*   Accessing `y` inside `Add` would cause a compile error.

#### Tests
[7 - StaticLocalFunctions.cs](../../CSharpStudy.Tests/CSharp8/7%20-%20StaticLocalFunctions.cs)

#### Best Practices / Checklist
*   Make local functions `static` by default.
*   Remove `static` only if you explicitly need to capture variables.

#### Related Topics
*   Local Functions (C# 7.0)

### Readonly Members

#### Summary
**Readonly Members** allow you to apply the `readonly` modifier to individual members (methods, properties) of a `struct`. This indicates that the member does not modify the struct's state.

#### Motivation / When to Use
*   **Performance**: Allows compiler to avoid defensive copies of `in` parameters or `readonly` fields.
*   **Design**: Enforce immutability at the member level.

#### Benefits
*   **Optimization**: Compiler knows it's safe to pass by reference without copying.
*   **Safety**: Compiler prevents accidental modification of `this`.

#### Improvements (C# specifics)
*   Can be applied to methods, properties, and indexers.
*   If the member tries to modify state, compiler throws error.

#### Example
```csharp
public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
    
    // This method guarantees it won't change X or Y
    public readonly double Distance => Math.Sqrt(X * X + Y * Y);
    
    public readonly override string ToString() => $"({X}, {Y})";
    
    public void Move(double x, double y) // Not readonly
    {
        X += x;
        Y += y;
    }
}
```

#### Line-by-Line Explanation
*   `public readonly double Distance`: Property getter is readonly.
*   Accessing `Distance` on a `readonly Point` variable is efficient (no copy).

#### Tests
Conceptual feature; verified by compiler.

#### Common Pitfalls / Gotchas
*   **Defensive Copies**: Calling a *non-readonly* member on a *readonly* struct variable causes a hidden copy (performance hit). Marking members `readonly` prevents this.

#### Best Practices / Checklist
*   Mark all non-mutating members of a struct as `readonly`.
*   Consider `readonly struct` if the entire type is immutable.

#### Related Topics
*   Structs
*   Readonly Structs (C# 7.2)

### Disposable Ref Structs

#### Summary
**Disposable Ref Structs** allow `ref struct` types (like `Span<T>`) to be disposable by implementing a `public void Dispose()` method. They cannot implement the `IDisposable` interface because interfaces are reference types (boxing).

#### Motivation / When to Use
*   **Resource Management**: Managing native memory or handles in high-performance code.
*   **Scoped Lifetime**: Ensuring cleanup happens deterministically on the stack.

#### Benefits
*   **No Boxing**: Avoids boxing `ref struct` to `IDisposable`.
*   **Stack-Only**: Guaranteed to not escape to the heap.

#### Improvements (C# specifics)
*   Compiler looks for a `Dispose` method via duck typing (pattern-based).
*   Enables `using` statement for ref structs.

#### Example
```csharp
public ref struct NativeBuffer
{
    private IntPtr _pointer;
    
    public NativeBuffer(int size)
    {
        _pointer = Marshal.AllocHGlobal(size);
    }
    
    public void Dispose()
    {
        if (_pointer != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(_pointer);
            _pointer = IntPtr.Zero;
        }
    }
}

// Usage
using var buffer = new NativeBuffer(1024);
// buffer.Dispose() called automatically
```

#### Line-by-Line Explanation
*   `ref struct`: Stack-only type.
*   `public void Dispose()`: The method compiler looks for.
*   `using var`: Works because `Dispose` exists.

#### Tests
[8 - DisposableRefStructs.cs](../../CSharpStudy.Tests/CSharp8/8%20-%20DisposableRefStructs.cs)

#### Common Pitfalls / Gotchas
*   **No Interface**: You cannot cast to `IDisposable`.
*   **Stack Only**: Cannot be fields in classes or used in async methods (across awaits).

#### Related Topics
*   Ref Structs (C# 7.2)
*   Span<T>
