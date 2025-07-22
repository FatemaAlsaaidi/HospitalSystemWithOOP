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

        
        static void Main(string[] args)
        {
        }

        
    }


}
