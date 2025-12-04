using System.Runtime.CompilerServices;

namespace CSharpStudy.Tests.CSharp9
{
    /**
     * Module initializers run automatically when an assembly is loaded.
     * Useful for one-time initialization, logging, or setting up global state.
     * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers
     **/
    public class ModuleInitializers
    {
        private static bool _wasInitialized = false;

        [ModuleInitializer]
        internal static void Initialize()
        {
            _wasInitialized = true;
            // This runs once when the assembly loads
        }

        [Fact]
        public void ModuleInitializer_RunsOnAssemblyLoad()
        {
            // The module initializer should have already run
            Assert.True(_wasInitialized);
        }
    }
}
