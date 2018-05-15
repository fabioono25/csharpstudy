using System;

namespace CSharpStudy
{
    public class Person{

        private DateTime _birthdate;

        public Person()
        {
        }

        public void SetBirthDate(DateTime birthdate){
            _birthdate = birthdate;
        }

        public DateTime GetBirthDate()
        {
            return _birthdate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Introduce(){
            System.Console.WriteLine("my name is: " + FirstName + " " + LastName);
        }
    }
}