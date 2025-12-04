# Chapter 3 --- C# 2.0: The Generics Revolution

## Summary
Released in 2005 with Visual Studio 2005, C# 2.0 was a massive update. The introduction of **Generics** was the most significant feature, fundamentally changing how collections were used. It also introduced features that improved developer productivity and code expressiveness.

## Highlights & Internal Changes
*   **Generics Support in CLR**: Generics were implemented at the runtime level (reified generics), allowing for performance benefits and true type safety, unlike Java's type erasure.
*   **Nullable Types**: Addressed the "billion-dollar mistake" of nulls by allowing value types to represent a null state.

## Topics

### Generics (`List<T>`, `Dictionary<K, V>`)

#### Summary
**Generics** allow you to define classes, interfaces, and methods with placeholders for types (type parameters). This enables you to write code that works with any data type while maintaining type safety and performance.

#### Motivation / When to Use
*   **Collections**: Creating lists, stacks, or queues that can hold any specific type (e.g., `List<int>`, `List<string>`) without casting.
*   **Algorithms**: Writing sorting or searching algorithms that work on any comparable type.
*   **Design Patterns**: Implementing repositories or factories that handle different entity types uniformly.

#### Benefits
*   **Type Safety**: Errors are caught at compile time. You cannot accidentally add a string to a `List<int>`.
*   **Performance**: Eliminates boxing/unboxing overhead for value types. `List<int>` stores raw integers, not objects.
*   **Code Reuse**: Write the logic once (e.g., `Stack<T>`) and use it for any type.

#### Improvements (C# specifics)
*   **Reified Generics**: Unlike Java's type erasure, C# generics exist at runtime. `List<int>` and `List<string>` are distinct types, allowing for optimizations and reflection.
*   **Constraints**: You can restrict type parameters (e.g., `where T : class`, `where T : new()`).

#### Example
```csharp
// 1. Define a generic class
public class GenericStack<T>
{
    private T[] _items = new T[100];
    private int _index = 0;

    public void Push(T item) => _items[_index++] = item;
    public T Pop() => _items[--_index];
}

// 2. Usage
var intStack = new GenericStack<int>();
intStack.Push(10);
intStack.Push(20);
int sum = intStack.Pop() + intStack.Pop(); // No casting needed
```

#### Line-by-Line Explanation
*   `class GenericStack<T>`: `T` is the type parameter. It will be replaced by a concrete type (like `int`) when instantiated.
*   `T[] _items`: The array holds elements of type `T`.
*   `Push(T item)`: The method accepts an argument of type `T`.

#### Tests
[1 - Generics.cs](../../CSharpStudy.Tests/CSharp2/1%20-%20Generics.cs)

```csharp
[Fact]
public void GenericStack_EnforcesTypeSafety()
{
    var stack = new GenericStack<string>();
    stack.Push("Hello");
    // stack.Push(123); // Compile error!
    
    string item = stack.Pop();
    Assert.Equal("Hello", item);
}
```

#### Common Pitfalls / Gotchas
*   **Bloat**: Excessive use of generics with value types can cause code bloat (the CLR generates specialized code for each value type instantiation).
*   **Covariance/Contravariance**: `List<string>` is not a `List<object>`. (Variance support was added for interfaces in C# 4.0).
*   **Static Members**: Static fields are shared only within the same closed generic type (`MyClass<int>` shares statics, `MyClass<string>` has its own copy).

#### Performance Notes
*   **Value Types**: `List<int>` is much faster than `ArrayList` because it avoids boxing.
*   **Reference Types**: `List<string>` and `List<object>` share the same native code implementation, so there's no code bloat for reference types.

#### Best Practices / Checklist
*   Prefer `List<T>` over arrays for most collections.
*   Use constraints (`where T : ...`) to document and enforce requirements on type parameters.
*   Name type parameters descriptively (e.g., `TKey`, `TValue`) or use `T` if it's the only one.

#### Related Topics
*   Generic Constraints
*   Covariance and Contravariance (C# 4.0)
*   `IEnumerable<T>`

### Nullable Value Types (`int?`)

#### Summary
**Nullable Value Types** allow value types (like `int`, `bool`, `DateTime`) to represent `null`. This is essential for scenarios where a value might be absent, such as optional fields in a database.

#### Motivation / When to Use
*   **Database Mapping**: A database column might contain `NULL`. `int?` maps directly to this.
*   **Optional Values**: Representing "not set" states without using magic numbers like `-1`.
*   **API Responses**: Handling missing fields in JSON/XML responses.

#### Benefits
*   **Clarity**: Explicitly signals that a value can be absent.
*   **Safety**: Compiler enforces checks before using the value (via `HasValue` or `??`).

#### Improvements (C# specifics)
*   **`T?` Syntax**: Shorthand for `Nullable<T>`.
*   **Null-Coalescing Operator (`??`)**: Provides a default value concisely.

#### Example
```csharp
int? age = null; // No age provided

// Check before use
if (age.HasValue)
{
    Console.WriteLine($"Age is {age.Value}");
}

// Or use null-coalescing
int displayAge = age ?? 0; // If null, use 0
```

#### Line-by-Line Explanation
*   `int? age = null`: Declares a nullable integer. `int?` is equivalent to `Nullable<int>`.
*   `age.HasValue`: Returns `true` if `age` is not null.
*   `age.Value`: Gets the underlying value. Throws `InvalidOperationException` if null.
*   `age ?? 0`: Returns `age` if not null, otherwise returns `0`.

#### Tests
[3 - NullableValue.cs](../../CSharpStudy.Tests/CSharp2/3%20-%20NullableValue.cs)

```csharp
[Fact]
public void NullCoalescing_ReturnsDefault_WhenNull()
{
    int? nullable = null;
    int result = nullable ?? -1;
    
    Assert.Equal(-1, result);
}
```

#### Common Pitfalls / Gotchas
*   **Accessing `.Value` on null**: Throws `InvalidOperationException`. Always check `HasValue` or use `??`.
*   **Boxing**: Boxing a `null` nullable results in a null reference, not a boxed `Nullable<T>`.
*   **Comparison**: `null == null` is true, but `nullable.Equals(null)` throws if `nullable` itself is null.

#### Performance Notes
*   `Nullable<T>` is a struct containing a value and a boolean flag. There's a small memory overhead.

#### Best Practices / Checklist
*   Use `??` for providing defaults.
*   Use `?.` (null-conditional, C# 6.0) for safe member access.
*   Consider non-nullable reference types (C# 8.0) for stricter null safety.

#### Related Topics
*   Nullable Reference Types (C# 8.0)
*   Null-Conditional Operators (C# 6.0)
*   `GetValueOrDefault()` method

<!-- TODO: Consider adding Access Modifiers on Property Accessors (e.g., public int X { get; private set; }) -->

### Partial Classes

#### Summary
**Partial Classes** allow you to split the definition of a class, struct, or interface across multiple source files. All parts are combined at compile time.

#### Motivation / When to Use
*   **Code Generators**: Separating auto-generated code (e.g., Windows Forms designer, EF scaffolding) from hand-written code.
*   **Team Collaboration**: Multiple developers can work on different parts of a large class simultaneously.
*   **Organization**: Large classes can be logically divided into separate files.

#### Benefits
*   **Separation of Concerns**: Keep generated code clean and untouchable; edit only your custom parts.
*   **Merge-Friendly**: Reduces Git conflicts when multiple developers edit the same class.

#### Improvements (C# specifics)
*   **`partial` Keyword**: Applied to each part of the class declaration.
*   **Partial Methods**: (C# 3.0) Allow defining a method signature in one part, with optional implementation in another.

#### Example
```csharp
// File: User.Generated.cs (Auto-generated)
public partial class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// File: User.cs (Custom logic)
public partial class User
{
    public string GetDisplayName() => $"[{Id}] {Name}";
}
```

#### Line-by-Line Explanation
*   `partial class User`: Both files declare the same class as `partial`. The compiler merges them.
*   Properties in one file, methods in another: All members end up in a single class.

#### Tests
No dedicated test file (conceptual feature).

#### Common Pitfalls / Gotchas
*   **All parts must be `partial`**: If any part omits `partial`, it's a compile error.
*   **Single Assembly**: All partial definitions must be in the same assembly.
*   **Access Modifiers**: Must be consistent across all parts.

#### Best Practices / Checklist
*   Use for separating generated code only.
*   Don't use to hide complexity—consider refactoring large classes instead.

#### Related Topics
*   Partial Methods (C# 3.0)
*   Extension Methods (C# 3.0)

### Static Classes

#### Summary
**Static Classes** are classes that cannot be instantiated and can only contain static members. They are declared using the `static` keyword on the class definition.

#### Motivation / When to Use
*   **Utility/Helper Methods**: Math utilities, string helpers, validation functions.
*   **Extension Method Containers**: Extension methods must be defined in static classes.
*   **Constants**: Grouping related constants together.

#### Benefits
*   **Compiler Enforcement**: Prevents accidental instantiation.
*   **Clarity**: Signals intent that no instance state is involved.

#### Improvements (C# specifics)
*   **`static` Keyword on Class**: Enforces that all members must be static.
*   **Cannot Have Instance Constructors**: Only a static constructor is allowed.

#### Example
```csharp
public static class MathHelper
{
    public static int Square(int x) => x * x;
    public static int Max(int a, int b) => a > b ? a : b;
}

// Usage
int squared = MathHelper.Square(5); // 25
```

#### Line-by-Line Explanation
*   `static class MathHelper`: Cannot use `new MathHelper()`.
*   `static int Square(...)`: All methods must be static.

#### Tests
[8 - StaticInterfaces.cs](../../CSharpStudy.Tests/CSharp2/8%20-%20StaticInterfaces.cs)

#### Common Pitfalls / Gotchas
*   **No State**: Cannot store instance fields. Use with caution for mutable static state (thread safety issues).
*   **Testing**: Static methods are harder to mock. Prefer dependency injection for complex logic.

#### Best Practices / Checklist
*   Use for pure utility functions with no side effects.
*   Avoid mutable static state.
*   Consider extension methods for fluent APIs.

#### Related Topics
*   Extension Methods (C# 3.0)
*   Static Abstract Members (C# 11.0)

### Iterators (`yield return`)

#### Summary
**Iterators** simplify the implementation of `IEnumerable` and `IEnumerator`. Using `yield return`, the compiler generates a state machine that produces values on-demand (lazy evaluation).

#### Motivation / When to Use
*   **Streaming Data**: Process large datasets without loading everything into memory.
*   **Infinite Sequences**: Generate sequences like Fibonacci numbers or random values.
*   **Pipelines**: Transform data lazily (filter, map) before final materialization.

#### Benefits
*   **Simplicity**: No need to manually implement `IEnumerator`, `Current`, `MoveNext()`, or `Reset()`.
*   **Lazy Evaluation**: Values are computed only when iterated.

#### Improvements (C# specifics)
*   **`yield return`**: Returns a value and pauses execution until the next item is requested.
*   **`yield break`**: Ends iteration early.

#### Example
```csharp
public static IEnumerable<int> GetEvenNumbers(int max)
{
    for (int i = 0; i <= max; i++)
    {
        if (i % 2 == 0)
            yield return i;
    }
}

// Usage
foreach (int n in GetEvenNumbers(10))
{
    Console.WriteLine(n); // 0, 2, 4, 6, 8, 10
}
```

#### Line-by-Line Explanation
*   `yield return i`: Returns `i` and pauses. On next iteration, execution resumes after this line.
*   The loop state (variable `i`) is preserved between calls.

#### Tests
No dedicated test file. (Commonly used in LINQ tests.)

```csharp
[Fact]
public void Iterator_LazilyReturnsValues()
{
    var results = GetEvenNumbers(6).ToList();
    Assert.Equal(new[] { 0, 2, 4, 6 }, results);
}
```

#### Common Pitfalls / Gotchas
*   **Deferred Execution**: The method body doesn't run until you iterate. Exceptions inside won't throw until iteration.
*   **Cannot use `yield` in `try-catch`**: Only `try-finally` is allowed with `yield`.

#### Performance Notes
*   No upfront allocation of a full collection. Ideal for large or infinite sequences.

#### Best Practices / Checklist
*   Use for lazy sequences.
*   Be aware of deferred execution (e.g., database connection might close before iteration).
*   Materialize with `.ToList()` if you need multiple passes.

#### Related Topics
*   LINQ (C# 3.0)
*   Async Streams (`IAsyncEnumerable<T>`, C# 8.0)

### Anonymous Methods

#### Summary
**Anonymous Methods** allow you to define inline delegate code blocks without creating a named method. Introduced in C# 2.0, they were the precursor to lambda expressions.

#### Motivation / When to Use
*   **Event Handlers**: Short, one-off handlers that don't warrant a full method.
*   **Callbacks**: Passing simple logic to async operations or thread pool work.

#### Benefits
*   **Less Boilerplate**: No need to declare a separate method for trivial logic.
*   **Closure**: Can capture variables from the enclosing scope.

#### Improvements (C# specifics)
*   **`delegate` Keyword**: Used to define the inline block.
*   **Variable Capture**: Automatically captures local variables (closures).

#### Example
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// Anonymous method as a predicate
List<int> evens = numbers.FindAll(
    delegate(int n) { return n % 2 == 0; }
);
// evens = [2, 4]
```

#### Line-by-Line Explanation
*   `delegate(int n)`: Defines an inline method taking `int n`.
*   `{ return n % 2 == 0; }`: The body of the anonymous method.

#### Tests
No dedicated test file. (Superseded by lambda expressions in tests.)

```csharp
[Fact]
public void AnonymousMethod_FiltersCorrectly()
{
    var nums = new List<int> { 1, 2, 3, 4 };
    var evens = nums.FindAll(delegate(int n) { return n % 2 == 0; });
    
    Assert.Equal(new[] { 2, 4 }, evens);
}
```

#### Common Pitfalls / Gotchas
*   **Verbose Syntax**: Compared to lambdas (`n => n % 2 == 0`), anonymous methods are more verbose.
*   **Obsolete**: Largely replaced by lambda expressions in C# 3.0+.

#### Performance Notes
*   Closure allocation: Capturing variables may allocate a closure object.

#### Best Practices / Checklist
*   Prefer **lambda expressions** (C# 3.0) for brevity.
*   Use anonymous methods only if targeting C# 2.0.

#### Related Topics
*   Lambda Expressions (C# 3.0)
*   Delegates and Events (C# 1.0)
