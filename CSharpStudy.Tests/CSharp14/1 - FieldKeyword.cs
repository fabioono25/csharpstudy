namespace CSharpStudy.Tests.CSharp14
{
    /**
     * Field Keyword (Stabilized in C# 14)
     * Allows accessing the backing field of auto-properties
     * https://github.com/dotnet/csharplang/issues/140
     **/
    public class FieldKeyword
    {
        // Note: 'field' keyword is a future C# 14 feature
        // This demonstrates what it will enable
        public class PersonWithValidation
        {
            private string _name = "";
            
            // Current C# way (before 'field' keyword)
            public string Name
            {
                get => _name;
                set => _name = value?.Trim() ?? "";
            }
            
            // C# 14 'field' keyword syntax (commented - not yet available)
            // public string Email
            // {
            //     get => field;
            //     set => field = value?.ToLower().Trim() ?? "";
            // }
        }

        [Fact]
        public void FieldKeyword_CurrentApproach()
        {
            var person = new PersonWithValidation 
            { 
                Name = "  Alice  " 
            };
            
            // Trimmed automatically via property setter
            Assert.Equal("Alice", person.Name);
        }

        public class Product
        {
            private decimal _price;
            
            // Without 'field' keyword, needs explicit backing field
            public decimal Price
            {
                get => _price;
                set => _price = value < 0 ? 0 : value;
            }
            
            // C# 14 would simplify to:
            // public decimal Price
            // {
            //     get => field;
            //     set => field = value < 0 ? 0 : value;
            // }
        }

        [Fact]
        public void FieldKeyword_ValidationExample()
        {
            var product = new Product { Price = -10 };
            
            // Negative price clamped to 0
            Assert.Equal(0, product.Price);
            
            product.Price = 99.99m;
            Assert.Equal(99.99m, product.Price);
        }

        [Fact]
        public void FieldKeyword_Benefits()
        {
            /// The 'field' keyword in C# 14 will:
            /// 1. Eliminate need for explicit backing fields
            /// 2. Enable validation in auto-property setters
            /// 3. Reduce boilerplate code
            /// 4. Maintain encapsulation
            
            // For now, we use traditional backing fields
            var person = new PersonWithValidation();
            person.Name = "Bob";
            Assert.Equal("Bob", person.Name);
        }
    }
}
