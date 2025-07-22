namespace HospitalSystemWithOOP
{
    internal class Program
    {
        // Create Person Class 
        public class Person
        {
            //  private fields 
            private int id;
            private string name;
            private int age;

            // properties
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            // virtual method to display person details
            public virtual void DisplayInfo()
            {
                //Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
            }

        }
        // Create Patient Class that inherits from Person
        public class Patient : Person
        {
            // public feild
            public string PhoneNumber { get; set; }
            // override DisplayInfo method
            public override void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Phone: {PhoneNumber}");
            }
        }

        // Create Doctor Class that inherits from Person
        public class Doctor : Person
        {
            // private fields
            private string specialization;

            // list of doctor info 
            public List<Doctor> doctors = new List<Doctor>();

            // DateTime list Appointments
            public List<Doctor> appointments = new List<Doctor>();

            // properties
            public string Specialization
            {
                get { return specialization; }
                set { specialization = value; }
            }
           

            // override DisplayInfo method
            public override void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Phone: {specialization}");
            }


        }


        static void Main(string[] args)
        {
        }

        
    }


}
