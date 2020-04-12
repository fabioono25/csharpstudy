namespace CSharpStudy.CSharp2_0
{
    public class PartialTypes
    {
        public static void ExecuteExample()
        {
            PartialTest testPartial = new PartialTest();
            testPartial.Method1();
            testPartial.Method2();
            testPartial.Method3();
            testPartial.MethodPartialTest1();
            testPartial.MethodPartialTest2();
        }        
    }

    internal partial class PartialTest : ITest
    {
        public void MethodPartialTest1(){}

        public void Method1()
        {
            throw new System.NotImplementedException();
        }

        public void Method2()
        {
            throw new System.NotImplementedException();
        }

        public void Method3()
        {
            throw new System.NotImplementedException();
        }
    }

    internal partial class PartialTest {
        public void MethodPartialTest2(){}
    }

    internal partial interface ITest {
        void Method1();
    }


    internal partial interface ITest {
        void Method2();
    }


    internal partial interface ITest {
        void Method3();
    }
}