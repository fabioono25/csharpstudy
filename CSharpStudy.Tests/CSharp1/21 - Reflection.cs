using System.Reflection;
using System.Reflection.Emit;

/**
  *  reflection refers to the ability of a program to examine and manipulate its own structure and metadata at runtime. 
  * It provides a way to inspect and analyze types, classes, methods, properties, and other elements of a program dynamically, without knowing them at compile time.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection
  **/

namespace CSharpStudy.Tests.CSharp1
{
  public class ReflectionTest
  {
    [Fact]
    public void ExecuteExample()
    {
      int age = 29;
      Type ageType = age.GetType();
      Console.WriteLine(ageType); //System.Int32

      //Gets the location regarding the process executable in the default application domain
      string path = Assembly.GetEntryAssembly().Location;

      //Gets the assembly that contains the code that is currently executing.
      foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
      {
        Console.WriteLine($"Class {type.Name}"); //print all class names
      }

      // Topic 1: Retrieve information about types and their members
      Type myClassType = typeof(MyClass);
      Console.WriteLine("Class: " + myClassType.Name);

      PropertyInfo propertyInfo = myClassType.GetProperty("MyProperty");
      Console.WriteLine("Property: " + propertyInfo.Name);

      MethodInfo methodInfo = myClassType.GetMethod("MyMethod");
      Console.WriteLine("Method: " + methodInfo.Name);

      // Topic 2: Invoke methods dynamically
      MyClass instance = new MyClass();
      methodInfo.Invoke(instance, null);

      // Topic 3: Get and set property and field values dynamically
      propertyInfo.SetValue(instance, 42);
      int propertyValue = (int)propertyInfo.GetValue(instance);
      Console.WriteLine("Property Value: " + propertyValue);

      // Topic 4: Create instances of types dynamically
      Type stringType = Type.GetType("System.String");
      object stringInstance = Activator.CreateInstance(stringType);
      Console.WriteLine("String Instance: " + stringInstance.GetType().Name);

      // Topic 5: Explore and interact with attributes attached to program elements
      CustomAttribute attribute = (CustomAttribute)methodInfo.GetCustomAttribute(typeof(CustomAttribute));
      Console.WriteLine("Attribute Data: " + attribute.Data);

      // Topic 6: Generate code dynamically (not demonstrated in this example)
      // Create a dynamic assembly (a compiled unit of code that contains executable code, type definitions, and metadata. It is the fundamental building block of any .NET application or library)
      AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
      AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

      // Create a dynamic module
      ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

      // Create a dynamic type
      TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);

      // Create a dynamic method
      MethodBuilder methodBuilder = typeBuilder.DefineMethod("DynamicMethod", MethodAttributes.Public | MethodAttributes.Static, typeof(void), null);
      ILGenerator ilGenerator = methodBuilder.GetILGenerator();

      // Emit IL instructions
      ilGenerator.Emit(OpCodes.Ldstr, "Dynamic Method Called");
      ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
      ilGenerator.Emit(OpCodes.Ret);

      // Create the type and get a MethodInfo for the dynamic method
      Type dynamicType = typeBuilder.CreateType();
      MethodInfo dynamicMethod = dynamicType.GetMethod("DynamicMethod");

      // Invoke the dynamic method
      dynamicMethod.Invoke(null, null);
    }

    public class MyClass
    {
      public int MyProperty { get; set; }

      [Custom("CustomAttribute Data")]
      public void MyMethod()
      {
        Console.WriteLine("MyMethod called.");
      }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAttribute : Attribute
    {
      public string Data { get; }

      public CustomAttribute(string data)
      {
        Data = data;
      }
    }
  }


}