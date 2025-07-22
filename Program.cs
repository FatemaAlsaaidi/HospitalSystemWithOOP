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

            bool MainMenu = true;
            // create menue 
            while (MainMenu) {
            Console.WriteLine("Welcome to the Hospital System");
            Console.Write("Please select an option (1-3): ");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Booking Appointment");
            Console.WriteLine("4. Displaying all appointments ");
            Console.WriteLine("5. Showing available doctors by specialization ");
            Console.WriteLine("6. Displaying all appointments for specific patient name");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNewPatient(patients);
                        Console.ReadLine();
                        break;
                    case 2:
                        AddNewDoctor(doctors);
                        Console.ReadLine();
                        break;
                    case 3:
                        BookAppointment(doctors, patients, appointments);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter the doctor ID:");
                        int doctorId = Convert.ToInt32(Console.ReadLine());
                        DisplayingAllAppointments(doctorId);
                        Console.ReadLine();
                        break;
                    case 5:
                        // Print all specializations in the hospital 
                        Console.WriteLine("Available Specializations:");
                        Console.WriteLine("1. Cardiology");
                        Console.WriteLine("2. Neurology");
                        Console.WriteLine("3. Orthopedics");

                        string specialization = Console.ReadLine();
                        ShowingAvailableDoctorsBySpecialization(specialization);
                        break;
                    case 6:
                        Console.WriteLine("Enter the patient name:");
                        string patientNameOrDate = Console.ReadLine();
                        DisplayingAllAppointmentsForPatient(patientNameOrDate);
                        break;
                    case 0:

                        MainMenu = false;
                        break;
                }

            }
        }

        // Method to add new patient
        static void AddNewPatient(List<Patient> patients)
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
            patients.Add(newPatient); // Add to the patients list
            Console.WriteLine("Patient added successfully!");
        }

        // Method to add new doctor
        static void AddNewDoctor(List<Doctor>doctors)
        {
            Doctor newDoctor = new Doctor();
            Console.WriteLine("Enter Doctor ID: ");
            newDoctor.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctor Name: ");
            newDoctor.Name = Console.ReadLine();
            Console.WriteLine("Enter Doctor Age: ");
            newDoctor.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("select Specialization: ");
            Console.WriteLine("1. Cardiology");
            Console.WriteLine("2. Neurology");
            Console.WriteLine("3. Orthopedics");
           
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    newDoctor.Specialization = "Cardiology";
                    break;
                case '2':
                    newDoctor.Specialization = "Neurology";
                    break;
                case '3':
                    newDoctor.Specialization = "Orthopedics";
                    break;
            }

            // Display doctor information
            newDoctor.DisplayInfo();
            // add to the doctore list 
            doctors.Add(newDoctor); // Corrected: Add to the 'doctors' list passed as parameter
            Console.WriteLine("Doctor added successfully!");



        }

        // Booking an appointment (select doctor and patient from lists) 
        static void BookAppointment(List<Doctor> doctors, List<Patient> patients, List<Appointment> appointments)
        {
            if (doctors.Count == 0 || patients.Count == 0)
            {
                Console.WriteLine("No doctors or patients available for booking.");
                return;
            }
            Console.WriteLine("Select a Doctor ID:");
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {doctors[i].Name} - {doctors[i].Specialization}");
            }
            int doctorIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Select a ID Patient:");
            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {patients[i].Name}");
            }
            int patientIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            // display when doctor can be available
            Console.WriteLine($"--- Availability for Dr. {doctors[doctorIndex].Name} ({doctors[doctorIndex].Specialization}) ---");

            // Get the appointments for the selected doctor
            List<Appointment> doctorAppointments = appointments.Where(a => a.Doctor.Id == doctors[doctorIndex].Id).ToList();
            // list of date 
            List<DateTime> appointmentDates = new List<DateTime>();

            if (doctorAppointments.Count == 0)
            {
                Console.WriteLine($"Dr. {doctors[doctorIndex].Name} currently has no appointments booked. Likely fully available!");
            }
            else
            {
                Console.WriteLine("Booked appointments:");
                foreach (var appt in doctorAppointments.OrderBy(a => a.AppointmentDate)) // Order by date for better readability
                {
                    Console.WriteLine($"- {appt.AppointmentDate:yyyy-MM-dd HH:mm}"); // Format the date nicely
                    appointmentDates.Add(appt.AppointmentDate); // Add to the list of appointment dates
                }
                Console.WriteLine("Please choose an appointment date and time that doesn't conflict with the above.");
            }

            // Enter the date and time of appointment
            Console.WriteLine("Enter Appointment Date and Time (YYYY-MM-DD HH:mm:ss):");
            DateTime appointmentDate;
            while (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
            {
                Console.WriteLine("Invalid date and time format. Please enter a valid date and time (YYYY-MM-DD HH:mm:ss):");
            }
            if (appointmentDates.Any(d => d == appointmentDate))
            {
                Console.WriteLine("This appointment time is already booked. Please choose a different time.");
                return;
            }
            else
            {
                Appointment newAppointment = new Appointment
                {
                    AppointmentId = appointments.Count + 1,
                    Doctor = doctors[doctorIndex],
                    Patient = patients[patientIndex],
                    AppointmentDate = appointmentDate
                };
                appointments.Add(newAppointment);
                newAppointment.DisplayInfo();
                Console.WriteLine("Appointment booked successfully!");
            }

                
        }

        // Displaying all appointments for specific doctor 
        static void DisplayingAllAppointments(int doctorId)
        {
            // Assuming appointments is a list of Appointment objects
            List<Appointment> appointments = new List<Appointment>(); // This should be populated with actual data
            Console.WriteLine($"Appointments for Doctor ID: {doctorId}");
            foreach (var appointment in appointments)
            {
                if (appointment.Doctor.Id == doctorId)
                {
                    appointment.DisplayInfo();
                }
            }
        }

        // Displaying all appointments for specific dpatient name
        static void DisplayingAllAppointmentsForPatient(string patientName)
        {
            // Assuming appointments is a list of Appointment objects
            List<Appointment> appointments = new List<Appointment>(); // This should be populated with actual data
            Console.WriteLine($"Appointments for Patient: {patientName}");
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase))
                {
                    appointment.DisplayInfo();
                }
            }
        }

        // Showing available doctors by specialization
        static void ShowingAvailableDoctorsBySpecialization(string specialization)
        {
            // Assuming doctors is a list of Doctor objects
            List<Doctor> doctors = new List<Doctor>(); // This should be populated with actual data
            Console.WriteLine($"Doctors with specialization in {specialization}:");
            foreach (var doctor in doctors)
            {
                if (doctor.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Age: {doctor.Age}");
                }
            }
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
