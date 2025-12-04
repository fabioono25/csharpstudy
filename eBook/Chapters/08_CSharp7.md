# Chapter 8 --- C# 7.0: Data & Pattern Matching

## Summary
Released in 2017 with Visual Studio 2017, C# 7.0 focused on data consumption, code simplification, and performance. It introduced powerful features for working with data structures, such as lightweight Tuples and the beginning of Pattern Matching, which would become a major theme in subsequent versions.

## Highlights & Internal Changes
*   **ValueTuple**: A new underlying type (`System.ValueTuple`) that made tuples lightweight value types, solving the performance issues of the old `System.Tuple` (which was a reference type).
*   **Pattern Matching Support**: The compiler began supporting pattern matching constructs, enabling more expressive control flow.

## Topics

### Tuples & Deconstruction

#### Summary
**Tuples** provide a lightweight syntax to group multiple values. **Deconstruction** unpacks tuple elements into separate variables. `ValueTuple` is a value type, avoiding heap allocations.

#### Motivation / When to Use
*   **Multiple Returns**: Return several values without `out` parameters.
*   **Temporary Grouping**: Quick data structures without defining classes.
*   **LINQ Projections**: Select multiple fields.

#### Benefits
*   **Efficiency**: Value type (stack-allocated).
*   **Named Elements**: `(string Name, int Age)` instead of `Item1`, `Item2`.

#### Improvements (C# specifics)
*   Replaces `System.Tuple<>` (reference type).
*   Deconstruction works with custom types via `Deconstruct` method.

#### Example
```csharp
// Named tuple return
(string Name, int Age) GetPerson() => ("Alice", 30);

var person = GetPerson();
Console.WriteLine(person.Name); // Alice

// Deconstruction
var (name, age) = GetPerson();
Console.WriteLine($"{name} is {age}");
```

#### Line-by-Line Explanation
*   `(string Name, int Age)`: Named tuple elements.
*   `var (name, age)`: Deconstructs into two variables.

#### Tests
[3 - Tuples.cs](../../CSharpStudy.Tests/CSharp7/3%20-%20Tuples.cs)

#### Common Pitfalls / Gotchas
*   **Naming**: Names are compile-time only; at runtime they're `Item1`, `Item2`.
*   **Equality**: Tuples compare by value.

#### Best Practices / Checklist
*   Use named elements for clarity.
*   Consider records (C# 9.0) for complex data.

#### Related Topics
*   Records (C# 9.0)
*   `Deconstruct` method

### Initial Pattern Matching (`is` and `switch` patterns)

#### Summary
**Pattern Matching** allows testing expressions against patterns (type, constant, null) and extracting data. C# 7.0 introduced type patterns in `is` expressions and `switch` statements.

#### Motivation / When to Use
*   **Type Checking**: Replace `as` + null check with `is Type variable`.
*   **Polymorphic Dispatch**: Handle different types in `switch`.
*   **Null Handling**: Pattern match on `null`.

#### Benefits
*   **Concise**: Combines type check and cast in one expression.
*   **Safe**: Variable is in scope only when pattern matches.

#### Improvements (C# specifics)
*   Type patterns: `is string s`
*   `switch` on any type (not just constants).
*   `when` guards in `switch`.

#### Example
```csharp
object obj = "Hello";

// is pattern
if (obj is string s)
{
    Console.WriteLine(s.ToUpper()); // HELLO
}

// switch pattern
string result = obj switch
{
    int i => $"Integer: {i}",
    string s => $"String: {s}",
    null => "Null value",
    _ => "Unknown"
};
```

#### Line-by-Line Explanation
*   `is string s`: If `obj` is a string, assigns it to `s`.
*   `_ =>`: Discard pattern, matches anything.

#### Tests
[2 - PatternMatching.cs](../../CSharpStudy.Tests/CSharp7/2%20-%20PatternMatching.cs)

#### Common Pitfalls / Gotchas
*   **Scope**: Pattern variable `s` is in scope after `is` even if false (but definitely assigned only when true).
*   **Order in switch**: More specific patterns should come first.

#### Best Practices / Checklist
*   Use `is` for simple type checks.
*   Use switch expressions (C# 8.0) for complex branching.

#### Related Topics
*   Switch Expressions (C# 8.0)
*   Property Patterns (C# 8.0)

### Discards (`_`)

#### Summary
**Discards** use `_` as a placeholder for values you intentionally ignore. Useful with tuples, out parameters, and pattern matching.

#### Motivation / When to Use
*   **Tuple Deconstruction**: Ignore unwanted elements.
*   **Out Parameters**: Ignore output you don't need.
*   **Pattern Matching**: Default case in switch.

#### Benefits
*   **Intent**: Signals deliberate ignoring.
*   **No Allocation**: `_` isn't a real variable.

#### Improvements (C# specifics)
*   Works anywhere a variable would be assigned.
*   Multiple `_` discards can appear in same statement.

#### Example
```csharp
// Ignore tuple element
var (_, age) = GetPerson();

// Ignore out parameter
if (dict.TryGetValue(key, out _))
    Console.WriteLine("Key exists");

// Pattern matching
var result = obj switch
{
    int i => i * 2,
    _ => 0 // Default case
};
```

#### Tests
[1 - OutVariables.cs](../../CSharpStudy.Tests/CSharp7/1%20-%20OutVariables.cs)

#### Common Pitfalls / Gotchas
*   **Not a variable**: Cannot read from `_`.
*   **Shadowing**: A variable named `_` takes precedence.

#### Related Topics
*   Tuples
*   Pattern Matching

### Local Functions

#### Summary
**Local Functions** are methods defined inside other methods. They can access local variables and parameters from the enclosing method.

#### Motivation / When to Use
*   **Recursive Helpers**: Implement recursive algorithms.
*   **Iterator/Async Validation**: Defer execution while validating upfront.
*   **Encapsulation**: Keep helpers private to one method.

#### Benefits
*   **Performance**: No delegate allocation (unlike lambdas).
*   **Cleaner**: Avoids polluting class with private helpers.

#### Improvements (C# specifics)
*   Can be `static` (C# 8.0) to prevent capturing.
*   Supports generics and attributes.

#### Example
```csharp
public int Factorial(int n)
{
    if (n < 0) throw new ArgumentException("Negative");
    
    return Compute(n);
    
    int Compute(int x) => x <= 1 ? 1 : x * Compute(x - 1);
}
```

#### Line-by-Line Explanation
*   `int Compute(int x)`: Local function defined inside `Factorial`.
*   Can call itself recursively.

#### Tests
[4 - LocalFunctions.cs](../../CSharpStudy.Tests/CSharp7/4%20-%20LocalFunctions.cs)

#### Common Pitfalls / Gotchas
*   **Capture**: Capturing variables creates a closure.
*   **Use `static`**: In C# 8.0+, use `static` to prevent accidental capture.

#### Related Topics
*   Lambdas
*   Static Local Functions (C# 8.0)

### `out var` (inline declaration)

#### Summary
**Inline out declarations** allow declaring the `out` variable directly in the method call, keeping declaration and usage together.

#### Motivation / When to Use
*   **TryParse patterns**: `int.TryParse(str, out int n)`.
*   **Dictionary lookups**: `dict.TryGetValue(key, out var value)`.

#### Benefits
*   **Concise**: No separate declaration line.
*   **Scoped**: Variable is available after the call.

#### Example
```csharp
if (int.TryParse("123", out int number))
{
    Console.WriteLine(number * 2); // 246
}

// With var
if (dict.TryGetValue(key, out var value))
    Console.WriteLine(value);
```

#### Tests
[1 - OutVariables.cs](../../CSharpStudy.Tests/CSharp7/1%20-%20OutVariables.cs)

#### Related Topics
*   Discards (`_ `)

### `ref` locals and returns

#### Summary
**Ref returns** allow methods to return references to variables. **Ref locals** store those references. This enables modifying the original data without copying.

#### Motivation / When to Use
*   **Large Structs**: Avoid copying when accessing array elements.
*   **Performance-Critical**: Game engines, numerical computing.

#### Benefits
*   **Zero-Copy**: Work directly with the original value.
*   **Mutable Access**: Modify values in-place.

#### Example
```csharp
public ref int Find(int[] arr, int target)
{
    for (int i = 0; i < arr.Length; i++)
        if (arr[i] == target)
            return ref arr[i];
    throw new InvalidOperationException();
}

int[] nums = { 1, 2, 3 };
ref int numRef = ref Find(nums, 2);
numRef = 20; // nums is now { 1, 20, 3 }
```

#### Tests
[5 - RefReturns.cs](../../CSharpStudy.Tests/CSharp7/5%20-%20RefReturns.cs)

#### Common Pitfalls / Gotchas
*   **Lifetime**: Cannot return ref to local variable.
*   **Readonly Refs**: `ref readonly` prevents modification.

#### Related Topics
*   `in` parameters (C# 7.2)
*   `Span<T>`


### throw Expressions

#### Summary
**Throw expressions** allow `throw` in expression contexts (null-coalescing, ternary, expression-bodied members) where previously only statements were allowed.

#### Motivation / When to Use
*   **Null Checks**: `name ?? throw new ArgumentNullException()`.
*   **Ternary**: `valid ? value : throw new Exception()`.
*   **Expression-bodied**: Constructor validation.

#### Benefits
*   **Concise**: One-liner guard clauses.

#### Example
```csharp
public class Person
{
    public string Name { get; }
    
    public Person(string name) =>
        Name = name ?? throw new ArgumentNullException(nameof(name));
}

// Ternary
int result = isValid ? value : throw new InvalidOperationException();
```

#### Related Topics
*   Null-coalescing operator
*   Expression-bodied members

### Generalized Async Return Types (`ValueTask<T>`)

#### Summary
**`ValueTask<T>`** is a struct-based alternative to `Task<T>` that avoids heap allocation when results are synchronously available (e.g., cached values).

#### Motivation / When to Use
*   **Cached Results**: Return cached data without Task allocation.
*   **Hot Paths**: High-frequency async calls.

#### Benefits
*   **Performance**: Struct = stack allocation.
*   **Same await syntax**: Works just like `Task<T>`.

#### Example
```csharp
private Dictionary<string, int> _cache = new();

public async ValueTask<int> GetAsync(string key)
{
    if (_cache.TryGetValue(key, out var value))
        return value; // No allocation!
    
    var result = await FetchFromDbAsync(key);
    _cache[key] = result;
    return result;
}
```

#### Tests
[6 - GeneralizedAsyncReturn.cs](../../CSharpStudy.Tests/CSharp7/6%20-%20GeneralizedAsyncReturn.cs)

#### Common Pitfalls / Gotchas
*   **Await Once**: Cannot await a `ValueTask<T>` multiple times.
*   **Not for all cases**: Use `Task<T>` for complex async flows.

#### Related Topics
*   async/await
*   `IValueTaskSource<T>`

### Binary Literals and Digit Separators

#### Summary
**Binary literals** use `0b` prefix for base-2 numbers. **Digit separators** (`_`) improve readability of large literals (works with binary, hex, and decimal).

#### Motivation / When to Use
*   **Bit Masks**: `0b1111_0000` for flags.
*   **Large Numbers**: `1_000_000` vs `1000000`.
*   **Hex Values**: `0xFF_00_FF` for colors.

#### Benefits
*   **Readable**: Clear at a glance.
*   **No Runtime Impact**: Compile-time only.

#### Example
```csharp
int flags = 0b1010_1010;     // 170
long billion = 1_000_000_000;
int color = 0xFF_AA_BB;       // RGB color
```

#### Tests
[9 - DigitBinarySeparator.cs](../../CSharpStudy.Tests/CSharp7/9%20-%20DigitBinarySeparator.cs)

#### Related Topics
*   Numeric Types
*   Bit Operations
