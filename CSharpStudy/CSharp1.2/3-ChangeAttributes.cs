using System;

namespace CSharpStudy.CSharp1_2
{
    [AttributeUsage(AttributeTargets.All)]
    public class ClassWithCustomAttribute: Attribute {

        private string message;

        public string Message {
            get {
                return message;
            }
            set {
                message = value;
            }
        }

        public ClassWithCustomAttribute() {
        }
    }

    //'ClassWithCustomAttribute.message' is inaccessible due to its protection level [CSharpStudy]csharp(CS0122)
    //[ClassWithCustomAttribute(message = "Changing the message")]
    public class TestClass {

    }
}