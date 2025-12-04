# Chapter 4 --- C# 3.0: The Functional Shift

## Summary
Released in 2007 with Visual Studio 2008, C# 3.0 was a revolutionary release that introduced **Language Integrated Query (LINQ)**. This version bridged the gap between object-oriented and functional programming, allowing developers to write declarative code to manipulate data from various sources (Objects, SQL, XML) using a consistent syntax.

## Highlights & Internal Changes
*   **Expression Trees**: Allowed code (lambdas) to be represented as data structures, enabling LINQ providers (like Entity Framework) to translate C# code into SQL.
*   **Type Inference**: The compiler became smarter, capable of inferring types for local variables.

## Topics

### LINQ (Query and Method syntax)

#### Summary
**Language Integrated Query (LINQ)** provides a consistent, strongly-typed way to query data from various sources (collections, databases, XML) using C# syntax. It supports both query syntax (SQL-like) and method syntax (fluent API).

#### Motivation / When to Use
*   **Collections**: Filtering, sorting, grouping in-memory data.
*   **Databases**: Querying SQL via Entity Framework or LINQ to SQL.
*   **XML**: Parsing and querying XML documents with LINQ to XML.

#### Benefits
*   **Declarative**: Describe *what* you want, not *how* to get it.
*   **Type Safety**: Compile-time checking of queries.
*   **Composable**: Chain operations together fluently.

#### Improvements (C# specifics)
*   **Query Syntax**: `from ... where ... select` resembles SQL.
*   **Method Syntax**: Uses extension methods like `.Where()`, `.Select()`, `.OrderBy()`.
*   **Deferred Execution**: Queries execute only when iterated.

#### Example
```csharp
var employees = new List<Employee> { /* ... */ };

// Query Syntax
var highEarners = from e in employees
                  where e.Salary > 100000
                  orderby e.Name
                  select e;

// Method Syntax (equivalent)
var highEarners = employees
    .Where(e => e.Salary > 100000)
    .OrderBy(e => e.Name);
```

#### Line-by-Line Explanation
*   `from e in employees`: Declares range variable `e` iterating over `employees`.
*   `where e.Salary > 100000`: Filters employees with salary above 100k.
*   `.Where(...)`: Extension method equivalent, takes a lambda predicate.

#### Tests
[6 - QueryExpressions.cs](../../CSharpStudy.Tests/CSharp3/6%20-%20QueryExpressions.cs)

```csharp
[Fact]
public void LinqQuery_FiltersCorrectly()
{
    var nums = new[] { 1, 2, 3, 4, 5 };
    var evens = nums.Where(n => n % 2 == 0).ToList();
    
    Assert.Equal(new[] { 2, 4 }, evens);
}
```

#### Common Pitfalls / Gotchas
*   **Deferred Execution**: The query runs when you iterate (e.g., `foreach`, `.ToList()`). If data changes, results change.
*   **Multiple Enumeration**: Iterating a query twice executes it twice. Use `.ToList()` to materialize.
*   **N+1 Problem**: In EF, lazy-loading can cause one query per item.

#### Performance Notes
*   LINQ to Objects: Small overhead for delegates but negligible for most workloads.
*   LINQ to SQL/EF: Translates to SQL; complex queries may generate inefficient SQL.

#### Best Practices / Checklist
*   Use method syntax for simple queries; query syntax for complex joins.
*   Call `.ToList()` at the end to control when the query runs.
*   Use `.AsNoTracking()` in EF for read-only queries.

#### Related Topics
*   Lambda Expressions
*   Expression Trees
*   Entity Framework

### Lambdas and Expression Trees

#### Summary
**Lambda expressions** (`=>`) are concise anonymous functions. **Expression Trees** represent lambdas as data structures, enabling code to be analyzed and translated (e.g., to SQL).

#### Motivation / When to Use
*   **LINQ**: Passing predicates to `.Where()`, `.Select()`, etc.
*   **Callbacks**: Short inline functions for events or async continuations.
*   **ORMs**: Expression trees let Entity Framework convert C# to SQL.

#### Benefits
*   **Brevity**: `x => x * x` vs `delegate(int x) { return x * x; }`.
*   **Flexibility**: Can be compiled to delegates or expression trees.

#### Improvements (C# specifics)
*   **`=>` Syntax**: Arrow operator separates parameters from body.
*   **Type Inference**: Parameter types often inferred.
*   **Expression<Func<>>**: Wraps lambda as a data structure.

#### Example
```csharp
// Lambda as delegate
Func<int, int> square = x => x * x;
Console.WriteLine(square(5)); // 25

// Lambda with multiple parameters
Func<int, int, int> add = (a, b) => a + b;

// Expression Tree (for LINQ providers)
Expression<Func<int, bool>> isEven = x => x % 2 == 0;
```

#### Line-by-Line Explanation
*   `x => x * x`: Single parameter `x`, returns `x * x` (no braces needed for single expression).
*   `(a, b) => a + b`: Multiple parameters require parentheses.
*   `Expression<...>`: Compiler generates a tree structure instead of compiled IL.

#### Tests
[5 - LambdaExpressions.cs](../../CSharpStudy.Tests/CSharp3/5%20-%20LambdaExpressions.cs)

```csharp
[Fact]
public void Lambda_CalculatesSquare()
{
    Func<int, int> square = x => x * x;
    Assert.Equal(25, square(5));
}
```

#### Common Pitfalls / Gotchas
*   **Closure Capture**: Lambdas capture variables by reference. Modifying `i` after defining a lambda affects the lambda.
*   **Async Lambdas**: Use `async () => await ...` for async operations.

#### Performance Notes
*   Each lambda creates a delegate instance. Avoid creating in hot loops if possible.
*   Expression trees have parsing overhead; use caching.

#### Best Practices / Checklist
*   Use lambdas for inline, short logic.
*   Avoid complex statements in lambdas; extract to named methods.
*   Use `Expression<>` only when needed for translation.

#### Related Topics
*   LINQ
*   `Func<>` and `Action<>` delegates
*   Dynamic LINQ

### Extension Methods

#### Summary
**Extension Methods** allow you to "add" methods to existing types without modifying the original source code. Defined as static methods, they appear as instance methods on the extended type.

#### Motivation / When to Use
*   **Fluent APIs**: LINQ's `.Where()`, `.Select()` are extension methods on `IEnumerable<T>`.
*   **Utility Methods**: Adding helpers to built-in types (e.g., `"hello".Capitalize()`).
*   **Interface Extensions**: Adding default behavior to interface implementers.

#### Benefits
*   **Non-invasive**: Extend sealed classes or types you don't own.
*   **Discoverability**: IntelliSense shows extension methods.

#### Improvements (C# specifics)
*   **`this` Modifier**: First parameter uses `this` keyword to specify extended type.
*   **Static Class Requirement**: Must be defined in a static class.

#### Example
```csharp
public static class StringExtensions
{
    public static bool IsCapitalized(this string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        return char.IsUpper(s[0]);
    }
}

// Usage - looks like instance method
bool result = "Hello".IsCapitalized(); // true
```

#### Line-by-Line Explanation
*   `this string s`: The `this` keyword marks `s` as the instance the method extends.
*   Calling `"Hello".IsCapitalized()` is equivalent to `StringExtensions.IsCapitalized("Hello")`.

#### Tests
[4 - ExtensionMethods.cs](../../CSharpStudy.Tests/CSharp3/4%20-%20ExtensionMethods.cs)

```csharp
[Fact]
public void ExtensionMethod_WorksOnString()
{
    Assert.True("Hello".IsCapitalized());
    Assert.False("hello".IsCapitalized());
}
```

#### Common Pitfalls / Gotchas
*   **Null**: Extension methods can be called on `null` (no `NullReferenceException` until you access `this`).
*   **Priority**: Instance methods take precedence over extension methods with the same name.
*   **Discovery**: Must import the namespace containing the static class.

#### Performance Notes
*   No overhead—they're compiled as static method calls.

#### Best Practices / Checklist
*   Group related extensions in logically named static classes.
*   Avoid polluting types with too many extensions.
*   Ensure namespace is imported (`using ...`).

#### Related Topics
*   LINQ (built on extension methods)
*   Static Classes

### `var` keyword (Implicitly typed locals)

#### Summary
**`var`** instructs the compiler to infer a local variable's type from the right-hand side expression. The variable is still strongly typed at compile time.

#### Motivation / When to Use
*   **Complex Types**: Avoid repeating `Dictionary<string, List<int>>` twice.
*   **Anonymous Types**: The only way to declare them (no explicit type name).
*   **LINQ Results**: Query return types can be complex.

#### Benefits
*   **Readability**: Less noise, especially with generics.
*   **Refactoring**: Changing the right side updates the type automatically.

#### Improvements (C# specifics)
*   **Strong Typing**: `var` is NOT dynamic. Type is fixed at compile time.
*   **Must Initialize**: `var x;` is invalid—requires an initializer.

#### Example
```csharp
var name = "Alice";                    // string
var numbers = new List<int> { 1, 2 };  // List<int>
var query = numbers.Where(n => n > 0); // IEnumerable<int>
```

#### Line-by-Line Explanation
*   `var name = "Alice"`: Compiler infers `string` from the literal.
*   `var query = ...`: LINQ result type is inferred. Avoids writing `IEnumerable<int>`.

#### Tests
[1 - ImplicitTypedLocalVariables.cs](../../CSharpStudy.Tests/CSharp3/1%20-%20ImplicitTypedLocalVariables.cs)

#### Common Pitfalls / Gotchas
*   **Overuse**: Using `var` for `var x = 5;` can hurt readability (what type is it?).
*   **Numeric Literals**: `var x = 1;` is `int`, `var y = 1.0;` is `double`.

#### Best Practices / Checklist
*   Use `var` when the type is obvious from the right side (`new List<int>()`).
*   Avoid `var` when the type isn't clear (`var result = GetData()`).
*   Always use `var` for anonymous types.

#### Related Topics
*   Anonymous Types
*   `dynamic` keyword (C# 4.0)

### Object/Collection Initializers

#### Summary
**Object Initializers** allow setting properties in a single expression after construction. **Collection Initializers** allow populating collections inline using brace syntax.

#### Motivation / When to Use
*   **Immutable-Style**: Initialize all properties at once without mutable setters.
*   **Readability**: See all values in one place.
*   **LINQ Projections**: Create new objects with `new { ... }`.

#### Benefits
*   **Conciseness**: Replace multiple assignment statements with one expression.
*   **Works with Constructors**: Can combine with constructor parameters.

#### Improvements (C# specifics)
*   **Brace Syntax**: `{ Property = Value }` after `new Type()`.
*   **Collection Syntax**: `{ item1, item2 }` calls `Add()` implicitly.

#### Example
```csharp
// Object Initializer
var person = new Person
{
    Name = "Alice",
    Age = 30
};

// Collection Initializer
var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Dictionary Initializer
var ages = new Dictionary<string, int>
{
    { "Alice", 30 },
    { "Bob", 25 }
};
```

#### Line-by-Line Explanation
*   `new Person { ... }`: Creates instance then sets `Name` and `Age`.
*   `new List<int> { 1, 2, ... }`: Calls `Add(1)`, `Add(2)`, etc.

#### Tests
[2 - ObjectCollectionInitializers.cs](../../CSharpStudy.Tests/CSharp3/2%20-%20ObjectCollectionInitializers.cs)

#### Common Pitfalls / Gotchas
*   **Requires Settable Properties**: Object initializers need writable properties.
*   **Collection Add**: Collection must implement `IEnumerable` and have an `Add` method.

#### Best Practices / Checklist
*   Use for creating objects with multiple properties.
*   Prefer over separate assignment statements.

#### Related Topics
*   Anonymous Types
*   Target-typed `new` (C# 9.0)


### Anonymous Types

#### Summary
**Anonymous Types** are compiler-generated immutable types with no name, created using `new { ... }` syntax. Properties are inferred from the initializer.

#### Motivation / When to Use
*   **LINQ Projections**: Select a subset of properties without creating a DTO.
*   **Temporary Groupings**: Quick data structures within a method.

#### Benefits
*   **No Boilerplate**: No need to declare a class for one-time use.
*   **Immutable**: Properties are read-only.

#### Improvements (C# specifics)
*   **Inferred Property Names**: `new { p.Name }` creates a `Name` property.
*   **Structural Equality**: Two anonymous types with the same properties are equal.

#### Example
```csharp
var person = new { Name = "Alice", Age = 30 };
Console.WriteLine(person.Name); // Alice

// LINQ projection
var employees = new[] { new { Name = "Bob", Dept = "IT" } };
var names = employees.Select(e => new { e.Name }).ToList();
```

#### Line-by-Line Explanation
*   `new { Name = "Alice", Age = 30 }`: Creates an anonymous object with two properties.
*   `{e.Name}`: Property name inferred from `Name`; equivalent to `{ Name = e.Name }`.

#### Tests
[3 - AnonymousTypes.cs](../../CSharpStudy.Tests/CSharp3/3%20-%20AnonymousTypes.cs)

```csharp
[Fact]
public void AnonymousType_HasExpectedProperties()
{
    var obj = new { X = 1, Y = 2 };
    Assert.Equal(1, obj.X);
    Assert.Equal(2, obj.Y);
}
```

#### Common Pitfalls / Gotchas
*   **Scope**: Cannot pass outside the method (no named type to declare).
*   **Mutable Fields**: Properties are read-only; you cannot modify them.

#### Best Practices / Checklist
*   Use within method scope only.
*   For returning data, use records (C# 9.0) or tuples.

#### Related Topics
*   Records (C# 9.0)
*   Tuples (C# 7.0)


### Partial Methods

#### Summary
**Partial Methods** are methods declared in a partial class that can be optionally implemented. If not implemented, the compiler removes the declaration and all calls.

#### Motivation / When to Use
*   **Generated Code**: Code generators can define hooks (e.g., `OnPropertyChanged`) that developers may optionally implement.
*   **Extensibility**: Framework-provided templates with optional customization.

#### Benefits
*   **Zero Overhead**: If not implemented, no runtime cost (call is removed).
*   **Clean API**: Generated code remains untouched.

#### Improvements (C# specifics)
*   **C# 3.0**: Must be `void`, no access modifiers allowed.
*   **C# 9.0**: Extended partial methods allow return values and access modifiers.

#### Example
```csharp
// Generated code (File1.cs)
partial class Customer
{
    partial void OnNameChanging(string value);
    
    private string _name;
    public string Name
    {
        set
        {
            OnNameChanging(value); // Removed if not implemented
            _name = value;
        }
    }
}

// Developer code (File2.cs)
partial class Customer
{
    partial void OnNameChanging(string value)
    {
        Console.WriteLine($"Name changing to {value}");
    }
}
```

#### Line-by-Line Explanation
*   `partial void OnNameChanging(...)`: Declaration. No body.
*   Implementation in another file: Provides the body.

#### Tests
[8 - PartialMethods.cs](../../CSharpStudy.Tests/CSharp3/8%20-%20PartialMethods.cs)

#### Common Pitfalls / Gotchas
*   **No Return Value (C# 3.0-8.0)**: Partial methods must return `void` (until C# 9.0).
*   **Private by Default**: Cannot specify access modifiers in older versions.

#### Best Practices / Checklist
*   Use for generated code hooks.
*   Consider events for more general extensibility.

#### Related Topics
*   Partial Classes (C# 2.0)
*   Extended Partial Methods (C# 9.0)
