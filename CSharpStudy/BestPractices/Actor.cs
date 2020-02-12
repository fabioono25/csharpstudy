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
        private string actorName;

        public string ActorName
        {
            get { return actorName; }
            set {
                var formattedName = value?.Trim();
                actorName = formattedName; 
            }
        }

        public int ActorAge { get; set; }
        public string ActorDescription { get; set; } = "Regular Actor";

        public string GetOccupation()
        {
            JobTitle = "Actor";
            return JobTitle;
        }

        /// <summary>
        /// Books actor and not date specified
        /// </summary>
        /// <returns></returns>
        public string BookActor()
        {
            return BookActor(string.Empty);

            //var details = "Booking can change";

            //return "Actor " + ActorName + " is booked. Details: " + details;
        }

        /// <summary>
        /// Book actor for specific date
        /// </summary>
        /// <param name="theDate"></param>
        /// <returns></returns>
        public string BookActor(string theDate)
        {
            var details = "Booking can change";

            var theActor = "Actor " + ActorName + " is booked";

            if (!string.IsNullOrEmpty(theDate))
                return theActor + " on " + theDate + ". Details: " + details;

            return  theActor + " on . Details: " + details;
        }
    }
}
