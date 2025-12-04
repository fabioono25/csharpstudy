namespace CSharpStudy.Tests.CSharp14
{
    /**
     * Extension Members - C# 14's revolutionary feature
     * Allows creating extension properties and simplifies extension method syntax
     * Note: This is a future C# 14 feature - syntax is conceptual
     * https://github.com/dotnet/csharplang/issues/192
     **/
    public class ExtensionMembers
    {
        // Traditional extension method (C# 3.0)
        public static class StringExtensionsOld
        {
            public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);
        }

        // C# 14 Extension Members (conceptual syntax)
        // public extension StringExtensions for string
        // {
        //     // Extension property
        //     public bool IsEmpty => string.IsNullOrEmpty(this);
        //     
        //     // Extension method with simplified syntax
        //     public string Capitalize()
        //     {
        //         if (IsEmpty) return this;
        //         return char.ToUpper(this[0]) + this.Substring(1).ToLower();
        //     }
        // }

        [Fact]
        public void ExtensionMembers_TraditionalExample()
        {
            // Using traditional C# 3.0 extension methods
            string text = "";
            Assert.True(StringExtensionsOld.IsEmpty(text));
            
            string name = "alice";
            // In C# 14, this would be cleaner:
            // Assert.True(name.IsEmpty); // Property-like syntax
            // Assert.Equal("Alice", name.Capitalize());
        }

        [Fact]
        public void ExtensionMembers_ConceptualBenefits()
        {
            /// C# 14 Extension Members would enable:
            /// 1. Extension properties (not just methods)
            /// 2. Simpler syntax without 'this' keyword
            /// 3. Better intellisense and discoverability
            /// 4. More natural API design
            
            // For now, we use traditional approach
            var numbers = new List<int> { 1, 2, 3 };
            Assert.Equal(3, numbers.Count); // Built-in property
        }
    }
}
