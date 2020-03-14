namespace CSharpStudy
{
    public class Car : Vehicle
    {
        public Car(string registrationNumber)
            : base(registrationNumber)
        {
            System.Console.WriteLine("initialize car {0}", registrationNumber);
        }
    }

}
