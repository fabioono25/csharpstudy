using System.Collections.Generic;

namespace CSharpStudy
{
    #region C# Intermediate
    // class Person2{

    //     public string Name { get; set; }

    //     public static Person2 Parse(string str){
    //         var person = new Person2();

    //         person.Name = str;

    //         return person;
    //     }

    // }  

    public class Customer
    {
        public int Id;
        public string Name;

        //public List<Order> Orders;
        public readonly List<Order> Orders = new List<Order>(); //personal taste

        private string Email;

        public Customer()
        {
            // Orders = new List<Order>();
        }

        public Customer(int id)
            :this()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            :this(id)
        {
            this.Name = name;
        }

        public void Promote(){
            var rating = CalculateRating(CalculateRating: true);

            if (rating == 0)
                System.Console.WriteLine("promoted to level 1");
            else
                System.Console.WriteLine("promoted to level 2");
        }

        protected int CalculateRating(bool CalculateRating){
            return 0;
        }
    }  
    #endregion    
}
