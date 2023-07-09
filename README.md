What is the C# History?
=====================
The C# History is a compound of examples that can show how the language was growing during the years. It'll start with the basic concepts of an Oriented-Programming Language, until newer and better features.

## How to use the material
For each version of the language we have a folder containing the examples. It'll have examples and comments so be free to copy and use as reference.

You can see the series containing articles about the main features throught the history of this language in the blog [My Life in Dev].(https://www.mylifeindev.com/)

## If you like it! :star:
If you liked the examples, give a star!

## About C#

C# is an object-oriented language that was born in 2002, with the strategy of Microsoft to provide a more robust and strongly typed language. To achieve this, the idea was following some design goals defined by ECMA.

Design goals from ECMA for C#:
- intended to be simple, modern, general purpose, OOP;
- strongly type checking, array bound checking, check unitialized variables;
- automatic garbage collection;
- distributed environments;
- programmer portability;
- support to internationalization;
- suitable for both hosted and embedded systems.

During these more than 15 years, the language is gaining new improvements. Here are the versions:


Version 1.0:
- Classes and Objects
- Inheritance
- Encapsulation
- Polymorphism
- Memory Management: 
  - Manage execution: automatic memory management and the concept of garbage collection. Value objects are allocated on the stack, while reference ones are part of the heap. GC traverses the object graph (Marking Phase) and then scans the entire heap for unmarked objects (Sweeping Phase). The objects are divided in different generations, based on their lifetime: 
    - Generation 0: Contains short-lived objects that are typically created and collected quickly.
    - Generation 1: Contains objects that have survived one garbage collection cycle.
    - Generation 2: Contains long-lived objects that have survived multiple garbage collection cycles.
  - It is important to stress that GC doesn't handled the cleanup of some resources, like DB connections or network sockes. This is why we have IDisposable interface and using statements.
- Exceptions
- Delegates: are used to define a type that represents a reference to a method or a group of methods. They provide a way to encapsulate and pass methods as parameters or store them in variables, enabling callbacks and dynamic invocation of methods. Advantages:
  - decoupling of components.
  - flexibility and extensibility
  - functional programming
  - async programming
  - customizations
- Events: build upon delegates and are used to provide a standardized way of implementing the publisher-subscriber pattern. They allow objects to notify other objects when certain actions or states occur, facilitating event-driven programming.
- Arrays
- Iteration Statements
- Conditional Staments
- Structs
- Enums
- Value Types
- Reference Types
- Boxing and Unboxing
- Classes
- Interfaces
- Delegates
- Events
- Attributes

Version 1.2
- ForEach Support for IDisposable
- Property Declarations
- Changing Attributes
- Reflection
- Unsafe
- Check and Uncheck
- Constructors and Destructors
- Using keyword

Version 2.0
- Generics
- Partial Types
- Anonymous Methods
- Nullable Value Types
- Iterators
- Covariance and Contravariance
- Getters and Setters Accessibility
- Delegate Inference
- Static Classes

Version 3.0
- Auto-Implemented Properties
- Anonymous Types
- Query Expressions
- Lambda Expressions
- Expression Trees
- Extension Methods
- Implicit Typed Local Variables
- Partial Methods
- Objects Colections Initializers

Version 4.0
- Named Arguments
- Optional Parameters
- Dynamics
- Covariance and Contravariance for Generic Types

Version 5.0
- CallerInfoAttributes
- Asynchronous Methods

Version 6.0
- 

Version 7.0
- 

Version 8.0
- 

Version 9.0
- 
