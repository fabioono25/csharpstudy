namespace CSharpStudy.Tests.CSharp2
{
    /**
    * Environment class provides information about, and means to manipulate, the current environment and platform.
    **/
    public class EnvironmentClassTest
    {
      [Fact]
      public void EnvironmentTest() {
        var currentDirectory = Environment.CurrentDirectory; //The current directory of the application
        var machineName = Environment.MachineName; // The NetBIOS name of this local computer
        var newLine = Environment.NewLine; // A string containing "\r\n" for non-Unix platforms, or a string containing "\n" for Unix platforms
        var osVersion = Environment.OSVersion; // An OperatingSystem object that contains the current platform identifier and version number
        var processorCount = Environment.ProcessorCount; // The number of processors on the current machine
        var systemDirectory = Environment.SystemDirectory; // The fully qualified path of the system directory
        var systemPageSize = Environment.SystemPageSize; // The number of bytes in the operating system's memory page
        var tickCount = Environment.TickCount; // Gets the number of milliseconds elapsed since the system started
        var userDomainName = Environment.UserDomainName; // The network domain name associated with the current user
        var userName = Environment.UserName; // The user name associated with the current thread
        var version = Environment.Version; // Gets a Version object that describes the major, minor, build, and revision numbers of the common language runtime
        var workingSet = Environment.WorkingSet; // Gets the amount of physical memory mapped to the process context
      }
    }
}