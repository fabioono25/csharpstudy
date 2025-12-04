# Chapter 2 --- C# 1.0: The Genesis

## Summary
C# 1.0, released in 2002 with Visual Studio .NET 2002, marked the beginning of the language. It was designed to be a modern, object-oriented language that addressed the complexities of C++ while providing the ease of use of Visual Basic. The core highlight was the introduction of **Managed Code**, running on the Common Language Runtime (CLR), which provided services like garbage collection and type safety.

## Highlights & Internal Changes
*   **Managed Execution**: Code is compiled to Intermediate Language (IL) and executed by the CLR.
*   **Garbage Collection**: Automatic memory management, removing the need for manual `malloc` and `free`.
*   **Unified Type System**: All types, including primitives, inherit from `System.Object`.

## Topics

### Classes, Structs, and Interfaces

#### Summary
The fundamental building blocks of C# applications. **Classes** are reference types used for object-oriented modeling. **Structs** are lightweight value types for data structures. **Interfaces** define contracts that classes and structs implement.

#### Motivation / When to Use
*   **Classes**: Use for most objects, especially those requiring inheritance, identity, or complex behavior (e.g., `Customer`, `Service`).
*   **Structs**: Use for small, immutable data values that act like primitives (e.g., `Point`, `ComplexNumber`, `Coordinate`).
*   **Interfaces**: Use to define capabilities (e.g., `IDisposable`, `IEnumerable`) and decouple implementation from definition.

#### Benefits
*   **Classes**: Support inheritance and polymorphism.
*   **Structs**: Memory efficient (stack-allocated or inline), reduced GC pressure.
*   **Interfaces**: Enable loose coupling and multiple implementation support (simulating multiple inheritance).

#### Improvements (C# specifics)
*   **Unified Type System**: Both classes and structs inherit from `object` (structs via boxing).
*   **Explicit Interfaces**: C# allows explicit interface implementation to hide members or resolve naming conflicts.
*   **Struct Semantics**: C# structs are true value types, unlike Java's classes-only approach (at the time).

#### Example
```csharp
public interface IShape
{
    double Area { get; }
}

public struct Point
{
    public int X, Y;
    public Point(int x, int y) { X = x; Y = y; }
}

public class Circle : IShape
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public double Area => Math.PI * Radius * Radius;
}
```

#### Line-by-Line Explanation
*   `interface IShape`: Defines a contract with a read-only property `Area`.
*   `struct Point`: A value type holding `X` and `Y`. It's lightweight and copied by value.
*   `class Circle`: A reference type implementing `IShape`. It contains a `Point` (struct) and `Radius`.
*   `public double Area => ...`: Implements the interface property using an expression body.

#### Tests
*   [1 - ClassesAndObjects.cs](../../CSharpStudy.Tests/CSharp1/1%20-%20ClassesAndObjects.cs)
*   [12 - Structs.cs](../../CSharpStudy.Tests/CSharp1/12%20-%20Structs.cs)
*   [19 - Interfaces.cs](../../CSharpStudy.Tests/CSharp1/19%20-%20Interfaces.cs)

```csharp
[Fact]
public void ClassAndStructBehavior()
{
    var center = new Point(0, 0);
    var circle = new Circle(center, 5);
    
    Assert.Equal(78.53981633974483, circle.Area);
}
```

#### Common Pitfalls / Gotchas
*   **Mutable Structs**: Avoid mutable structs; they can lead to confusing bugs because copies are modified, not the original.
*   **Boxing**: Assigning a struct to an interface causes boxing (heap allocation), negating performance benefits.
*   **Class Overhead**: Using classes for tiny data structures can cause excessive GC pressure.

#### Performance Notes
*   Structs are stack-allocated (or inline), avoiding GC. However, passing large structs by value is slow (copies data); use `ref` to optimize.
*   Interface calls on structs are slower due to boxing (unless using constrained generics).

#### Best Practices / Checklist
*   Default to **Classes** for most logic and entities.
*   Use **Structs** only for small, immutable values (< 16 bytes is a common rule of thumb).
*   Use **Interfaces** to define public contracts and enable testing (mocking).
*   Make structs **immutable** (`readonly struct` in later versions).

#### Related Topics
*   Inheritance & Polymorphism
*   Boxing & Unboxing
*   Generics (C# 2.0)

### Inheritance & Polymorphism

#### Summary
Allows classes to inherit behavior and override methods using `virtual` and `override`, enabling runtime polymorphic dispatch.

#### Motivation / When to Use
*   Implement shared behaviour across several related types (e.g., `Vehicle`, `Car`, `Truck`).
*   Provide common default behavior that derived classes may specialize.
*   Use when code needs to treat different concrete types uniformly via a base reference.

#### Benefits
*   **Code reuse**: Avoid duplicating common logic.
*   **Extensibility**: Add new derived types without changing client code.
*   **Patterns**: Enables patterns like Template Method and Strategy.

#### Improvements (C# specifics)
*   C# requires explicit `virtual` and `override` (prevents accidental overrides).
*   `sealed` can stop further overriding.
*   `new` hides base members — different semantics (not polymorphic).

#### Example
```csharp
public class Base
{
    public virtual string Show() => "Base";
}

public class Derived : Base
{
    public override string Show() => "Derived";
}

public class HidingDerived : Base
{
    // Hides base method, not overrides it
    public new string Show() => "HidingDerived";
}
```

#### Line-by-Line Explanation
*   `public virtual string Show()`: Marks the base method overridable at runtime.
*   `public override string Show()`: Provides the derived implementation; calls through a `Base` reference dispatch to this method.
*   `public new string Show()`: Hides the base method; calling through a `Base` reference still invokes `Base.Show()`.

#### Tests
[2 - Inheritance.cs](../../CSharpStudy.Tests/CSharp1/2%20-%20Inheritance.cs)

```csharp
[Fact]
public void DerivedOverridesBase_Show_ReturnsDerived()
{
    Base subject = new Derived();
    Assert.Equal("Derived", subject.Show());
}
```

#### Common Pitfalls / Gotchas
*   Forgetting `virtual` in base class -> `override` not possible.
*   Using `new` (hiding) accidentally -> leads to surprising behavior when using base references.
*   Overriding and changing contract (violates Liskov Substitution Principle).
*   Excessive inheritance -> fragile hierarchies. Prefer composition when behavior is not shared exactly.

#### Performance Notes
*   Virtual calls have small dispatch overhead (vtable). Typically negligible, but in tight loops consider alternatives.

#### Best Practices / Checklist
*   Use inheritance for "is-a" relationships and shared behavior.
*   Prefer `abstract` if base makes no sense to instantiate.
*   Seal overrides if further specialization is not expected (`public sealed override ...`).
*   Keep inheritance shallow; prefer interfaces or composition for orthogonal concerns.

#### Related Topics
*   `abstract` classes and abstract members
*   `interface` vs `inheritance`
*   `sealed` classes / methods
*   Liskov Substitution Principle

### Delegates and Events

#### Summary
**Delegates** are type-safe function pointers that hold references to methods. **Events** are a wrapper around delegates that implement the Observer pattern, allowing objects to subscribe to and receive notifications.

#### Motivation / When to Use
*   **Callbacks**: executing code when a task completes (e.g., async operations).
*   **Event Handling**: UI interactions (button clicks) or system changes (file created).
*   **Decoupling**: The publisher doesn't need to know who the subscribers are.

#### Benefits
*   **Type Safety**: Unlike C++ function pointers, delegates ensure the method signature matches.
*   **Multicast**: Delegates can hold references to multiple methods (invocation list).
*   **Encapsulation**: Events prevent external code from clearing the invocation list (only `+=` and `-=` allowed).

#### Improvements (C# specifics)
*   **First-class support**: Built-in keywords (`delegate`, `event`) make the Observer pattern easy to implement.
*   **MulticastDelegate**: The underlying CLR support for chaining methods.

#### Example
```csharp
// 1. Define the delegate
public delegate void Notify(string message);

public class Process
{
    // 2. Define the event based on the delegate
    public event Notify OnCompleted;

    public void Start()
    {
        // ... work ...
        // 3. Raise the event
        OnCompleted?.Invoke("Process finished!");
    }
}

// Usage
var process = new Process();
process.OnCompleted += msg => Console.WriteLine(msg); // Subscribe
process.Start();
```

#### Line-by-Line Explanation
*   `delegate void Notify(...)`: Defines the signature of methods that can be called.
*   `event Notify OnCompleted`: Declares an event. Outside classes can only add (`+=`) or remove (`-=`) handlers.
*   `OnCompleted?.Invoke(...)`: Safely invokes the delegate only if it's not null (i.e., has subscribers).

#### Tests
*   [7 - Delegates.cs](../../CSharpStudy.Tests/CSharp1/7%20-%20Delegates.cs)
*   [8 - Events.cs](../../CSharpStudy.Tests/CSharp1/8%20-%20Events.cs)

```csharp
[Fact]
public void Event_Raised_WhenProcessCompletes()
{
    var process = new Process();
    string receivedMessage = null;
    
    process.OnCompleted += msg => receivedMessage = msg;
    process.Start();
    
    Assert.Equal("Process finished!", receivedMessage);
}
```

#### Common Pitfalls / Gotchas
*   **NullReferenceException**: Always check if the event is null before invoking (or use `?.Invoke`).
*   **Memory Leaks**: Failing to unsubscribe (`-=`) from static events can keep objects alive, preventing garbage collection.
*   **Overwriting**: Using `=` instead of `+=` on a delegate variable wipes out other subscribers (Events prevent this).

#### Performance Notes
*   Delegate invocation is slightly slower than a direct method call but generally negligible.
*   Multicast delegates iterate through the list sequentially; a slow subscriber blocks the rest.

#### Best Practices / Checklist
*   Use `EventHandler<T>` instead of defining custom delegate types (standard practice in modern C#).
*   Always check for null before raising an event.
*   Use `+=` and `-=` for subscription.
*   Unsubscribe when the subscriber is disposed to avoid memory leaks.

#### Related Topics
*   Lambda Expressions (C# 3.0)
*   Anonymous Methods (C# 2.0)
*   `Action` and `Func` delegates

### Boxing and Unboxing

#### Summary
**Boxing** is the process of converting a value type (like `int`, `struct`) to the type `object` or to any interface implemented by this value type. **Unboxing** is the reverse process: extracting the value type from the object.

#### Motivation / When to Use
*   **Unified Type System**: Allows storing any type in a generic container (like `ArrayList` in C# 1.0) or passing any type to a method expecting `object`.
*   **Interfaces**: When a struct implements an interface, it must be boxed to be treated as that interface.

#### Benefits
*   **Flexibility**: Enables a single method (e.g., `Console.WriteLine(object value)`) to handle any data type.
*   **Consistency**: Everything ultimately inherits from `System.Object`.

#### Improvements (C# specifics)
*   **Implicit Boxing**: Boxing happens automatically when needed.
*   **Explicit Unboxing**: Unboxing requires an explicit cast, ensuring type safety.

#### Example
```csharp
int num = 123;

// Boxing: Implicit conversion to object
object boxed = num; 

// Unboxing: Explicit cast back to int
int unboxed = (int)boxed;
```

#### Line-by-Line Explanation
*   `int num = 123`: A value type on the stack.
*   `object boxed = num`: A new object is allocated on the heap, and the value `123` is copied into it. `boxed` is a reference to this heap object.
*   `int unboxed = (int)boxed`: The value is copied from the heap object back to the stack. Throws `InvalidCastException` if types don't match.

#### Tests
[16 - BoxingUnboxing.cs](../../CSharpStudy.Tests/CSharp1/16%20-%20BoxingUnboxing.cs)

```csharp
[Fact]
public void Boxing_CreatesCopy()
{
    int original = 42;
    object boxed = original; // Box
    
    original = 99; // Change stack value
    
    int unboxed = (int)boxed; // Unbox
    
    Assert.Equal(42, unboxed); // Boxed copy remained 42
}
```

#### Common Pitfalls / Gotchas
*   **Performance**: Boxing allocates memory on the heap and causes GC pressure. Unboxing checks type at runtime. Avoid in tight loops.
*   **Type Safety**: Unboxing to the wrong type throws `InvalidCastException`. You must unbox to the exact original type (e.g., cannot unbox an `int` boxed as `double`).
*   **Identity**: `boxed1 == boxed2` compares references, not values (unless `Equals` is used).

#### Performance Notes
*   **High Cost**: Boxing is expensive (allocation + copy). Unboxing is cheaper but still has overhead (type check + copy).
*   **Generics (C# 2.0)**: Largely eliminated the need for boxing in collections, providing massive performance gains.

#### Best Practices / Checklist
*   Avoid boxing where possible, especially in hot paths.
*   Use **Generics** (C# 2.0+) instead of `ArrayList` or `object` collections.
*   Be aware that calling `ToString()`, `Equals()`, or `GetHashCode()` on a struct *may* cause boxing if not overridden.

#### Related Topics
*   Classes, Structs, and Interfaces
*   Generics (C# 2.0)

### Properties

#### Summary
**Properties** are members that provide a flexible mechanism to read, write, or compute the value of a private field. They look like public data fields but are actually special methods called *accessors* (`get` and `set`).

#### Motivation / When to Use
*   **Encapsulation**: Expose data while hiding implementation details (e.g., validation logic).
*   **Computed Values**: Return a value calculated on the fly (e.g., `Area` from `Width` and `Height`).
*   **Read-only/Write-only**: Control access (e.g., only allow reading `Id`).

#### Benefits
*   **Validation**: Validate data before assigning it to a field.
*   **Data Binding**: Essential for UI frameworks (WPF, WinForms) to bind data.
*   **Compatibility**: Changing a field to a property is a breaking change (binary compatibility), so starting with properties is safer.

#### Improvements (C# specifics)
*   **Syntax**: Much cleaner than Java's `getVariable()` and `setVariable()` convention.
*   **Accessors**: `get` and `set` keywords define the behavior clearly.

#### Example
```csharp
public class BankAccount
{
    private decimal _balance;

    public decimal Balance
    {
        get { return _balance; }
        set 
        { 
            if (value >= 0) 
                _balance = value; 
            else
                throw new ArgumentException("Balance cannot be negative");
        }
    }
}
```

#### Line-by-Line Explanation
*   `private decimal _balance`: The backing field that actually stores the data.
*   `get { return _balance; }`: The accessor called when reading the property.
*   `set { ... }`: The accessor called when assigning to the property. The keyword `value` represents the assigned value.

#### Tests
[3 - Encapsulation.cs](../../CSharpStudy.Tests/CSharp1/3%20-%20Encapsulation.cs)

```csharp
[Fact]
public void SettingNegativeBalance_ThrowsException()
{
    var account = new BankAccount();
    Assert.Throws<ArgumentException>(() => account.Balance = -100);
}
```

#### Common Pitfalls / Gotchas
*   **Side Effects**: Avoid expensive operations (like database calls) in getters; users expect property access to be instant.
*   **Exceptions**: Getters should generally not throw exceptions. Setters can throw validation exceptions.
*   **Infinite Recursion**: Calling the property itself inside the accessor (e.g., `get { return Balance; }`) causes a stack overflow.

#### Performance Notes
*   Properties are compiled to methods (`get_Balance`, `set_Balance`), so there is a tiny overhead compared to fields, but the JIT compiler often inlines them, making them as fast as fields.

#### Best Practices / Checklist
*   Use **PascalCase** for properties and **camelCase** (often with `_`) for backing fields.
*   Prefer properties over public fields.
*   Keep property logic simple.
*   Use Auto-Implemented Properties (C# 3.0) when no logic is needed (covered in later chapters).

#### Related Topics
*   Auto-Implemented Properties (C# 3.0)
*   Init-only properties (C# 9.0)
*   Expression-bodied members (C# 6.0)

### Arrays

#### Summary
**Arrays** are fixed-size collections that store multiple elements of the same type in a contiguous block of memory. They are the most fundamental collection type in C#.

#### Motivation / When to Use
*   **Performance**: When you need the fastest possible access (by index) and memory locality.
*   **Fixed Size**: When the number of elements is known in advance and won't change.
*   **Interoperability**: Often required when calling native APIs or interacting with legacy code.

#### Benefits
*   **Type Safety**: Arrays are strongly typed (`int[]` can only hold integers).
*   **Efficiency**: Zero overhead for element access; no boxing for value types.
*   **Multidimensional**: Supports true multidimensional arrays (`[,]`) which are more efficient than arrays of arrays for matrices.

#### Improvements (C# specifics)
*   **Bounds Checking**: The CLR ensures you cannot access memory outside the array bounds (throws `IndexOutOfRangeException`), preventing buffer overflow vulnerabilities common in C/C++.
*   **System.Array**: All arrays inherit from `System.Array`, providing useful methods like `Sort`, `Reverse`, and `BinarySearch`.

#### Example
```csharp
// Single-dimensional
int[] numbers = new int[3];
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;

// Multidimensional (Matrix)
int[,] matrix = 
{
    { 1, 2 },
    { 3, 4 }
};

// Jagged (Array of Arrays)
int[][] jagged = new int[2][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
```

#### Line-by-Line Explanation
*   `int[]`: Declares an array of integers.
*   `new int[3]`: Allocates memory for 3 integers on the heap (initialized to 0).
*   `int[,]`: A rectangular array where every row has the same length.
*   `int[][]`: An array where each element is itself an array (can be different lengths).

#### Tests
[9 - Arrays.cs](../../CSharpStudy.Tests/CSharp1/9%20-%20Arrays.cs)

```csharp
[Fact]
public void Array_BoundsChecking_ThrowsException()
{
    int[] numbers = { 1, 2, 3 };
    Assert.Throws<IndexOutOfRangeException>(() => 
    {
        var x = numbers[5]; // Access invalid index
    });
}
```

#### Common Pitfalls / Gotchas
*   **Fixed Size**: You cannot resize an array. Use `List<T>` (C# 2.0) if you need dynamic sizing.
*   **0-Based Indexing**: The first element is at index 0, the last at `Length - 1`.
*   **Covariance**: Array covariance (assigning `string[]` to `object[]`) is supported but unsafe for writes (throws runtime exception if you add a non-string).

#### Performance Notes
*   **Bounds Checking**: Has a small cost, but the JIT compiler can often eliminate it inside loops.
*   **Locality**: Iterating arrays is extremely CPU-cache friendly.

#### Best Practices / Checklist
*   Prefer `List<T>` for collections that change size.
*   Use `Array` when performance is critical or size is fixed.
*   Use `foreach` for readability when index is not needed.

#### Related Topics
*   `List<T>` (Generics - C# 2.0)
*   `Span<T>` (Memory Safety - C# 7.2)
*   Collection Initializers (C# 3.0)

### Exception Handling

#### Summary
**Exception Handling** provides a structured, uniform way to handle runtime errors using `try`, `catch`, `finally`, and `throw`. It replaces error codes with objects that contain detailed error information.

#### Motivation / When to Use
*   **Runtime Errors**: Handle unexpected situations like file not found, network failure, or division by zero.
*   **Cleanup**: Ensure resources are released (in `finally` blocks) even if an error occurs.
*   **Validation**: Signal invalid arguments or state by throwing exceptions.

#### Benefits
*   **Separation of Concerns**: Keeps "happy path" logic separate from error handling code.
*   **Stack Traces**: Exceptions carry the call stack, making debugging easier.
*   **Propagation**: Errors bubble up the call stack automatically until caught, unlike return codes which must be manually checked at every level.

#### Improvements (C# specifics)
*   **Structured**: Unlike C++'s flexible exception types, C# exceptions must inherit from `System.Exception`.
*   **Finally**: Guaranteed execution block for cleanup.

#### Example
```csharp
public int Divide(int x, int y)
{
    try
    {
        return x / y;
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw; // Re-throw to let caller handle it too
    }
    finally
    {
        Console.WriteLine("Operation attempted.");
    }
}
```

#### Line-by-Line Explanation
*   `try { ... }`: Wraps code that might throw an exception.
*   `catch (DivideByZeroException ex)`: Catches a specific type of exception. `ex` contains details.
*   `throw;`: Re-throws the *original* exception, preserving the stack trace. `throw ex;` would reset the stack trace (bad practice).
*   `finally { ... }`: Executes always, whether an exception occurred or not.

#### Tests
[6 - ExceptionHandling.cs](../../CSharpStudy.Tests/CSharp1/6%20-%20ExceptionHandling.cs)

```csharp
[Fact]
public void Divide_ByZero_ThrowsException()
{
    Assert.Throws<DivideByZeroException>(() => Divide(10, 0));
}
```

#### Common Pitfalls / Gotchas
*   **Swallowing Exceptions**: Catching `Exception` and doing nothing (empty catch block) hides bugs.
*   **Throwing ex**: Using `throw ex` instead of `throw` resets the stack trace, making it hard to find the origin of the error.
*   **Control Flow**: Using exceptions for normal logic (e.g., `try { int.Parse(...) } catch`) is slow and confusing. Use `TryParse` instead.

#### Performance Notes
*   **Costly**: Throwing and catching exceptions is expensive (stack unwinding). Avoid using them for control flow in hot paths.

#### Best Practices / Checklist
*   Catch specific exceptions, not generic `Exception`.
*   Use `finally` or `using` blocks for cleanup.
*   Throw meaningful custom exceptions if standard ones don't fit.
*   Do not catch exceptions you cannot handle.

#### Related Topics
*   `using` statement (IDisposable)
*   Exception Filters (C# 6.0)

### Attributes

#### Summary
**Attributes** are declarative tags that allow you to add metadata to your code (assemblies, types, methods, properties, etc.). This metadata can be inspected at runtime using Reflection.

#### Motivation / When to Use
*   **Metadata**: Add information that isn't part of the core language logic (e.g., author, version, description).
*   **Behavior Modification**: Influence how the compiler or runtime handles code (e.g., `[Obsolete]`, `[Serializable]`, `[ThreadStatic]`).
*   **Framework Integration**: Tell frameworks how to map classes to database tables (Entity Framework), serialize to JSON (Json.NET), or expose API endpoints (ASP.NET).

#### Benefits
*   **Declarative**: Separates configuration from logic.
*   **Extensible**: You can define your own custom attributes inheriting from `System.Attribute`.
*   **Standardized**: A unified way to annotate code across the entire .NET ecosystem.

#### Improvements (C# specifics)
*   **Syntax**: Uses square brackets `[...]` (unlike Java's `@Annotation`).
*   **Compile-time checks**: Attribute parameters are validated at compile time (must be constant values).

#### Example
```csharp
[Serializable]
public class User
{
    [Obsolete("Use FullName instead")]
    public string Name { get; set; }

    [Custom("Metadata value")]
    public void Save() { }
}

public class CustomAttribute : Attribute
{
    public string Info { get; }
    public CustomAttribute(string info) => Info = info;
}
```

#### Line-by-Line Explanation
*   `[Serializable]`: A standard attribute indicating the class can be serialized.
*   `[Obsolete(...)]`: Marks a member as deprecated. The compiler will issue a warning if it's used.
*   `[Custom(...)]`: Applying a user-defined attribute. The compiler calls the attribute's constructor.

#### Tests
[18 - Attributes.cs](../../CSharpStudy.Tests/CSharp1/18%20-%20Attributes.cs)

```csharp
[Fact]
public void Attribute_CanBeRetrievedViaReflection()
{
    var method = typeof(User).GetMethod("Save");
    var attr = method.GetCustomAttribute<CustomAttribute>();
    
    Assert.Equal("Metadata value", attr.Info);
}
```

#### Common Pitfalls / Gotchas
*   **Passive**: Attributes don't *do* anything by themselves. Some code (compiler, runtime, or your own reflection code) must explicitly inspect and act on them.
*   **Parameters**: Attribute constructor arguments must be compile-time constants (literals, `typeof`, or arrays of these). You cannot pass dynamic objects.

#### Performance Notes
*   **Reflection Cost**: Retrieving attributes at runtime involves Reflection, which is slow. Frameworks often cache this information on startup.

#### Best Practices / Checklist
*   Suffix custom attribute classes with `Attribute` (e.g., `CustomAttribute`).
*   Use `[AttributeUsage]` to control where your attribute can be applied (classes, methods, etc.) and if it allows multiples.
*   Keep attributes simple (data containers).

#### Related Topics
*   Reflection
*   Generic Attributes (C# 11.0)

### Reflection

#### Summary
**Reflection** allows code to inspect and manipulate its own structure (assemblies, types, methods, properties) at runtime. It enables dynamic object creation and method invocation.

#### Motivation / When to Use
*   **Plug-in Architectures**: Load assemblies dynamically and instantiate types that implement a known interface.
*   **Object Mapping**: Libraries like AutoMapper or ORMs use reflection to map properties between objects.
*   **Serialization**: Inspecting properties to save an object's state to JSON/XML.

#### Benefits
*   **Dynamism**: Write code that works with types not known at compile time.
*   **Extensibility**: Build flexible frameworks that users can extend without recompiling the framework.

#### Improvements (C# specifics)
*   **System.Type**: The central class for reflection, representing a type declaration.
*   **Attributes**: Reflection is the mechanism used to read attributes.

#### Example
```csharp
using System.Reflection;

public class Robot
{
    public void Speak(string message) => Console.WriteLine($"Robot says: {message}");
}

// Runtime usage
Type type = typeof(Robot);
object instance = Activator.CreateInstance(type);
MethodInfo method = type.GetMethod("Speak");
method.Invoke(instance, new object[] { "Hello World" });
```

#### Line-by-Line Explanation
*   `typeof(Robot)`: Gets the `Type` object representing the `Robot` class metadata.
*   `Activator.CreateInstance(type)`: Creates a new instance of the type dynamically (equivalent to `new Robot()`).
*   `type.GetMethod("Speak")`: Finds the method metadata by name.
*   `method.Invoke(...)`: Calls the method on the given instance with arguments.

#### Tests
[21 - Reflection.cs](../../CSharpStudy.Tests/CSharp1/21%20-%20Reflection.cs)

```csharp
[Fact]
public void Reflection_InvokeMethod_Success()
{
    var type = typeof(Robot);
    var instance = Activator.CreateInstance(type);
    var method = type.GetMethod("Speak");
    
    // Redirect console to capture output if needed, or just verify no exception
    method.Invoke(instance, new object[] { "Test" });
}
```

#### Common Pitfalls / Gotchas
*   **Performance**: Reflection is significantly slower than direct calls. Avoid in tight loops.
*   **Safety**: No compile-time checking. Renaming a method breaks reflection code (runtime error).
*   **Complexity**: Code becomes harder to read and debug.

#### Performance Notes
*   **Caching**: Cache `MethodInfo` and `PropertyInfo` objects if you use them repeatedly.
*   **Fast Reflection**: For high performance, use `Delegate.CreateDelegate` or Expression Trees (C# 3.0) to compile reflection calls into delegates.

#### Best Practices / Checklist
*   Use Reflection only when necessary (e.g., frameworks, tools).
*   Prefer Interfaces/Generics for flexibility before resorting to Reflection.
*   Use `nameof(MyMethod)` instead of hardcoded strings to make refactoring safer.

#### Related Topics
*   Attributes
*   Expression Trees (C# 3.0)
*   `dynamic` keyword (C# 4.0)

### Operator Overloading

#### Summary
**Operator Overloading** allows you to define how standard operators (like `+`, `-`, `==`) behave when applied to your custom types (classes or structs).

#### Motivation / When to Use
*   **Mathematical Types**: Making types like `Complex`, `Vector`, or `Matrix` feel natural to use.
*   **Value Equality**: Defining `==` and `!=` for value-like objects.
*   **Domain Specific Languages**: Creating expressive syntax for specific domains (e.g., combining filters).

#### Benefits
*   **Readability**: `a + b` is often clearer than `a.Add(b)`.
*   **Consistency**: Allows custom types to behave like built-in types.

#### Improvements (C# specifics)
*   **Static**: Operators must be `public static` methods.
*   **Pairs**: Some operators must be overloaded in pairs (e.g., `==` and `!=`, `<` and `>`).
*   **Safety**: You cannot overload logical operators `&&` and `||` directly (they rely on `true`/`false` operators), preserving short-circuiting behavior.

#### Example
```csharp
public struct Complex
{
    public double Real { get; }
    public double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }
}
```

#### Line-by-Line Explanation
*   `public static Complex operator +`: Defines the addition operator. Must be static.
*   `(Complex a, Complex b)`: The operands. At least one must be of the containing type.
*   `return new Complex(...)`: Returns a new instance (operators should generally be immutable).

#### Tests
[26 - OperatorOverloading.cs](../../CSharpStudy.Tests/CSharp1/26%20-%20OperatorOverloading.cs)

```csharp
[Fact]
public void OperatorPlus_AddsComponents()
{
    var c1 = new Complex(1, 2);
    var c2 = new Complex(3, 4);
    var result = c1 + c2;
    
    Assert.Equal(4, result.Real);
    Assert.Equal(6, result.Imaginary);
}
```

#### Common Pitfalls / Gotchas
*   **Confusion**: Overloading operators for non-obvious operations (e.g., using `+` to add an item to a collection) can confuse readers.
*   **Equality**: If you overload `==`, you must also overload `!=` and override `Equals()` and `GetHashCode()`.
*   **Immutability**: Operators should return new values, not modify operands.

#### Performance Notes
*   **Inlining**: Simple operator overloads are often inlined by the JIT compiler, making them as fast as primitive operations.

#### Best Practices / Checklist
*   Only overload operators if the meaning is intuitive.
*   Ensure operations are symmetric and commutative where expected.
*   Always overload `==` and `!=` together.
*   Override `ToString()` to provide a meaningful representation.

#### Related Topics
*   Implicit and Explicit Conversions
*   `IEquatable<T>`

### Foreach and IDisposable

#### Summary
**Foreach** provides a clean, readable way to iterate over collections. **IDisposable** is an interface for deterministic cleanup of unmanaged resources. Crucially, `foreach` automatically calls `Dispose()` on the enumerator if it implements `IDisposable`.

#### Motivation / When to Use
*   **Iteration**: Looping through arrays, lists, or any `IEnumerable` collection without managing indices.
*   **Resource Management**: Ensuring file handles, database connections, or network sockets are closed immediately after use (via `using` statement or `foreach`).

#### Benefits
*   **Safety**: Eliminates off-by-one errors common in `for` loops.
*   **Abstraction**: Works on any collection (linked list, array, tree) regardless of internal structure.
*   **Cleanup**: The `using` statement (and `foreach`) guarantees `Dispose()` is called even if exceptions occur.

#### Improvements (C# specifics)
*   **Syntactic Sugar**: `foreach` compiles down to a `while` loop using `GetEnumerator()` and `MoveNext()`.
*   **Using Statement**: A shorthand for `try...finally` that calls `Dispose()`.

#### Example
```csharp
// Foreach
var names = new[] { "Alice", "Bob" };
foreach (var name in names)
{
    Console.WriteLine(name);
}

// Using / IDisposable
public class Logger : IDisposable
{
    public void Log(string msg) => Console.WriteLine(msg);
    public void Dispose() => Console.WriteLine("Logger disposed");
}

// Usage
using (var logger = new Logger())
{
    logger.Log("Work started");
} // Dispose called here automatically
```

#### Line-by-Line Explanation
*   `foreach (var name in names)`: Gets the enumerator from `names` and loops while `MoveNext()` returns true.
*   `class Logger : IDisposable`: Implements the contract for cleanup.
*   `using (...)`: Ensures `logger.Dispose()` is called at the end of the block, even if `Log` throws an exception.

#### Tests
[20 - ForEachIDisposable.cs](../../CSharpStudy.Tests/CSharp1/20%20-%20ForEachIDisposable.cs)

```csharp
[Fact]
public void UsingStatement_CallsDispose()
{
    bool disposed = false;
    var disposable = new DisposableAction(() => disposed = true);
    
    using (disposable)
    {
        // Do work
    }
    
    Assert.True(disposed);
}
```

#### Common Pitfalls / Gotchas
*   **Modification**: You cannot modify the collection (add/remove items) inside a `foreach` loop (throws `InvalidOperationException`).
*   **Capture**: In C# 1.0-4.0, the loop variable was captured outside the loop scope, causing issues with closures/lambdas. (Fixed in C# 5.0).
*   **Struct Enumerators**: `foreach` avoids boxing struct enumerators (like `List<T>.Enumerator`) for performance.

#### Performance Notes
*   **Arrays**: `foreach` on arrays is optimized by the JIT to be as fast as a `for` loop.
*   **Allocations**: `foreach` on `IEnumerable` (interfaces) causes boxing of struct enumerators. Use concrete types where possible.

#### Best Practices / Checklist
*   Prefer `foreach` over `for` for readability unless index access is needed.
*   Always implement `IDisposable` if your class owns unmanaged resources or other disposable objects.
*   Always use `using` when working with `IDisposable` objects.

#### Related Topics
*   Iterators (`yield return` - C# 2.0)
*   Async Streams (`await foreach` - C# 8.0)
*   Pattern-based using (C# 8.0)

### Entry Point: `static void Main`
*   **Summary**: The entry point of every C# application.
*   **Benefits**: Standardized entry point.
*   **Example**:
    ```csharp
    static void Main(string[] args) { }
    ```

### Checked and Unchecked Contexts
*   **Summary**: Controls overflow checking for integral-type arithmetic operations and conversions.
*   **Benefits**: Allows developers to explicitly choose between safety (throwing exceptions on overflow) and performance (ignoring overflow).
*   **Tests**: [23 - CheckUncheck.cs](../../CSharpStudy.Tests/CSharp1/23%20-%20CheckUncheck.cs)
*   **Example**:
    ```csharp
    checked
    {
        int z = int.MaxValue + 1; // Throws OverflowException
    }
    ```
