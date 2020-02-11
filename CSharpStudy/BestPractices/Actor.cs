using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpStudy.BestPractices
{
    public class Actor
    {
        public Actor()
        {
            Console.WriteLine("An Actor is born!");
        }

        public Actor(string actorName): this() //force the execution of default constructor
        {
            ActorName = actorName;
        }

        public string JobTitle { get; set; }
        public string ActorName { get; }

        public string GetOccupation()
        {
            JobTitle = "Actor";
            return JobTitle;
        }
    }
}
