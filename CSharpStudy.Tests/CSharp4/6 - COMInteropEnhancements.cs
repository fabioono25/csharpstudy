using System.Runtime.InteropServices;

namespace CSharpStudy.Tests.CSharp4
{
    /**
    * The COM (Component Object Model) library is a technology developed by Microsoft that enables software components to interact with each other across different programming languages and platforms. 
        It provides a standardized way for components to communicate and work together.
    * improve interoperability with COM. Better support for handling optional parameters, named parameters and late binding when working with COM objects.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-access-office-onterop-objects
    **/
    public class COMInteropEnhancementsTest
    {
        [Fact]
        public void Example()
        {
            // Creating an instance of a COM object
            // we create an instance of a COM object by casting it to the ICOMInterface interface. Note that the SomeCOMObject class is marked with the ComVisible(true) attribute, allowing it to be visible to COM.
            ICOMInterface comObject = (ICOMInterface)new SomeCOMObject();

            // Calling a method on the COM object
            // We call the SomeMethod method on the COM object, which is defined in the ICOMInterface.
            comObject.SomeMethod();
        }
    }

    /**
      We define a COM interface ICOMInterface using the ComImport attribute, which instructs the runtime to import the interface from a COM type library. 
      The Guid attribute specifies the GUID of the interface, and the InterfaceType attribute indicates that it's an interface.
    **/
    [ComImport]
    [Guid("00000000-0000-0000-0000-000000000001")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface ICOMInterface
    {
        void SomeMethod();
    }


    [ComVisible(true)]
    [Guid("00000000-0000-0000-0000-000000000002")]
    class SomeCOMObject : ICOMInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("SomeMethod called");
        }
    }
}
