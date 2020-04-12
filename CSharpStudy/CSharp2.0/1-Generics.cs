namespace CSharpStudy.CSharp2_0
{
    public class GenericsTest
    {
        public static void ExecuteExample()
        {
            //In this example, we must to explicitly cast the object in the return
            Stack s = new Stack();
            s.Push(new ClassTest());
            ClassTest c = (ClassTest)s.Pop(); //casting (performance penalty)

            //Here, we have a boxing ocurring when adding a value type
            //and an unboxing when retrieving
            s.Push(3);
            int i = (int)s.Pop();

            //The Stack accepts instances different classes, all derived from object
            //However, if you try casting in a different you, you will have an exception at runtime 
            s.Push(new ClassTest());
            AnotherClassTest c2 = (AnotherClassTest)s.Pop(); //InvalidCastException

            //using generics, you ensure the type you are adding (no cast needed)
            Stack<ClassTest> s2 = new Stack<ClassTest>();
            s2.Push(new ClassTest());
            ClassTest c3 = s2.Pop(); //no cast

            //Now, if your stack is of type ClassTest, you will have a type error at compile time
            AnotherClassTest c4 = (AnotherClassTest)s2.Pop(); //Design type error

            //Creating a Stack of type int, it'll not incur in boxing/unboxing. 
            //Now, the value type is saved directly in the array, not the pointer to a reference type (object)
            Stack<int> s3 = new Stack<int>();
            s3.Push(3);
            int x = s3.Pop(); 
        }        
    }

    internal class Stack {
        private object[] items = new object[100];
        private int index;

        public void Push(object data){
            items[index++] = data;
        }
        public object Pop(){
            return items[--index];
        }
    }

     internal class Stack<T> {
        private T[] items = new T[100];
        private int index;

        public void Push(T data){
            items[index++] = data;
        }
        public T Pop(){
            return items[--index];
        }
    }

    internal class ClassTest{

    }

    internal class AnotherClassTest{

    }
}