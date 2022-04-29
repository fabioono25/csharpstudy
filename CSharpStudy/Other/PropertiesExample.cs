using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpStudy.CSharp1
{
    public class PropertiesExample : INotifyPropertyChanged
    {
        public ICollection<string> points { get; } = new List<string>();

        //C# 7.3: fields are not persisted
        [field: NonSerialized]
        public int Id { get; set; }

        //

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //specify with a storage
        private string lastName;

        //when property changes, the object raises the PropertyChanged event to indicate the change
        public event PropertyChangedEventHandler PropertyChanged;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        //basic implementation
        public string FirstName { get; } = "default"; //initial value empty string than null

        //expression-bodie members
        public string LastName2
        {
            get => lastName;
            set => lastName = (!string.IsNullOrEmpty(value)) ? value : throw new ArgumentException("last name must not be blank");
        }

        public string ChangePropert
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("value not found");

                if (value != lastName)
                {
                    //if there are no subscribers to the PropertyChanged event, the code to raise the event doesn't execute
                    //i't woult throw a NullReferenceException
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangePropert)));
                }

                lastName = value;
            }
        }

        public PropertiesExample()
        {
        }

        public PropertiesExample(string name) => FirstName = name;
    }
}