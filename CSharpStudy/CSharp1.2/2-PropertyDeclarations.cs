namespace CSharpStudy.CSharp1_2
{
    public class PropertyDeclarations
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        //Type 'PropertyDeclarations' already reserves a member called 'get_Age' with the same parameter types [CSharpStudy]csharp(CS0082)
        // public int get_Age() {
        //     return 1;
        // }

        // public void set_Age(int age) {
        // }                  
        
        // public int getAge() {
        //     return 1;
        // }

        // public void setAge(int age) {
        // }         

    }
}