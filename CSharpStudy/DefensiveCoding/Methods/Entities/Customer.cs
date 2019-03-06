using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpStudy.DefensiveCoding.Methods
{
    //represent entity - information
    public class Customer
    {
        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal void ValidateEmail()
        {
            throw new NotImplementedException();
        }
    }
}
