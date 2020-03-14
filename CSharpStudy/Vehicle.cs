namespace CSharpStudy
{
    public class Vehicle
    {
        private readonly string _registrationNumber;
        // public Vehicle(){
        //     System.Console.WriteLine("initialize vehicle");
        // }

        public Vehicle(string registrationNumber)
        {
            _registrationNumber = registrationNumber;

            System.Console.WriteLine("vehicle initialized {0}", _registrationNumber);
        }
    }
}
