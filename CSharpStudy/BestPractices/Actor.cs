namespace CSharpStudy.BestPractices
{
    public class Actor
    {
        public Actor()
        {
            Console.WriteLine("An Actor is born!");
            this.CurrentAgency = new Agency();
        }

        public Actor(string actorName) : this() //force the execution of default constructor
        {
            ActorName = actorName;
        }

        public string JobTitle { get; set; }
        private string actorName;

        public string ActorName
        {
            get { return actorName; }
            set
            {
                var formattedName = value?.Trim(); //checking for null... if YES, it'll not call Trim() method (null conditional operator)
                actorName = formattedName;
            }
        }

        public int ActorAge { get; set; }
        public string ActorDescription { get; set; } = "Regular Actor";

        private Agency currentAgency;

        public Agency CurrentAgency
        {
            get { return currentAgency; }
            set { currentAgency = value; }
        }

        public Agency CurrentAgency2
        {
            get
            {

                if (currentAgency == null)
                {
                    currentAgency = new Agency();
                }

                return currentAgency;
            }
            set { currentAgency = value; }
        }

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

            return theActor + " on . Details: " + details;
        }

        public string GetAgency()
        {
            var currentAgency = new Agency();

            return currentAgency.Name;
        }

        public string GetAgencyByProp()
        {
            return CurrentAgency.Name;
        }

        public string GetAgencyByProp2()
        {
            return CurrentAgency2.Name;
        }

        public static void OpenFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\test.txt");

            using (var fs1 = new FileStream(path, FileMode.Open))
            {
                //do something
            }

            using (var fs2 = new FileStream(path, FileMode.Open))
            {
                //do something
            }
        }
    }
}
