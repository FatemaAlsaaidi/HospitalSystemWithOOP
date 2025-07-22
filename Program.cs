namespace HospitalSystemWithOOP
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // create list for Patient
            List<Patient> patients = new List<Patient>();
            // create list for Doctor
            List<Doctor> doctors = new List<Doctor>();
            // create list for Appointment
            List<Appointment> appointments = new List<Appointment>();

            // create menue 
            Console.WriteLine("Welcome to the Hospital System");
            Console.Write("Please select an option (1-3): ");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Booking Appointment");
            Console.WriteLine("4. Displaying all appointments ");
            Console.WriteLine("5. Showing available doctors by specialization ");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddNewPatient();
                    Console.ReadLine();
                    break;
                case 2:
                    AddNewDoctor();
                    Console.ReadLine();
                    break;
            }
        }

        // Method to add new patient
        static void AddNewPatient()
        {
            Patient newPatient = new Patient();
            Console.Write("Enter Patient ID: ");
            newPatient.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Patient Name: ");
            newPatient.Name = Console.ReadLine();
            Console.Write("Enter Patient Age: ");
            newPatient.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            newPatient.PhoneNumber = Console.ReadLine();
            // Display patient information
            newPatient.DisplayInfo();
        }

       
    }

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

    // Appointment class
    public class Appointment
    {
        private int appointmentId;
        private Doctor doctor;
        private Patient patient;
        private DateTime appointmentDate;

        public int AppointmentId { get => appointmentId; set => appointmentId = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Appointment ID: {AppointmentId}, Doctor: {Doctor.Name}, Patient: {Patient.Name}, Date: {AppointmentDate}");
        }
    }


}
