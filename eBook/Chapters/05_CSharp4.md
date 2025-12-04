# Chapter 5 --- C# 4.0: The Dynamic Era

## Summary
Released in 2010 with Visual Studio 2010, C# 4.0 focused on improving interoperability with dynamic languages and COM (Component Object Model). The introduction of the `dynamic` keyword allowed C# to bypass static type checking when necessary, making it easier to work with Python, Ruby, or legacy COM libraries (like Office automation).

## Highlights & Internal Changes
*   **DLR (Dynamic Language Runtime)**: A new runtime environment that sits on top of the CLR and provides services for dynamic languages.
*   **Call Site Caching**: The DLR caches the result of method resolution for dynamic operations to improve performance.

## Topics

### `dynamic` keyword (Runtime binding)

#### Summary
**`dynamic`** is a static type that bypasses compile-time type checking. Operations on `dynamic` variables are resolved at runtime using the Dynamic Language Runtime (DLR).

#### Motivation / When to Use
*   **COM Interop**: Working with Office automation or legacy COM libraries.
*   **Dynamic Languages**: Interoperating with Python (IronPython), Ruby, or JavaScript.
*   **JSON Parsing**: Accessing properties on deserialized JSON without strongly-typed classes.

#### Benefits
*   **Flexibility**: Access members without knowing the type at compile time.
*   **Simplified Reflection**: No need for `GetMethod/Invoke` boilerplate.

#### Improvements (C# specifics)
*   **DLR Integration**: Built on the Dynamic Language Runtime.
*   **Call Site Caching**: Performance optimization by caching method resolutions.

#### Example
```csharp
dynamic value = 5;
Console.WriteLine(value + 10);  // 15 - works as int

value = "Hello";
Console.WriteLine(value.ToUpper()); // HELLO - works as string

value = new ExpandoObject();
value.Name = "Dynamic!";
Console.WriteLine(value.Name);  // Dynamic!
```

#### Line-by-Line Explanation
*   `dynamic value = 5`: Compiles, but type is resolved at runtime.
*   `value.ToUpper()`: No compile error even if `value` is an int (fails at runtime).
*   `ExpandoObject`: Built-in type for adding properties dynamically.

#### Tests
[1 - DynamicTyping.cs](../../CSharpStudy.Tests/CSharp4/1%20-%20DynamicTyping.cs)

```csharp
[Fact]
public void Dynamic_CanChangeType()
{
    dynamic x = 1;
    Assert.Equal(1, x);
    
    x = "hello";
    Assert.Equal("hello", x);
}
```

#### Common Pitfalls / Gotchas
*   **No IntelliSense**: IDE cannot provide completion for `dynamic`.
*   **Runtime Errors**: Compile passes but runtime throws `RuntimeBinderException`.
*   **Performance**: Slower than static typing due to runtime binding.

#### Performance Notes
*   First call is slow (JIT compilation + DLR resolution).
*   Subsequent calls are cached and faster.

#### Best Practices / Checklist
*   Use sparingly. Prefer strong typing.
*   Ideal for COM/Office interop or dynamic data structures.
*   Wrap dynamic code in try/catch for safety.

#### Related Topics
*   Reflection
*   ExpandoObject
*   COM Interop

### Optional & Named Parameters

#### Summary
**Optional Parameters** have default values so callers can omit them. **Named Parameters** allow specifying arguments by name, regardless of order.

#### Motivation / When to Use
*   **API Design**: Methods with many configuration options.
*   **Readability**: Clarify what each argument means at the call site.
*   **COM Interop**: Many COM methods have numerous optional parameters.

#### Benefits
*   **Fewer Overloads**: One method can replace many overloads.
*   **Self-Documenting**: Named arguments explain purpose.

#### Improvements (C# specifics)
*   **Default at Declaration**: `void Foo(int x = 10)`.
*   **Named at Call Site**: `Foo(x: 5)`.

#### Example
```csharp
void PrintMessage(string msg, int times = 1, bool uppercase = false)
{
    for (int i = 0; i < times; i++)
        Console.WriteLine(uppercase ? msg.ToUpper() : msg);
}

// Calls
PrintMessage("Hi");                      // times=1, uppercase=false
PrintMessage("Hi", 3);                   // times=3
PrintMessage("Hi", uppercase: true);     // times=1, uppercase=true
PrintMessage(uppercase: true, msg: "X"); // Named, any order
```

#### Line-by-Line Explanation
*   `int times = 1`: Default value; caller can omit.
*   `uppercase: true`: Named argument.

#### Tests
- [2 - NamedParameters.cs](../../CSharpStudy.Tests/CSharp4/2%20-%20NamedParameters.cs)
- [3 - OptionalParameters.cs](../../CSharpStudy.Tests/CSharp4/3%20-%20OptionalParameters.cs)

```csharp
[Fact]
public void OptionalParam_UsesDefault()
{
    int DoubleIt(int n = 5) => n * 2;
    Assert.Equal(10, DoubleIt());
    Assert.Equal(20, DoubleIt(10));
}
```

#### Common Pitfalls / Gotchas
*   **Compile-time Binding**: Default values are baked into the call site. Changing defaults doesn't affect old callers until recompiled.
*   **Ordering**: Optional parameters must come after required ones.

#### Best Practices / Checklist
*   Use for genuinely optional configuration.
*   Document default values clearly.
*   Prefer overloads for different behaviors.

#### Related Topics
*   Method Overloading
*   Caller Information Attributes (C# 5.0)

### Generic Covariance & Contravariance

#### Summary
**Covariance** (`out`) allows a more derived type to be used where a less derived type is expected. **Contravariance** (`in`) allows a less derived type to be used where a more derived type is expected. These apply to generic interfaces and delegates.

#### Motivation / When to Use
*   **Collection Return Types**: Return `IEnumerable<string>` as `IEnumerable<object>`.
*   **Event Handlers**: Use a general handler (`Action<object>`) where a specific one (`Action<string>`) is expected.

#### Benefits
*   **Flexibility**: Enables polymorphism with generics.
*   **Type Safety**: Compiler ensures safe conversions.

#### Improvements (C# specifics)
*   **`out` keyword**: Makes type parameter covariant (output only).
*   **`in` keyword**: Makes type parameter contravariant (input only).
*   **Interface/Delegate Only**: Classes cannot be variant.

#### Example
```csharp
// Covariance: IEnumerable<out T>
IEnumerable<string> strings = new List<string> { "a", "b" };
IEnumerable<object> objects = strings; // OK, covariant

// Contravariance: Action<in T>
Action<object> printObj = o => Console.WriteLine(o);
Action<string> printStr = printObj; // OK, contravariant
printStr("Hello");
```

#### Line-by-Line Explanation
*   `IEnumerable<object> objects = strings`: Works because `IEnumerable<T>` is covariant (`out T`).
*   `Action<string> printStr = printObj`: Works because `Action<T>` is contravariant (`in T`).

#### Tests
[5 - CovariantContravariantTypeParameters.cs](../../CSharpStudy.Tests/CSharp4/5%20-%20CovariantContravariantTypeParameters.cs)

```csharp
[Fact]
public void Covariance_AllowsAssignment()
{
    IEnumerable<string> strings = new[] { "x" };
    IEnumerable<object> objs = strings;
    
    Assert.Single(objs);
}
```

#### Common Pitfalls / Gotchas
*   **Read-Only for `out`**: Covariant type parameters can only appear in return positions.
*   **Write-Only for `in`**: Contravariant type parameters can only appear in input positions.
*   **Classes**: Cannot be covariant/contravariant, only interfaces and delegates.

#### Best Practices / Checklist
*   Use `out` for types that produce values.
*   Use `in` for types that consume values.
*   Annotate custom interfaces/delegates appropriately.

#### Related Topics
*   Generics (C# 2.0)
*   `IEnumerable<T>`, `Func<>`, `Action<>`

### Embedded Interop Types (No-PIA)

#### Summary
**Embedded Interop Types** (also called No-PIA) allows type information from COM assemblies to be embedded directly into your application, eliminating the need to deploy separate Primary Interop Assemblies (PIAs).

#### Motivation / When to Use
*   **Office Automation**: Using Microsoft.Office.Interop without distributing the PIA.
*   **Simplified Deployment**: No need to install PIAs on target machines.
*   **Version Independence**: Compiled against one Office version works with others.

#### Benefits
*   **Smaller Footprint**: Only used types are embedded.
*   **No GAC Dependency**: No need to install PIAs globally.

#### Improvements (C# specifics)
*   **Visual Studio Property**: Set "Embed Interop Types" = true on the COM reference.
*   **Compiler Support**: `/link` option.

#### Example
```csharp
// No code change required - just a project setting
// In Visual Studio:
// 1. Add reference to COM library (e.g., Microsoft.Office.Interop.Excel)
// 2. In Properties, set "Embed Interop Types" = true

// Usage remains the same
var excel = new Excel.Application();
excel.Visible = true;
```

#### Line-by-Line Explanation
*   No code change—this is a build/deployment feature.
*   The compiler extracts only the types you use from the PIA.

#### Tests
No automated test (configuration-based feature).

#### Common Pitfalls / Gotchas
*   **Not All Types Embeddable**: Some complex COM types may not embed.
*   **Reflection**: Embedded types may behave differently with reflection.

#### Best Practices / Checklist
*   Enable for COM interop assemblies.
*   Test on machines without PIAs installed.

#### Related Topics
*   COM Interop
*   `dynamic` keyword
